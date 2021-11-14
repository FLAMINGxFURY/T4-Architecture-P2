
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

		// Returns 0 because void type
		public override ushort Execute(ushort operand) {
			var addToPC = (short)GetImmediate(operand);
			addToPC -= 1; //one instruction behind

			if (cpu.EFlags['z']){ //if comparison was zero			
				if(addToPC < 0) {
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
			return "JEQ";
		}
	}
}
