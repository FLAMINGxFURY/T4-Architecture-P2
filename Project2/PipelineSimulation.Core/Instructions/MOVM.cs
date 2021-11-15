using System;

namespace PipelineSimulation.Core.Instructions
{
	public class MOVM : Instruction
	{
        public override ushort OpCode => 0x02;
        public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => true;
        public override bool UsesRegister => false;

		public MOVM(CPU cpuref) : base(cpuref) {

		}

		// Returns the value to be stored in the destination register
		public override ushort Execute(ushort operand) {
			DestinationRegister = cpu.GetRegister(GetRegister1Code(operand));

			return DataBuffer;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString();
		}

		public override string ToString() {
			return "MOVM";
		}
	}
}
