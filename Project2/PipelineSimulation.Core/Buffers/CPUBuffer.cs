
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public abstract class CPUBuffer
    {
        public abstract int ID { get; }
        public ushort Contents { get; set; }
        /// <summary>
        /// Holds the decoded instruction stored in the buffer. This is only
        /// set after the decode phase.
        /// </summary>
        public Instruction DecodedInstruction { get; protected set; }
        /// <summary>
        /// Memory that is read after the read memory phase. This is not set
        /// until then.
        /// </summary>
        public ushort ReadMemory { get; protected set; }

        public abstract void PerformBehavior(CPU cpu);

        public void MoveForward(CPU cpu)
        {
            // Move my contents to the next buffer
            var nextBuff = ID + 1;
            if (nextBuff < cpu.Buffers.Count)
            {
                cpu.Buffers[nextBuff].Contents = Contents;
                cpu.Buffers[nextBuff].DecodedInstruction = DecodedInstruction;
                cpu.Buffers[nextBuff].ReadMemory = ReadMemory;
            }
            else
            {
                // TODO: Maybe have a "finished instruction" pool   
            }
        }
    }
}
