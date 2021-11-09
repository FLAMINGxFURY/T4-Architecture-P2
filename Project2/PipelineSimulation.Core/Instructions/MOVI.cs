﻿
namespace PipelineSimulation.Core.Instructions
{
	public class MOVI : Instruction
	{
		public override ushort OpCode => 0x01;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => true;
        public override bool UsesRegister => false;

		public MOVI(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			var reg = cpu.GetRegister(GetRegister1Code(operand));
			var data = GetImmediate(operand);

			reg.Data = data;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString() + ", " + GetImmediate(operand);
		}

		public override string ToString() {
			return "MOVI";
		}
	}
}
