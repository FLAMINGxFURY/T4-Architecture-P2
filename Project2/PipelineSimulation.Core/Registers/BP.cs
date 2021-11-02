using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Registers
{
	public class BP : Register
	{
		public override ushort ID => 0x05;
		public override string ToString() {
			return "BP";
		}
	}
}
