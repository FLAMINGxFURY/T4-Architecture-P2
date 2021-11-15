using System;

namespace PipelineSimulation.Core.Instructions
{
	public class MOVO : Instruction
	{
		public override ushort OpCode => 0x03;
		public override int Cycles { get; set; } = 1;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => true;

		public MOVO(CPU cpuref) : base(cpuref) {

		}

		// Returns 0 because void type
		public override ushort Execute(ushort operand) {
			// Get memory address from s0/s1
			DestinationAddr = GetMemoryAddress();

			// Get register
			var reg = cpu.GetRegister(GetRegister1Code(operand));
			
			return reg.Data;
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString();
		}

		public override string ToString() {
			return "MOVO";
		}
	}
}
