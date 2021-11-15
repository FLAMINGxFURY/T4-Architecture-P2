using PipelineSimulation.Core.Instructions;
using System.Collections.Generic;

namespace PipelineSimulation.Core.Buffers
{
    public class Decode : CPUBuffer
    {
		
		public override int ID => 1;

        // This is stored so that jumps know what instruction they are waiting on
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
            if(cpu.RTpyeOpCodes.Contains(decoded) || cpu.ITypeOpCodes.Contains(decoded) || cpu.MTypeOpCodes.Contains(decoded)) {
                ins.DestinationRegister = cpu.GetRegister(ins.GetRegister1Code(WorkingInstruction));
			}
            
            // Determine where it needs to go next
            // TODO: Jumps need to execute here. They have a completion dependency on the last instruction
            // Left here. Nothing else can be fetched while we are waiting for a jump to execute.

            // TODO: If not a jump, determine whether it needs to go to MemRead or Execute based on opcode.

        }
    }
}