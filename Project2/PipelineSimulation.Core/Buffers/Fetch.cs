
using System.Collections.Generic;

namespace PipelineSimulation.Core.Buffers
{
    public class Fetch : CPUBuffer
    {
        public override int ID => 0;

        public Fetch(CPU cpuref) : base(cpuref) {
            FetchedInstructions = new Queue<ushort>();
        }

        /// <summary>
        /// Gets the next instruction in memory, stores it in this buffer.
        /// Moves the PC forward.
        /// </summary>
        public override void PerformBehavior(CPU cpu)
        {
            //First, pass to decode
            if(FetchedInstructions.Count != 0) {
                if(cpu.Buffers[1].FetchedInstructions.Count < 6) { //simulating size constraint
                    cpu.Buffers[1].FetchedInstructions.Enqueue(FetchedInstructions.Dequeue()); // Pass
                }
			}
            
            //Next, grab next op
            var op = cpu.Rd.GetNextWord();  // This also moves the PC forward
            FetchedInstructions.Enqueue(op);
        }
    }
}
