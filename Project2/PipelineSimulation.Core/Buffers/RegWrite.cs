using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public class RegWrite : CPUBuffer
    {
        public override int ID => 5;

        public RegWrite(CPU cpuref) : base(cpuref) {
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

                if (ins is NOP) // This can occur when there is a bubble (stalling)
                    return;

                var value = ins.Result;
                //TODO: check for data hazard
                ins.DestinationRegister.Data = value;

                ReadyInstructions.Enqueue(DecodedInstructions.Dequeue());
            }
        }
    }
}