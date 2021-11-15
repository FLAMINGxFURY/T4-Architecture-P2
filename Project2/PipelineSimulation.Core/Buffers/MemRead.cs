
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
            if (DecodedInstruction != null && DecodedInstruction.GetType().Name.EndsWith("M"))
            {
                var addr = GetMemoryAddress();

                try {
                    //Store data in instruction
                    DecodedInstruction.DataBuffer = Memory.RequestMemoryFromAddr(addr);
                    //TODO: how are we going to simulate multiple cycle reads here

                    //Free memory access
                    Memory.Unlock(addr);
                }
                catch (AccessViolationException e) {
                    //TODO: add stall
                }
            }
        }
    }
}