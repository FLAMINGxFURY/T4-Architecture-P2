
namespace PipelineSimulation.Core.Buffers
{
    public class Execute : CPUBuffer
    {
        public override int ID => 3;

        public override void PerformBehavior(CPU cpu)
        {
            if (DecodedInstruction != null)
            {
                DecodedInstruction.Execute(ReadMemory);
            }
        }
    }
}