
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
                }
                catch (AccessViolationException e) {
                    //TODO: add stall
                }
            }

            // TODO: It is implied that the data being grabbed here is from the S0/S1 pair. 

            // Send value to functional unit
            // TODO

            // TODO: Handle data races
            // !Important - this must call Memory.Unlock(addr) when done
        }
    }
}