
namespace PipelineSimulation.Core.Buffers
{
    public class Fetch : CPUBuffer
    {
        public override int ID => 0;

        /// <summary>
        /// Gets the next instruction in memory, stores it in this buffer.
        /// </summary>
        public override void PerformBehavior(CPU cpu)
        {
            var op = cpu.Rd.GetNextWord();
            Contents = op;
        }
    }
}
