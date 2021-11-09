
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

            if (DecodedInstruction != null)
            {
                DecodedInstruction.Execute(ReadMemory);
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