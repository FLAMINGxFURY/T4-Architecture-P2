
namespace PipelineSimulation.Core.Instructions
{
	public class CMP : Instruction
	{
		public override ushort OpCode => 0x0B;
		public override int Cycles { get; set; } = 1;

		public CMP(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			// TODO: This should set every flag, but ZF and CF are good for now

			var reg1c = GetRegister1Code(operand);
			var reg2c = GetRegister2Code(operand);

			var reg1 = cpu.GetRegister(reg1c);
			var reg2 = cpu.GetRegister(reg2c);

			var result = reg1.Data - reg2.Data;

			cpu.EFlags.SetAll
			(
				WouldBorrow(reg1.Data, reg2.Data),
				Parity((ushort)result),
				null,
				result == 0,
				result < 0,
				WouldOverflow(reg1.Data, reg2.Data)
			);
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + cpu.GetRegister(GetRegister2Code(operand)).ToString();
		}

		public override string ToString() {
			return "CMP";
		}
	}
}
