using System;

namespace PipelineSimulation.Core.Instructions
{
	public class SUBM : Instruction
	{
		public override ushort OpCode => 0x09;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => true;
        public override bool UsesRegister => false;

		public SUBM(CPU cpuref) : base(cpuref) {

		}

		// Returns the value to be stored in the destination register
		public override ushort Execute(ushort operand) {		

			ushort ret = (ushort)(DestinationRegister.Data - DataBuffer);

			// I broke this because I took bytes out, so it just doesn't :)
			//cpu.EFlags.SetAll
			//(
			//	WouldBorrow(byte1, byte2),
			//	Parity(register.Data),
			//	AuxiliaryCarrySubtraction(byte1, byte2),
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
			return "SUBM";
		}
	}
}
