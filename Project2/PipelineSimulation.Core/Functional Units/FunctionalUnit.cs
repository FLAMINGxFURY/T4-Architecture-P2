﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Functional_Units {
	public abstract class FunctionalUnit {

		// These need to be types not instances, maybe ENUM instead of Instruction I don't recall 
		// Exactly what we said our implementation plan was

		// List of instructions belonging to the functional unit
		public List<Instruction> Instructions;
		//used a dictionary since thats what we used previously, but left the list here in case you all had different plans
		public Dictionary<ushort, Instruction> _operations = new Dictionary<ushort, Instruction>();

		// Currently running instruction
		public Instruction CurrentlyRunning;

		// TODO: No arg constructor
		public FunctionalUnit() {

		}

		// TODO: Do we need any abstract funtions?

	}
}