namespace PipelineSimulation.Core.Buffers
{
    public class MemWrite : CPUBuffer
    {
        public override int ID => 4;

        public override void PerformBehavior(CPU cpu)
        {
            // TODO
            // !Important - this must call Memory.Unlock(addr) when done
        }
    }
}