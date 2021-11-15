using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Functional_Units {
	public abstract class FunctionalUnit {

		// Currently running instruction
		public Instruction CurrentlyRunning;

		// TODO: No arg constructor
		public FunctionalUnit() 
		{

		}
	}
}
