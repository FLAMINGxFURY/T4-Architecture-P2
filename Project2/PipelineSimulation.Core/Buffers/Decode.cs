using PipelineSimulation.Core.Instructions;
using System.Collections.Generic;

namespace PipelineSimulation.Core.Buffers
{
    public class Decode : CPUBuffer
    {
		
		public override int ID => 1;

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

            // TODO: Based on instruction type add Source Register, Destination Register, and Destination Address
            // to the Instruction


            
            // Determine where it needs to go next
            // TODO: Jumps need to execute here. They have a completion dependency on the last instruction
            // Left here. Nothing else can be fetched while we are waiting for a jump to execute.

            // TODO: If not a jump, determine whether it needs to go to MemRead or Execute based on opcode.

        }
    }
}