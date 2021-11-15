
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
            // Mem read
            var addr = GetMemoryAddress();

            try {
                //Store data in instruction
                DecodedInstructions.Peek().DataBuffer = Memory.RequestMemoryFromAddr(addr);
                //TODO: how are we going to simulate multiple cycle reads here

                //Free memory access
                Memory.Unlock(addr);

                //TODO: If next buffer is not full, Dequeue and Enqueue. If it is, do nothing. This operation will
                //repeat but that's fine, at least for now
            }
            catch (AccessViolationException e) {
                //TODO: add stall
            }
        }
    }
}