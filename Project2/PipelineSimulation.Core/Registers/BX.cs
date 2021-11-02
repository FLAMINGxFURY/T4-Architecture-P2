using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Registers 
{
	public class BX : Register
	{
		public override ushort ID => 0x01;
		public override string ToString() {
			return "BX";
		}
	}
}
