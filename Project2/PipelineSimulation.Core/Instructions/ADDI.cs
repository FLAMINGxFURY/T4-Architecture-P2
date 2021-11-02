
namespace PipelineSimulation.Core.Instructions
{
	public class ADDI : Instruction
	{
		public override ushort OpCode => 0x05;
        public override int Cycles => 1;

		public ADDI(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			var register = cpu.GetRegister(GetRegister1Code(operand));

			var val1 = register.Data;
			var val2 = GetImmediate(operand);

			register.Data += val2;

			cpu.EFlags.SetAll
			(
				WouldCarry(val1, val2),
				Parity(register.Data),
				AuxiliaryCarryAddition(val1, val2),
				register.Data == 0,
				register.Data < 0,
				WouldOverflow(val1, val2)
			);
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + GetImmediate(operand);
		}

		public override string ToString() {
			return "ADDI";
		}
	}
}
