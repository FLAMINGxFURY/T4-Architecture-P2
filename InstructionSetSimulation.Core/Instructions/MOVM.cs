using System;

namespace InstructionSetSimulation.Core.Instructions
{
	public class MOVM : Instruction
	{
		public override ushort OpCode => 0x02;

		public MOVM(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			var reg = cpu.GetRegister(GetRegister1Code(operand));

			// get memory address
			var address = GetMemoryAddress();

			// Move short at address into register
			reg.Data = BitConverter.ToUInt16(new[] { cpu.Memory[address + 1], cpu.Memory[address] });
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString();
		}

		public override string ToString() {
			return "MOVM";
		}
	}
}
