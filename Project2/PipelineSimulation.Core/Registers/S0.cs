using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Registers
{
	public class S0: Register
	{
		public override ushort ID => 0x06;
		public override string ToString() {
			return "S0";
		}
	}
}
