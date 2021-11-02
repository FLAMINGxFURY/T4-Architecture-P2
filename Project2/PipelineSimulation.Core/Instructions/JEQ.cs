
namespace PipelineSimulation.Core.Instructions
{
	public class JEQ : Instruction
	{
		public override ushort OpCode => 0x0E;
        public override int Cycles => 1;

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
