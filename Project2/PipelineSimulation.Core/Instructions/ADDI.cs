
namespace PipelineSimulation.Core.Instructions
{
	public class ADDI : Instruction
	{
		public override ushort OpCode => 0x05;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => true;
        public override bool UsesRegister => false;

		public ADDI(CPU cpuref) : base(cpuref) {

		}

		// Returns the value to be stored in the destination register
		public override ushort Execute(ushort operand) {
			DestinationRegister = cpu.GetRegister(GetRegister1Code(operand));

			var val1 = DestinationRegister.Data;
			var val2 = GetImmediate(operand);

			ushort ret = (ushort)(val1 + val2);

			cpu.EFlags.SetAll
			(
				WouldCarry(val1, val2),
				Parity(DestinationRegister.Data),
				AuxiliaryCarryAddition(val1, val2),
				DestinationRegister.Data == 0,
				DestinationRegister.Data < 0,
				WouldOverflow(val1, val2)
			);

			return ret;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + GetImmediate(operand);
		}

		public override string ToString() {
			return "ADDI";
		}
	}
}
