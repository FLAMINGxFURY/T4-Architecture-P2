using PipelineSimulation.Core.Instructions;
using System.Collections.Generic;

namespace PipelineSimulation.Core.Buffers
{
    public class Decode : CPUBuffer
    {
		
		public override int ID => 1;

        public Queue<ushort> FetchedInstructions;

        public Decode(CPU cpuref) : base(cpuref) {
            FetchedInstructions = new Queue<ushort>();
        }

        /// <summary>
        /// Gets the instruction from the fetch buffer. Decodes it.
        /// </summary>
        public override void PerformBehavior(CPU cpu)
        {
            // Decode it
            var decoded = (ushort)(WorkingInstruction >> 11);
            var ins = cpu.CreateInstructionInstance(decoded);
            DecodedInstructions.Enqueue(ins);
        }
    }
}