
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public abstract class CPUBuffer
    {
        public abstract int ID { get; }
        public ushort WorkingInstruction { get; set; }
        public CPU cpu { get; set; }

        /// <summary>
        /// Holds the decoded instruction stored in the buffer. This is only
        /// set after the decode phase.
        /// </summary>
        public Instruction DecodedInstruction { get; protected set; }

        public CPUBuffer(CPU cpuref) {
            this.cpu = cpuref;
		}

        public abstract void PerformBehavior(CPU cpu);

        protected uint GetMemoryAddress() {
            //s0 represents upper half of address. Shift to reflect
            uint s0data = (uint)(cpu.GetRegister(6).Data << 4);
            uint s1data = cpu.GetRegister(7).Data;

            //combine and return
            return s0data + s1data;
        }

        /// <summary>
        /// Moves my contents into another buffer.
        /// </summary>
        public void MoveContents(CPUBuffer otherBuffer)
        {
            otherBuffer.WorkingInstruction = WorkingInstruction;

            if (DecodedInstruction != null)
                otherBuffer.DecodedInstruction = DecodedInstruction;
        }

        public void Empty()
        {
            WorkingInstruction = 0x0;
            DecodedInstruction = null;
        }
    }
}
