
namespace InstructionSetSimulation.Core.Instructions
{
	public class JMP : Instruction
	{
		public override ushort OpCode => 0x0C;

		public JMP(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			var addToPC = GetImmediate(operand);
			cpu.Rd.PC += addToPC;
		}

		public override string ToText(ushort operand) {
			return GetImmediate(operand).ToString();
		}

		public override string ToString() {
			return "JMP";
		}
	}
}
