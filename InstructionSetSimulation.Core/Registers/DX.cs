using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionSetSimulation.Core.Registers
{
	public class DX : Register
	{
		public override ushort ID => 0x03;
		public override string ToString() {
			return "DX";
		}
	}
}
