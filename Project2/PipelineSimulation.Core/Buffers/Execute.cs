
namespace PipelineSimulation.Core.Buffers
{
    public class Execute : CPUBuffer
    {
        public override int ID => 3;

        public override void PerformBehavior(CPU cpu)
        {
            // Check for dependency
            // TODO

            // Check logical unit
            // TODO

            if (DecodedInstruction != null)
            {
                DecodedInstruction.Execute(ReadMemory);
            }

            // Forwarding
            // TODO
        }
    }
}