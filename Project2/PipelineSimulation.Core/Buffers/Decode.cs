using PipelineSimulation.Core.Instructions;
using PipelineSimulation.Core.Functional_Units;

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

            //TODO 
            // Send imm to functional unit
            foreach(FunctionalUnit unit)
            {
                if(unit.opcodes.Contains(DecodedInstruction.OpCode))
                {
                    unit.instructions.Enqueue(DecodedInstruction);
                    break;
                }
            }
        }
    }
}