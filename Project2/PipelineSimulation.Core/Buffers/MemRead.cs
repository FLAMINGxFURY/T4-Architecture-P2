
using System;

namespace PipelineSimulation.Core.Buffers
{
    public class MemRead : CPUBuffer
    {
        public override int ID => 2;

        public MemRead(CPU cpuref) : base(cpuref) {
        }

        public override void PerformBehavior(CPU cpu)
        {
            if (DecodedInstructions.Count == 0)
                return;

            // Mem read
            var addr = GetMemoryAddress();

            if (cpu.Buffers[3].DecodedInstructions.Count < 6) { //simulate size constraint
                try {
                    //Store data in instruction
                    DecodedInstructions.Peek().DataBuffer = Memory.RequestMemoryFromAddr(addr);
                    //TODO: how are we going to simulate multiple cycle reads here

                    //Free memory access
                    Memory.Unlock(addr);

                    //Pass to execute
                    cpu.Buffers[3].DecodedInstructions.Enqueue(DecodedInstructions.Dequeue());

                }
                catch (AccessViolationException e) {
                    //Doing nothing here is inherently a stall because no data is being moved between buffers
                }
            }
        }
    }
}