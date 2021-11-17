using System;
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public class MemWrite : CPUBuffer
    {
        public override int ID => 4;

        public MemWrite(CPU cpuref) : base(cpuref) {
        }

        public override void PerformBehavior(CPU cpu)
        {
            if (ReadyInstructions.Count > 0)
            {
                cpu.CompletedInstructions.Add(ReadyInstructions.Dequeue());
            }

            if (DecodedInstructions.Count > 0)
            {
                var ins = DecodedInstructions.Peek();
                var addr = ins.DestinationAddr;

                if (ins is NOP) // This can occur when there is a bubble (stalling)
                    return;

                try
                {                    
                    Memory.StoreMemoryAtAddr(ins.Result, addr);
                    
                    Memory.Unlock(addr);

                    ReadyInstructions.Enqueue(DecodedInstructions.Dequeue());
                }
                catch (AccessViolationException)
                {
                    cpu.Buffers[4].DecodedInstructions.Enqueue(new NOP(cpu));
                }
            }
        }
    }
}