using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using PipelineSimulation.Core.Buffers;
using PipelineSimulation.Core.Instructions;
using PipelineSimulation.Core.Registers;

namespace PipelineSimulation.Core
{
	public class CPU
    {
        public int CurrentClockCycle = 0;
        private int _currentBuffer = 0;

		//public byte[] Memory { get; set; } = new byte[1048576]; //1 MiB = 1024 KiB = 1024 * 1024 B
        public Memory Memory = Memory.GetInstance();

        public Reader Rd;

        private Dictionary<ushort, Register> _registers = new Dictionary<ushort, Register>();

        public SortedDictionary<int, CPUBuffer> Buffers = new SortedDictionary<int, CPUBuffer>();

        public Dictionary<ushort, Type> _opToType = new Dictionary<ushort, Type>();

		public bool endReached;

		public EFlags EFlags { get; } = new EFlags();

		public Register PC => _registers[0x06];

		// Buffers
        public CPU() {

            //instantiate reader
			Rd = new Reader(this);

			endReached = false;

			//add all instructions and registers to dictionaries
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.BaseType == typeof(Instruction))
                {
                    var op = (Instruction)Activator.CreateInstance(type, this);
                    _opToType.Add(op.OpCode, type);
                }

                if (type.BaseType == typeof(Register))
                {
					var reg = (Register)Activator.CreateInstance(type);
					_registers.Add(reg.ID, reg);
                }

                if (type.BaseType == typeof(CPUBuffer))
                {
                    var buffer = (CPUBuffer)Activator.CreateInstance(type);
                    Buffers.Add(buffer.ID, buffer);
                }
            }
        }

		public Register GetRegister(ushort id)
        {
			return _registers[id];
        }

        public void NextClockCycle()
        {
            //TODO: Ensure that this is doing things in the order we want (re: forwarding and hazard handling)
            foreach (var buffer in Buffers.Values)
            {
                buffer.PerformBehavior(this);
            }

            CurrentClockCycle++;
        }

        public void MoveBuffersForward()
        {
            //TODO: stalling logic for each buffer. Also refactor so that CPU moves these values, not the Buffers.
            //The point being that stages in the pipeline can be skipped
            foreach (var buffer in Buffers.Values.Reverse())
            {
                buffer.MoveForward(this);
            }
        }

        // fetches a new instance of an Instruction based on the provided opCode
        public Instruction CreateInstructionInstance(ushort opCode)
        {
            return (Instruction)Activator.CreateInstance(_opToType[opCode], this);
        }

		#region obsolete

		[Obsolete]
		public bool ParseNextOp() {
			Rd.ParseNextOp();

			return endReached;

		}

		[Obsolete]
		public void End() {
			endReached = true;
		}

        #endregion

    }
}
