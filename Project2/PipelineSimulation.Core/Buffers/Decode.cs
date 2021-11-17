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
            // Move any decoded instruction to next phase
            if (DecodedInstructions.Count > 0)
            {
                var ins = DecodedInstructions.Peek();

                if (cpu.MTypeOpCodes.Contains(ins.OpCode))
                {
                    if (cpu.Buffers[2].DecodedInstructions.Count < 6)  //simulate size constraint
                    {
                        if (cpu.Buffers[2].DecodedInstructions.Contains(LastDelivered) ||
                        cpu.Buffers[3].DecodedInstructions.Contains(LastDelivered)) {
                            return; //Stall
						}
                        cpu.Buffers[2].DecodedInstructions.Enqueue(ins);
                        FetchedInstructions.Dequeue();
                        DecodedInstructions.Dequeue();
                    }
                }
                else if (cpu.OTypeOpCodes.Contains(ins.OpCode)) {
                    if (cpu.Buffers[2].DecodedInstructions.Contains(LastDelivered) ||
                        cpu.Buffers[3].DecodedInstructions.Contains(LastDelivered)) {
                        return; //Stall
                    }
                    cpu.Buffers[3].DecodedInstructions.Enqueue(ins);
                    FetchedInstructions.Dequeue();
                    DecodedInstructions.Dequeue();
                }
                else
                {
                    if (cpu.Buffers[3].DecodedInstructions.Count < 6)
                    {
                        cpu.Buffers[3].DecodedInstructions.Enqueue(ins);
                        FetchedInstructions.Dequeue();
                        DecodedInstructions.Dequeue();
                    }
                }
            }

            if (FetchedInstructions.Count > 0)
            {
                WorkingInstruction = FetchedInstructions.Peek();

                // Decode it
                var decoded = (ushort) (WorkingInstruction >> 11);
                var ins = cpu.CreateInstructionInstance(decoded);

                var operands = (ushort)(0b_0000_0111_1111_1111 & WorkingInstruction);

                // Add its op to the instruction
                ins.Operand = WorkingInstruction;

                // Based on instruction type add Source Register and Destination Register to the ins

                // Source Reg: R-Type instructions
                if (cpu.RTpyeOpCodes.Contains(decoded))
                {
                    ins.SourceRegister = cpu.GetRegister(ins.GetRegister2Code(operands));
                }

                // Destination Reg: R-Type, I-Type, M-Type
                if (cpu.RTpyeOpCodes.Contains(decoded) || cpu.ITypeOpCodes.Contains(decoded) ||
                    cpu.MTypeOpCodes.Contains(decoded) || cpu.OTypeOpCodes.Contains(decoded))
                {
                    ins.DestinationRegister = cpu.GetRegister(ins.GetRegister1Code(operands));
                }

                // Jumps: They have a completion dependency on the last instruction left here. 
                // Nothing else can be fetched while we are waiting for a jump to execute.
                if (cpu.JumpOpCodes.Contains(decoded))
                {
                    //Condition: If MemRead or Execute contain the last delivered instruction, stop here. 
                    if (cpu.Buffers[2].DecodedInstructions.Contains(LastDelivered) ||
                        cpu.Buffers[3].DecodedInstructions.Contains(LastDelivered))
                    {
                        //Check memread and exec
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

                DecodedInstructions.Enqueue(ins);

                // In the decode phase is where a decoded instruction checks to see specifically if the instruction in execute phase
                // writes to a register
                if (cpu.Buffers[3].DecodedInstructions.Count > 0 && ins.DestinationRegister == cpu.Buffers[3].DecodedInstructions.Peek().SourceRegister && ins.DestinationRegister != null)
                {
                    // If it does, stall in every part of the pipeline
                    cpu.Buffers[1].DecodedInstructions.Enqueue(new NOP(cpu));   // DECODE
                    cpu.Buffers[2].DecodedInstructions.Enqueue(new NOP(cpu));   // MEM READ
                    cpu.Buffers[3].DecodedInstructions.Enqueue(new NOP(cpu));   // EXECUTE
                    cpu.Buffers[4].DecodedInstructions.Enqueue(new NOP(cpu));   // MEM WRITE
                    cpu.Buffers[5].DecodedInstructions.Enqueue(new NOP(cpu));   // REG WRITE
                }
            }
        }
    }
}