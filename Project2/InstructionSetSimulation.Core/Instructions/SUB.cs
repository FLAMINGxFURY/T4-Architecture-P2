
namespace InstructionSetSimulation.Core.Instructions
{
	public class SUB : Instruction
	{
		public override ushort OpCode => 0x0A;

		public SUB(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			// src1
			var srcReg1 = cpu.GetRegister(GetRegister1Code(operand));
			// src2
			var srcReg2 = cpu.GetRegister(GetRegister2Code(operand));

			var val1 = srcReg1.Data;

			var val2 = srcReg2.Data;

			srcReg1.Data = (ushort)(srcReg1.Data - srcReg2.Data);

			cpu.EFlags.SetAll
			(
				WouldBorrow(val1, val2),
				Parity(srcReg1.Data),
				AuxiliaryCarrySubtraction(val1, val2),
				srcReg1.Data == 0,
				srcReg1.Data < 0,
				WouldOverflow(val1, val2)
			);
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + cpu.GetRegister(GetRegister2Code(operand)).ToString();
		}

		public override string ToString() {
			return "SUB";
		}
	}
}
