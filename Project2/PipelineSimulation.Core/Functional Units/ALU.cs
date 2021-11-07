using PipelineSimulation.Core.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Functional_Units {
	class ALU : FunctionalUnit
	{
		public ALU()
        {
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.BaseType == typeof(Instruction))
				{
					var instruction = (Instruction)Activator.CreateInstance(type, this);
					if (instruction.OpCode > 0x05 && instruction.OpCode < 0x0A) //this should be all of our integer ADD and SUB instructions
						_operations.Add(instruction.OpCode, instruction);
				}
			}
		}

				
}
}
