
namespace PipelineSimulation.Core.Instructions
{
	public class ADD : Instruction
	{
		public override ushort OpCode => 0x07;
        public override int Cycles { get; set; } =  1;
        public override bool WritesToRegister => true;
        public override bool UsesRegister => true;

        public ADD(CPU cpuref) : base(cpuref) {

		}

		// Returns the value to be stored in the destination register
		public override ushort Execute(ushort operand) {
			// src1
			DestinationRegister = cpu.GetRegister(GetRegister1Code(operand));
			// src2
			var srcReg2 = cpu.GetRegister(GetRegister2Code(operand));

			var value1 = DestinationRegister.Data;

			var value2 = srcReg2.Data;

			ushort ret = (ushort)(value1 + value2);

			cpu.EFlags.SetAll
			(
				WouldCarry(value1, value2),
				Parity(DestinationRegister.Data),
				AuxiliaryCarryAddition(value1, value2),
				DestinationRegister.Data == 0,
				DestinationRegister.Data < 0,
				WouldOverflow(value1, value2)
			);

			return ret;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + cpu.GetRegister(GetRegister2Code(operand)).ToString();
		}

		public override string ToString() {
			return "ADD";
		}
	}
}
