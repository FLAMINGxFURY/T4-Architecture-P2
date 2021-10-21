using System;
using System.Reflection;
using System.Collections.Generic;
using InstructionSetSimulation.Core.Instructions;
using InstructionSetSimulation.Core.Registers;

namespace InstructionSetSimulation.Core
{
	public class CPU
	{
		public byte[] Memory { get; set; } = new byte[1048576]; //1 MiB = 1024 KiB = 1024 * 1024 B

		public Reader Rd;


		private Dictionary<ushort, Register> _registers = new Dictionary<ushort, Register>();

		public Dictionary<ushort, Instruction> _operations = new Dictionary<ushort, Instruction>();

		public bool endReached;

		public EFlags EFlags { get; } = new EFlags();

		public Register PC => _registers[0x06];

		public CPU() {

			Rd = new Reader(this);

			endReached = false;

			//add all instructions and registers to dictionaries
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
				if (type.BaseType == typeof(Register))
                {
					var reg = (Register)Activator.CreateInstance(type);
					_registers.Add(reg.ID, reg);
                }

				if (type.BaseType == typeof(Instruction))
                {
					var instruction = (Instruction)Activator.CreateInstance(type, this);
					_operations.Add(instruction.OpCode, instruction);
                }
            }
		}

		public Register GetRegister(ushort id)
        {
			return _registers[id];
        }

		public bool ParseNextOp() {
			Rd.ParseNextOp();

			return endReached;

		}

		public void End() {
			endReached = true;
		}

	}
}
