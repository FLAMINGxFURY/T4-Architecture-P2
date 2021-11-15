namespace PipelineSimulation.Core.Buffers
{
    public class RegWrite : CPUBuffer
    {
        public override int ID => 5;

        public RegWrite(CPU cpuref) : base(cpuref) {
        }

        public override void PerformBehavior(CPU cpu)
        {
            // TODO
        }
    }
}