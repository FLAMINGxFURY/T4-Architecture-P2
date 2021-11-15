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
            rwr();
            mwr();

            // EXEC - moves from exec to proper next buffer
            ex();            

            // READ
            mrd();

            // DECODE
            dec();

            // FETCH
            fet();

            CurrentClockCycle++;
        }

        // fetches a new instance of an Instruction based on the provided opCode
        public Instruction CreateInstructionInstance(ushort opCode)
        {
            return (Instruction)Activator.CreateInstance(_opToType[opCode], this);
        }

		#region Pipeline Stages

		void fet() {
            Buffers[0].MoveContents(Buffers[1]);
            Buffers[0].PerformBehavior(this);       // Moves PC forward, fetches next instruction
        }

        void dec() {
            // TODO: Read buffer can be skipped
            // TODO: as soon as END is decoded, don't allow any more fetches. (Allow program to run until buffers are empty)
            Buffers[1].MoveContents(Buffers[2]);
            Buffers[1].PerformBehavior(this);       // Fetches instruction, stores decoded instruction
        }

        void mrd() {
            Buffers[2].MoveContents(Buffers[3]);
            Buffers[2].PerformBehavior(this);       // Gets values in memory, sends them to functional units  
        }

        void ex() {
            if (Buffers[3].DecodedInstruction != null) {
                // TODO: Instruction decoding here needs to be more robust. MOVO is the only instruction writing out to memory, but a significant
                // amount of our instructions write back to a register (I Type, R type, M type). Additionally, the R type instructions don't end in "R"

                if (Buffers[3].DecodedInstruction.GetType().Name.EndsWith("O")) // TODO: This is really hacky 
                {
                    Buffers[3].MoveContents(Buffers[4]); // mem write instructions
                }
                else if (Buffers[3].DecodedInstruction.GetType().Name.EndsWith("R")) {
                    Buffers[3].MoveContents(Buffers[5]); // reg write instructions
                }
                else {
                    CompletedInstructions.Add(Buffers[3].DecodedInstruction);
                }

                // TODO: should exececution happen first? Remember it can't move forward in the pipeline until clock cycles remaining == 0

                Buffers[3].PerformBehavior(this);   // Executes

                Buffers[3].Empty();
            }
        }

        void mwr() {
            if (Buffers[4].DecodedInstruction != null) {
                CompletedInstructions.Add(Buffers[4].DecodedInstruction);
                Buffers[4].PerformBehavior(this);   // Writes to memory
                Buffers[4].Empty();
            }
        }

        void rwr() {
            if (Buffers[5].DecodedInstruction != null) {
                CompletedInstructions.Add(Buffers[5].DecodedInstruction);
                Buffers[5].PerformBehavior(this);   // Writes to registers
                Buffers[5].Empty();
            }
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
