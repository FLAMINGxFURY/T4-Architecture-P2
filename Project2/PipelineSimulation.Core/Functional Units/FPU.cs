using PipelineSimulation.Core.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core.Functional_Units {
	public class FPU : FunctionalUnit
	{
		//TODO: Registers and secial FPU functs


		public FPU()
		{
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.BaseType == typeof(Instruction))
				{
					var instruction = (Instruction)Activator.CreateInstance(type, this);
					if (instruction.OpCode > 0x0F && instruction.OpCode < 0x1E) //this should include ALL floating point instructions
						_operations.Add(instruction.OpCode, instruction);
				}
			}
		}
	}
}
