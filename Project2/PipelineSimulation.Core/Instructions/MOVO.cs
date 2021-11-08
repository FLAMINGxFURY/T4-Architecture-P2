using System;

namespace PipelineSimulation.Core.Instructions
{
	public class MOVO : Instruction
	{
		public override ushort OpCode => 0x03;
		public override int Cycles { get; set; } = 1;

		public MOVO(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			// Get memory address from s0/s1
			var mem = GetMemoryAddress();

			// Get register
			var reg = cpu.GetRegister(GetRegister1Code(operand));

			// Convert contents of register to bytes
			var dataAsBytes = BitConverter.GetBytes(reg.Data);

			// Put contents of regsiter into memory stored little endian
			cpu.Memory.MemorySpace[mem] = dataAsBytes[1];
			cpu.Memory.MemorySpace[mem + 1] = dataAsBytes[0];
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString();
		}

		public override string ToString() {
			return "MOVO";
		}
	}
}
