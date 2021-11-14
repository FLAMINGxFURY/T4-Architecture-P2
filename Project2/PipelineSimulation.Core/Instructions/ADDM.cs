using System;

namespace PipelineSimulation.Core.Instructions
{
	public class ADDM : Instruction
	{
		public override ushort OpCode => 0x06;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => true;
        public override bool UsesRegister => false;

		public ADDM(CPU cpuref) : base(cpuref) {

		}

		// Returns the value to be stored in the destination register
		public override ushort Execute(ushort operand) {
			var register = cpu.GetRegister(GetRegister1Code(operand));
			var addr = GetMemoryAddress();

			ushort data;

			try {
				data = Memory.RequestMemoryFromAddr(addr);
			}
			catch (AccessViolationException e) {
				//TODO: add stall
				return 0;
			}

			ushort ret = (ushort)(register.Data + data);

			// I broke this because I took bytes out, so it just doesn't :)
			//cpu.EFlags.SetAll
			//(
			//	WouldCarry(byte1, byte2),
			//	Parity(register.Data),
			//	AuxiliaryCarryAddition(byte1, byte2),
			//	register.Data == 0,
			//	register.Data < 0,
			//	WouldOverflow(byte1, byte2)
			//);

			return ret;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString();
		}

		public override string ToString() {
			return "ADDM";
		}
	}
}
