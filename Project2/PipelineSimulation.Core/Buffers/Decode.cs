using PipelineSimulation.Core.Instructions;
using System.Collections.Generic;

namespace PipelineSimulation.Core.Buffers
{
    public class Decode : CPUBuffer
    {
		
		public override int ID => 1;

        // This is stored so that jumps know what instruction they are waiting on
        // Same for M-Type and O-Type: they need to wait on MOVI s1, xxx 
        public Instruction LastDelivered;

        public Decode(CPU cpuref) : base(cpuref) {
            FetchedInstructions = new Queue<ushort>();
        }

        /// <summary>
        /// Gets the instruction from the fetch buffer. Decodes it.
        /// </summary>
        public override void PerformBehavior(CPU cpu)
        {
            WorkingInstruction = FetchedInstructions.Peek();

            // Decode it
            var decoded = (ushort)(WorkingInstruction >> 11);
            var ins = cpu.CreateInstructionInstance(decoded);

            // Add its op to the instruction
            ins.Operand = WorkingInstruction;

            // Based on instruction type add Source Register and Destination Register to the ins

            // Source Reg: R-Type instructions
            if(cpu.RTpyeOpCodes.Contains(decoded)) {
                ins.SourceRegister = cpu.GetRegister(ins.GetRegister2Code(WorkingInstruction));
			}

            // Destination Reg: R-Type, I-Type, M-Type
            if(cpu.RTpyeOpCodes.Contains(decoded) || cpu.ITypeOpCodes.Contains(decoded) || cpu.MTypeOpCodes.Contains(decoded) || cpu.OTypeOpCodes.Contains(decoded)) {
                ins.DestinationRegister = cpu.GetRegister(ins.GetRegister1Code(WorkingInstruction));
			}
            
            // Determine where it needs to go next
            // TODO: Jumps need to execute here. They have a completion dependency on the last instruction
            // Left here. Nothing else can be fetched while we are waiting for a jump to execute.
            if(cpu.JumpOpCodes.Contains(decoded)) {
                //Condition: If MemRead or Execute contain the last delivered instruction, stop here. 
                if(cpu.Buffers[2].DecodedInstructions.Contains(LastDelivered) || cpu.Buffers[3].DecodedInstructions.Contains(LastDelivered)) { //Check memread and exec
                    cpu.stopFetch = true; //flag for no more fetches
                    return;
				}

                //implied else: continue
                cpu.stopFetch = false; //flag that fethces can continue
                ins.Execute(ins.Operand);
                //flag completion and dequeue
                cpu.CompletedInstructions.Add(ins);
                FetchedInstructions.Dequeue();

			}

            // TODO: If not a jump, determine whether it needs to go to MemRead or Execute based on opcode.

        }
    }
}