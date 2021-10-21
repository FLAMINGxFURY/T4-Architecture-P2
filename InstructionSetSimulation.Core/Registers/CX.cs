using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionSetSimulation.Core.Registers
{
	public class CX : Register
	{
		public override ushort ID => 0x02;
		public override string ToString() {
			return "CX";
		}
	}
}
