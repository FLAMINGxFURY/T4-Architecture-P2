using System;

namespace PipelineSimulation.Core.Buffers
{
    public class MemWrite : CPUBuffer
    {
        public override int ID => 4;

        public MemWrite(CPU cpuref) : base(cpuref) {
        }

        public override void PerformBehavior(CPU cpu)
        {
            if (DecodedInstructions.Count == 0)
                return;

            var ins = DecodedInstructions.Peek();
            var addr = ins.DestinationAddr;

            try
            {
                Memory.Unlock(addr);
                Memory.StoreMemoryAtAddr(ins.Result, addr);

                cpu.CompletedInstructions.Add(DecodedInstructions.Dequeue());
            }
            catch (AccessViolationException)
            {
                // TODO: stalling
            }
        }
    }
}