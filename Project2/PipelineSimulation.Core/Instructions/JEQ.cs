
namespace PipelineSimulation.Core.Instructions
{
	public class JEQ : Instruction
	{
		public override ushort OpCode => 0x0E;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

		public JEQ(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			var addToPC = GetImmediate(operand);

			if (cpu.EFlags['z']){ //if comparison was zero			
				cpu.Rd.PC += addToPC;
			}
		}

		public override string ToText(ushort operand) {
			return GetImmediate(operand).ToString();
		}

		public override string ToString() {
			return "JEQ";
		}
	}
}
