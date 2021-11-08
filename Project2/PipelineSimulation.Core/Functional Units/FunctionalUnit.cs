using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Functional_Units {
	public abstract class FunctionalUnit {

		// List of opcodes belonging to the Logic Unit. This list should be instantiated by the inheriting class, 
		// not this one.
		public HashSet<ushort> opcodes = new HashSet<ushort>();

		// Currently running instruction
		public Instruction CurrentlyRunning;

		// TODO: No arg constructor
		public FunctionalUnit() 
		{
			DefineOPCodes();
		}

		/// <summary>
		/// Gets called when instance is created. Should implement behavior 
		/// that populates the opcode hashset with opcodes that apply to the
		/// unit.
		/// </summary>
		protected abstract void DefineOPCodes();
	}
}
