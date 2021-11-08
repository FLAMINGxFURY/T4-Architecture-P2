
namespace PipelineSimulation.Core.Instructions
{
	public class MOV : Instruction
	{
		public override ushort OpCode => 0x04;
		public override int Cycles { get; set; } = 1;

		public MOV(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			var dest = cpu.GetRegister(GetRegister1Code(operand));
			var src = cpu.GetRegister(GetRegister2Code(operand));

			dest.Data = src.Data;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + cpu.GetRegister(GetRegister2Code(operand)).ToString();
		}

		public override string ToString() {
			return "MOV";
		}
	}
}
