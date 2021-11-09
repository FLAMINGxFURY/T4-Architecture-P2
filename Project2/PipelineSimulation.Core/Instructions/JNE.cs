
namespace PipelineSimulation.Core.Instructions
{
	public class JNE : Instruction
	{
		public override ushort OpCode => 0x0D;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

		public JNE(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			var addToPC = GetImmediate(operand);

			if (!cpu.EFlags['z']) { //if comparison was NOT zero
				cpu.Rd.PC += addToPC;
			}
		}

		public override string ToText(ushort operand) {
			return GetImmediate(operand).ToString();
		}

		public override string ToString() {
			return "JNE";
		}
	}
}
