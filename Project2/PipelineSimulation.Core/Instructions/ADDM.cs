
namespace PipelineSimulation.Core.Instructions
{
	public class ADDM : Instruction
	{
		public override ushort OpCode => 0x06;
        public override int Cycles => 1;

		public ADDM(CPU cpuref) : base(cpuref) {

		}
		public override void Execute(ushort operand) {
			var register = cpu.GetRegister(GetRegister1Code(operand));
			var addr = GetMemoryAddress();

			//get the 2 bytes from memory; force types to allow shift
			ushort byte1 = (ushort)(cpu.Memory[addr]);
			//next byte is 1 byte forward
			ushort byte2 = (ushort)(cpu.Memory[addr + 1]);

			//stored little endian, shift byte 2 because it is the upper order bits
			byte2 = (ushort)(byte2 << 2);

			//add together
			ushort data = (ushort)(byte1 + byte2);

			register.Data += data;

			cpu.EFlags.SetAll
			(
				WouldCarry(byte1, byte2),
				Parity(register.Data),
				AuxiliaryCarryAddition(byte1, byte2),
				register.Data == 0,
				register.Data < 0,
				WouldOverflow(byte1, byte2)
			);
		}

		public override string ToText(ushort operand) {
			return cpu.GetRegister(GetRegister1Code(operand)).ToString();
		}

		public override string ToString() {
			return "ADDM";
		}
	}
}
