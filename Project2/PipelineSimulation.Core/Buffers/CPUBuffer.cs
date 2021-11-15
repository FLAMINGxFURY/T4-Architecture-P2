
using PipelineSimulation.Core.Instructions;
using System.Collections.Generic;

namespace PipelineSimulation.Core.Buffers
{
    public abstract class CPUBuffer
    {
        public abstract int ID { get; }
        public ushort WorkingInstruction { get; set; }
        public CPU cpu { get; set; }

        /// <summary>
        /// Holds the decoded instructions stored in the buffer. This is only
        /// set after the decode phase.
        /// </summary>
        public Queue<Instruction> DecodedInstructions { get; protected set; }

        /// <summary>
        /// Memory that is read after the read memory phase. This is not set
        /// until then.
        /// </summary>
        public ushort ReadMemory { get; protected set; }

        public CPUBuffer(CPU cpuref) {
            this.cpu = cpuref;
            DecodedInstructions = new Queue<Instruction>();
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

            //if (DecodedInstruction != null)
            //    otherBuffer.DecodedInstruction = DecodedInstruction;

            //This should now be handled by peeking and dequeueing

            otherBuffer.ReadMemory = ReadMemory;
        }

        public void Empty()
        {
            WorkingInstruction = 0x0;
            DecodedInstructions.Clear();
            ReadMemory = 0x0;
        }
    }
}
