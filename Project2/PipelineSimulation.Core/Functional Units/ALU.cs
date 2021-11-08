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
        protected override void DefineOPCodes()
        {
            for (ushort op = 0x05; op <= 0x0A; op++)
            {
                opcodes.Add(op);
            }
        }
    }				
}
