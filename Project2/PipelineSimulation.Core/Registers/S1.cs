using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Registers
{
	public class S1 : Register
	{
		public override ushort ID => 0x07;
		public override string ToString() {
			return "S1";
		}
	}
}
