using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public class Decode : CPUBuffer
    {
        public override int ID => 1;

        /// <summary>
        /// Gets the instruction from the fetch buffer. Decodes it.
        /// </summary>
        /// <param name="cpu"></param>
        public override void PerformBehavior(CPU cpu)
        {
            // Decode it
            ushort decoded = (ushort)(WorkingInstruction >> 11);
            //Instruction ins = cpu._operations[decoded];

            // Store decoded instruction here too
            //DecodedInstruction = ins;
        }
    }
}