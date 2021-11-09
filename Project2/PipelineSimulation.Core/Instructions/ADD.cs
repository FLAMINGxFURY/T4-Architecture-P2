
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

		public override void Execute(ushort operand) {
			// src1
			var srcReg1 = cpu.GetRegister(GetRegister1Code(operand));
			// src2
			var srcReg2 = cpu.GetRegister(GetRegister2Code(operand));

			var value1 = srcReg1.Data;

			var value2 = srcReg2.Data;

			srcReg1.Data = (ushort)(value1 + value2);

			cpu.EFlags.SetAll
			(
				WouldCarry(value1, value2),
				Parity(srcReg1.Data),
				AuxiliaryCarryAddition(value1, value2),
				srcReg1.Data == 0,
				srcReg1.Data < 0,
				WouldOverflow(value1, value2)
			);
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + cpu.GetRegister(GetRegister2Code(operand)).ToString();
		}

		public override string ToString() {
			return "ADD";
		}
	}
}
