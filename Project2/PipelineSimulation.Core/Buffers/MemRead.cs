using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public class MemRead : CPUBuffer
    {
        public override int ID => 2;

        public override void PerformBehavior(CPU cpu)
        {
            // Mem read
            ReadMemory = (ushort)(0b_0000_0111_1111_1111 & Contents);
        }
    }
}