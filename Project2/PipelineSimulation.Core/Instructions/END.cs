using System;

namespace PipelineSimulation.Core.Instructions
{
	public class END : Instruction
	{
		public override ushort OpCode => 0x1F;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

		public END(CPU cpuref) : base(cpuref) {

		}

		// Returns 0 because void type
		public override ushort Execute(ushort operand) {
			Console.WriteLine("End Reached");
			cpu.End(); //TODO: The buffer needs to be handling this.
			return (ushort)(0);
		}

		public override string ToText(ushort operand) {
			return "";
		}

		public override string ToString() {
			return "END";
		}
	}
}
