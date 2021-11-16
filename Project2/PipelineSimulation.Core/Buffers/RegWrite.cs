namespace PipelineSimulation.Core.Buffers
{
    public class RegWrite : CPUBuffer
    {
        public override int ID => 5;

        public RegWrite(CPU cpuref) : base(cpuref) {
        }

        public override void PerformBehavior(CPU cpu)
        {
            if (DecodedInstructions.Count == 0)
                return;

            var ins = DecodedInstructions.Peek();
            var value = ins.Result;
            //TODO: check for data hazard
            ins.DestinationRegister.Data = value;
        }
    }
}