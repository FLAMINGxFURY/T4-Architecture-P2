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
        protected override void DefineOPCodes()
        {
            for (ushort op = 0x00; op <= 0x04; op++)
            {
                opcodes.Add(op);
            }

            for (ushort op = 0x0B; op <= 0xE; op++)
            {
                opcodes.Add(op);
            }

            opcodes.Add(0x1F);
        }
    }
}
