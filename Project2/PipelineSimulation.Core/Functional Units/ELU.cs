using PipelineSimulation.Core.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Functional_Units {
	class ELU : FunctionalUnit
	{
		public ELU()
		{
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.BaseType == typeof(Instruction))
				{
					var instruction = (Instruction)Activator.CreateInstance(type, this);
					if (instruction.OpCode == 0x00) //only has NOP right now, still need to add other execution logic related instructions
						_operations.Add(instruction.OpCode, instruction);
				}
			}
		}
	}
}
