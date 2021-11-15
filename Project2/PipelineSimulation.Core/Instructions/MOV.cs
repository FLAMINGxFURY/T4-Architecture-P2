
namespace PipelineSimulation.Core.Instructions
{
	public class MOV : Instruction
	{
		public override ushort OpCode => 0x04;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => true;
        public override bool UsesRegister => false;

		public MOV(CPU cpuref) : base(cpuref) {

		}

		// Returns the value to be stored in the destination register
		public override ushort Execute(ushort operand) {
			DestinationRegister = cpu.GetRegister(GetRegister1Code(operand));
			var src = cpu.GetRegister(GetRegister2Code(operand));

			ushort ret = src.Data;
			return ret;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + cpu.GetRegister(GetRegister2Code(operand)).ToString();
		}

		public override string ToString() {
			return "MOV";
		}
	}
}
