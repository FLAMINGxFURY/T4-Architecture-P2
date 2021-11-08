
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public abstract class CPUBuffer
    {
        public abstract int ID { get; }
        public ushort WorkingInstruction { get; set; }

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

        /// <summary>
        /// Moves my contents into another buffer.
        /// </summary>
        public void MoveContents(CPUBuffer otherBuffer)
        {
            otherBuffer.WorkingInstruction = WorkingInstruction;
            otherBuffer.DecodedInstruction = DecodedInstruction;
            otherBuffer.ReadMemory = ReadMemory;
        }

        public void Empty()
        {
            WorkingInstruction = 0x0;
            DecodedInstruction = null;
            ReadMemory = 0x0;
        }
    }
}
