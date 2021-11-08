using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// Figure we could use this on the UI to show what instructions are
        /// completed.
        /// </summary>
        public List<Instruction> CompletedInstructions = new List<Instruction>();

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
            // TODO: Behavior not implemented

            // WRITE - moves from write to decoded instruction pool
            if (Buffers[5].DecodedInstruction != null)
            {
                CompletedInstructions.Add(Buffers[5].DecodedInstruction);
                Buffers[5].Empty();
            }
            else if (Buffers[4].DecodedInstruction != null) // These buffers can't be working at the same time, right?
            {
                CompletedInstructions.Add(Buffers[4].DecodedInstruction);
                Buffers[4].Empty();
            }

            // EXEC - moves from exec to proper next buffer
            if (Buffers[3].DecodedInstruction != null)
            {
                if (Buffers[3].DecodedInstruction.ToString().Contains("M")) // TODO: This is really hacky
                {
                    Buffers[3].MoveContents(Buffers[4]); // mem write instructions
                }
                else if (Buffers[3].DecodedInstruction.ToString().Contains("R"))
                {
                    Buffers[3].MoveContents(Buffers[5]); // reg write instructions
                }
                else
                {
                    CompletedInstructions.Add(Buffers[3].DecodedInstruction);
                }

                Buffers[3].Empty();
            }

            // TODO - these steps
            // READ
            Buffers[2].MoveContents(Buffers[3]);

            // DECODE
            Buffers[1].MoveContents(Buffers[2]);

            // FETCH
            Buffers[0].MoveContents(Buffers[1]);


            //var next = Rd.GetNextWord();

            //var op = (ushort)(next >> 11);

            //Buffers[0].WorkingInstruction = op;

            //TODO: Ensure that this is doing things in the order we want (re: forwarding and hazard handling)
            foreach (var buffer in Buffers.Values)
            {
                buffer.PerformBehavior(this);
            }

            CurrentClockCycle++;
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
