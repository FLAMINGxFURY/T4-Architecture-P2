
using PipelineSimulation.Core.Functional_Units;
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public class Execute : CPUBuffer
    {
        public override int ID => 3;

        public override void PerformBehavior(CPU cpu)
        {
            // Check for dependency
            if (DecodedInstruction.WritesToRegister)
            {
                // If an instruction will write to a register
                // and another instruction will try to read from that same register
                // there's a dependency

                CheckReadWriteDependency(cpu.Buffers[2].DecodedInstruction);
                CheckReadWriteDependency(cpu.Buffers[1].DecodedInstruction);
            }

            // Check logical unit
			// TODO
            bool LogicUnitAvailable = false;
            FunctionalUnit unitUtilized = null;
            foreach (FunctionalUnit unit)
            {
                if (unit.opcodes.Contains(DecodedInstruction.OpCode))
                {
                    if (unit.CurrentlyRunning != null)
                        LogicUnitAvailable = false;
                    else
                        LogicUnitAvailable = true;

                    unitUtilized = unit;

                    break;
                }
            }

            if (DecodedInstruction != null && LogicUnitAvailable)
            {
                DecodedInstruction.Execute(ReadMemory);
                unitUtilized.instructions.Dequeue();
            }

            // Forwarding
            // TODO
        }

        private void CheckReadWriteDependency(Instruction otherInstruction)
        {
            if (otherInstruction != null && otherInstruction.UsesRegister)
            {
                var writeReg = DecodedInstruction.GetRegister1Code(WorkingInstruction);
                var readReg = otherInstruction.GetRegister2Code(WorkingInstruction);

                if (writeReg == readReg)
                {
                    DecodedInstruction.WaitList.Add(otherInstruction);
                    otherInstruction.WaitingFor = DecodedInstruction;
                }
            }
        }
    }
}