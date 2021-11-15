using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using PipelineSimulation.Core.Buffers;
using PipelineSimulation.Core.Functional_Units;
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

		// This boolean is used to stop fetches while waiting for a jump, or after end
		public bool stopFetch = false;

		public EFlags EFlags { get; } = new EFlags();

        public ALU ALU { get; } = new ALU();
        public ELU ELU { get; } = new ELU();
        public FPU FPU { get; } = new FPU();

		#region OpCode Defined Lists

		// List of all R-Type instructions
		public List<ushort> RTpyeOpCodes = new List<ushort> {
			0b00100,
			0b00111,
			0b01010,
			0b01011,
			//TOADD: Any of the floating point?
		};

		// List of all M-Type instructions
		public List<ushort> MTypeOpCodes = new List<ushort> {
			0b00010,
			0b00110,
			0b01001,
			0b01111,
			0b10101,
			0b11000,
			0b11011,
			0b11110
		};

		public List<ushort> OTypeOpCodes = new List<ushort> { 0b00011 };

		// List of all I-Type instructions
		public List<ushort> ITypeOpCodes = new List<ushort> {
			0b00001,
			0b00101,
			0b01000,
			//TOADD: Any of the floating point?
		};

		// List of all Jumps
		public List<ushort> JumpOpCodes = new List<ushort> {
			0b01100,
			0b01101,
			0b01110
		};

		// List of all ALU instructions
		public List<ushort> ALUOpCodes = new List<ushort> {
			0b00001,
			0b00010,
			0b00011,
			0b00100,
			0b00101,
			0b00110,
			0b00111,
			0b01000,
			0b01001,
			0b01010
		};

		// List of all FPU instructions
		public List<ushort> FPUOpCodes = new List<ushort> {
			0b01111,
			0b10000,
			0b10001,
			0b10010,
			0b10011,
			0b10100,
			0b10101,
			0b10110,
			0b10111,
			0b11000,
			0b11001,
			0b11010,
			0b11011,
			0b11100,
			0b11101,
			0b11110
		};

		// List of al ELU instructions
		public List<ushort> ELUOpCodes = new List<ushort> {
			0b00000,
			0b01011,
			0b01100,
			0b01101,
			0b01110,
			0b11111
		};

		#endregion

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

			// FETCH
			fet();

			// DECODE
			dec();

			// READ
			mrd();

			// EXEC - moves from exec to proper next buffer
			ex();

			// WRITE - moves from write to decoded instruction pool
			mwr();
			rwr();

			CurrentClockCycle++;
		}

		// fetches a new instance of an Instruction based on the provided opCode
		public Instruction CreateInstructionInstance(ushort opCode)
		{
			return (Instruction)Activator.CreateInstance(_opToType[opCode], this);
		}

		#region Pipeline Stages

		void fet() {
			Buffers[0].PerformBehavior(this);       // Moves PC forward, fetches next instruction
		}

		void dec() {
			// TODO: Read buffer can be skipped
			// TODO: as soon as END is decoded, don't allow any more fetches. (Allow program to run until buffers are empty)
			Buffers[1].PerformBehavior(this);       // Fetches instruction, stores decoded instruction
		}

		void mrd() {
			Buffers[2].PerformBehavior(this);       // Gets values in memory, sends them to functional units  
		}

		void ex() {
            Buffers[3].PerformBehavior(this);		// Executes
		}

		void mwr() {
            Buffers[4].PerformBehavior(this);   // Writes to memory
		}

		void rwr() {
            Buffers[5].PerformBehavior(this);   // Writes to registers
		}

		#endregion

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
