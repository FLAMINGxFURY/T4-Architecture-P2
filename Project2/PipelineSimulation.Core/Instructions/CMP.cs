
namespace PipelineSimulation.Core.Instructions
{
	public class CMP : Instruction
	{
		public override ushort OpCode => 0x0B;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

		public CMP(CPU cpuref) : base(cpuref) {

		}

		// Returns 0 because void type
		public override ushort Execute(ushort operand) {
			// TODO: This should set every flag, but ZF and CF are good for now

			var result = DestinationRegister.Data - SourceRegister.Data;

			cpu.EFlags.SetAll
			(
				WouldBorrow(DestinationRegister.Data, SourceRegister.Data),
				Parity((ushort)result),
				null,
				result == 0,
				result < 0,
				WouldOverflow(DestinationRegister.Data, SourceRegister.Data)
			);

			return (ushort)(0);
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + cpu.GetRegister(GetRegister2Code(operand)).ToString();
		}

		public override string ToString() {
			return "CMP";
		}
	}
}
