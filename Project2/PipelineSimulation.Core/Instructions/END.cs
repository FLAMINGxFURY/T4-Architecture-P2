using System;

namespace PipelineSimulation.Core.Instructions
{
	public class END : Instruction
	{
		public override ushort OpCode => 0x1F;
		public override int Cycles { get; set; } = 1;

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
