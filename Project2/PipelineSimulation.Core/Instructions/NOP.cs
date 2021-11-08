using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Instructions
{
	public class NOP : Instruction {
		public override ushort OpCode => 0x00;
		public override int Cycles { get; set; } = 1;

		public NOP(CPU cpuref) : base(cpuref) {

		}

		public override void Execute(ushort operand) {
			//Do nothing, explicitly :)
		}

		public override string ToText(ushort operand) {
			return "";
		}

		public override string ToString() {
			return "NOP";
		}
	}
}
