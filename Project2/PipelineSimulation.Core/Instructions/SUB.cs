
namespace PipelineSimulation.Core.Instructions
{
	public class SUB : Instruction
	{
		public override ushort OpCode => 0x0A;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => true;
        public override bool UsesRegister => true;

		public SUB(CPU cpuref) : base(cpuref) {

		}

		// Returns the value to be stored in the destination register
		public override ushort Execute(ushort operand) {
			// src1
			DestinationRegister = cpu.GetRegister(GetRegister1Code(operand));
			// src2
			var srcReg2 = cpu.GetRegister(GetRegister2Code(operand));

			var val1 = DestinationRegister.Data;

			var val2 = srcReg2.Data;

			ushort ret = (ushort)(DestinationRegister.Data - srcReg2.Data);

			cpu.EFlags.SetAll
			(
				WouldBorrow(val1, val2),
				Parity(DestinationRegister.Data),
				AuxiliaryCarrySubtraction(val1, val2),
				DestinationRegister.Data == 0,
				DestinationRegister.Data < 0,
				WouldOverflow(val1, val2)
			);

			return ret;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + cpu.GetRegister(GetRegister2Code(operand)).ToString();
		}

		public override string ToString() {
			return "SUB";
		}
	}
}
