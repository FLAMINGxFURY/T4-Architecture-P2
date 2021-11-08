
namespace PipelineSimulation.Core.Instructions
{
	public class SUBI : Instruction
	{
		public override ushort OpCode => 0x08;
		public override int Cycles { get; set; } = 1;

		public SUBI(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			var register = cpu.GetRegister(GetRegister1Code(operand));

			var val1 = register.Data;
			var val2 = GetImmediate(operand);

			register.Data -= GetImmediate(operand);

			cpu.EFlags.SetAll
			(
				WouldBorrow(val1, val2),
				Parity(register.Data),
				AuxiliaryCarrySubtraction(val1, val2),
				register.Data == 0,
				register.Data < 0,
				WouldOverflow(val1, val2)
			);
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + GetImmediate(operand);
		}

		public override string ToString() {
			return "SUBI";
		}

	}
}
