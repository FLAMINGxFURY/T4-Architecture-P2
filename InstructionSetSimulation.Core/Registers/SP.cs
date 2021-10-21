using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionSetSimulation.Core.Registers
{
	public class SP : Register
	{
		public override ushort ID => 0x04;
		public override string ToString() {
			return "SP";
		}
	}
}
