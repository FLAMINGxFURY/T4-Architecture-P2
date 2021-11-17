using System;
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
            if (ReadyInstructions.Count > 0)
            {
                var ins = ReadyInstructions.Dequeue();

                if (cpu.OTypeOpCodes.Contains(ins.OpCode))
                {
                    cpu.Buffers[4].DecodedInstructions.Enqueue(ins); // Goto memwrite
                }
                else if (cpu.RTpyeOpCodes.Contains(ins.OpCode))
                {
                    cpu.Buffers[5].DecodedInstructions.Enqueue(ins); // Goto regwrite
                }
                else
                {
                    cpu.CompletedInstructions.Add(ins);
                }
            }

            if (DecodedInstructions.Count > 0)
            {
                var ins = DecodedInstructions.Peek();

                // Check logical unit
                // TODO: Will this happen in each instructions execute?
                bool logicUnitAvailable;
                if (cpu.ALU.CurrentlyRunning == null && cpu.ALUOpCodes.Contains(ins.OpCode))
                    logicUnitAvailable = true;
                else if (cpu.ELU.CurrentlyRunning == null && cpu.ELUOpCodes.Contains(ins.OpCode))
                    logicUnitAvailable = true;
                else if (cpu.FPU.CurrentlyRunning == null && cpu.FPUOpCodes.Contains(ins.OpCode))
                    logicUnitAvailable = true;
                else
                    logicUnitAvailable = false;

                if (logicUnitAvailable)
                {
                    ins.Result = ins.Execute(ReadMemory);
                }
                else
                {
                    // Unit not available, stall until it is
                    cpu.Buffers[3].DecodedInstructions.Enqueue(new NOP(cpu));   // EXECUTE
                    cpu.Buffers[4].DecodedInstructions.Enqueue(new NOP(cpu));   // MEM WRITE
                    cpu.Buffers[5].DecodedInstructions.Enqueue(new NOP(cpu));   // REG WRITE
                }

                // Forwarding
                var destReg = ins.DestinationRegister;
                if (destReg != null)
                {
                    var dis = GetDependentInstructions(this, cpu.Buffers[2], cpu.Buffers[1]);

                    foreach (var d in dis)
                    {
                        d.ForwardBuffer = ins.Result;
                    }

                    List<Instruction> GetDependentInstructions(params CPUBuffer[] buffers)
                    {
                        var results = new List<Instruction>();

                        foreach (var buffer in buffers)
                        {
                            foreach (var i in buffer.DecodedInstructions)
                            {
                                // If the instruction uses a register this instruction writes to
                                if (i != ins && i.SourceRegister == destReg && i.SourceRegister != null) 
                                {
                                    results.Add(i);
                                }
                            }
                        }

                        return results;
                    }
                }

                // Finished with this instruction
                ReadyInstructions.Enqueue(DecodedInstructions.Dequeue());

                // Stall if this instruction takes more than one cycle
                if (ins.Cycles > 1)
                {
                    for (var i = 0; i < ins.Cycles; i++)
                    {
                        cpu.Buffers[3].DecodedInstructions.Enqueue(new NOP(cpu));
                    }
                }
            }
        }
    }
}