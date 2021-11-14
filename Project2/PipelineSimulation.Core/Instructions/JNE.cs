
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

		// Returns 0 because void type
		public override ushort Execute(ushort operand) {
			var addToPC = (short)GetImmediate(operand);

			if (!cpu.EFlags['z']) { //if comparison was NOT zero
				if (addToPC < 0) {
					//convert to positive version
					addToPC -= (short)(2 * addToPC);
					//subtract
					cpu.Rd.PC -= (ushort)(addToPC);
				}
				else cpu.Rd.PC += (ushort)(addToPC);
			}

			return (ushort)(0);
		}

		public override string ToText(ushort operand) {
			return GetImmediate(operand).ToString();
		}

		public override string ToString() {
			return "JNE";
		}
	}
}
