using System.Collections.Generic;
using PipelineSimulation.Core.Instructions;

namespace PipelineSimulation.Core.Buffers
{
    public class Execute : CPUBuffer
    {
        public override int ID => 3;

        public Dictionary<ushort, Instruction> usedRegisters;

        public Execute(CPU cpuref) : base(cpuref) {
            usedRegisters = new Dictionary<ushort, Instruction>();
        }

        public override void PerformBehavior(CPU cpu)
        {
            if (DecodedInstructions.Count == 0)
                return;

            var ins = DecodedInstructions.Peek();

            // Check for dependency
            if (ins.WritesToRegister)
            {
                // If an instruction will write to a register
                // and another instruction will try to read from that same register
                // there's a dependency

                CheckReadWriteDependency(ins, cpu.Buffers[2].DecodedInstructions.Peek());
                CheckReadWriteDependency(ins, cpu.Buffers[1].DecodedInstructions.Peek());
            }

            // Check logical unit
            // TODO: Will this happen in each instructions execute?

            ins.Result = ins.Execute(ReadMemory);

            // Forwarding
            // TODO

            if (cpu.OTypeOpCodes.Contains(ins.OpCode))
            {
                cpu.Buffers[4].DecodedInstructions.Enqueue(DecodedInstructions.Dequeue()); // Goto memwrite
            }
            else if (cpu.RTpyeOpCodes.Contains(ins.OpCode))
            {
                cpu.Buffers[5].DecodedInstructions.Enqueue(DecodedInstructions.Dequeue()); // Goto regwrite
            }
            else
            {
                cpu.CompletedInstructions.Add(DecodedInstructions.Dequeue());
            }
        }

        private void CheckReadWriteDependency(Instruction currentInstruction, Instruction otherInstruction)
        {
            if (otherInstruction != null && otherInstruction.UsesRegister)
            {
                var writeReg = currentInstruction.GetRegister1Code(WorkingInstruction);
                var readReg = otherInstruction.GetRegister2Code(WorkingInstruction);

                if (writeReg == readReg)
                {
                    currentInstruction.WaitList.Add(otherInstruction);
                    otherInstruction.WaitingFor = currentInstruction;
                }
            }
        }
    }
}