using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public class Decode : CPUBuffer
    {
        public override int ID => 1;

        /// <summary>
        /// Gets the instruction from the fetch buffer. Decodes it.
        /// </summary>
        public override void PerformBehavior(CPU cpu)
        {
            // Decode it
            var decoded = (ushort)(WorkingInstruction >> 11);
            var ins = cpu.CreateInstructionInstance(decoded);
            DecodedInstruction = ins;

            // Immediate read
            if (DecodedInstruction.GetType().Name.EndsWith("I"))
            {
                var imm = (ushort)(0b_0000_0000_0000_1111 & WorkingInstruction);
            }

            // Send imm to functional unit
            // TODO
        }
    }
}