
using System.Collections.Generic;

namespace PipelineSimulation.Core.Buffers
{
    public class Fetch : CPUBuffer
    {
        public override int ID => 0;

        public Queue<ushort> FetchedInstructions;

        public Fetch(CPU cpuref) : base(cpuref) {
            FetchedInstructions = new Queue<ushort>();
        }

        /// <summary>
        /// Gets the next instruction in memory, stores it in this buffer.
        /// Moves the PC forward.
        /// </summary>
        public override void PerformBehavior(CPU cpu)
        {
            var op = cpu.Rd.GetNextWord();  // This also moves the PC forward
            WorkingInstruction = op;
        }
    }
}
