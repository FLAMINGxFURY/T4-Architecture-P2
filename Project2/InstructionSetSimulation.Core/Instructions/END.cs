using System;

namespace InstructionSetSimulation.Core.Instructions
{
	public class END : Instruction
	{
		public override ushort OpCode => 0x1F;

		public END(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			Console.WriteLine("End Reached");
			cpu.End();
		}

		public override string ToText(ushort operand) {
			return "";
		}

		public override string ToString() {
			return "END";
		}
	}
}
