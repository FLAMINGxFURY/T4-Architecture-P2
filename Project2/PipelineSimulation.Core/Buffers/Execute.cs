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

                if (ins.OpCode == 0b11111) { //END
                    cpu.stopFetch = true;
                    DecodedInstructions.Dequeue();
                    return;
				}

                if (ins.Cycles > 1) ins.Cycles--;

                else {

                    // Execute
                    ins.Result = ins.Execute(ins.Operand);

                    // Forwarding
                    var destReg = ins.DestinationRegister;
                    if (destReg != null) {
                        var dis = GetDependentInstructions(this, cpu.Buffers[2], cpu.Buffers[1]);

                        foreach (var d in dis) {
                            d.ForwardBuffer = ins.Result;
                        }

                        List<Instruction> GetDependentInstructions(params CPUBuffer[] buffers) {
                            var results = new List<Instruction>();

                            foreach (var buffer in buffers) {
                                foreach (var i in buffer.DecodedInstructions) {
                                    // If the instruction uses a register this instruction writes to
                                    if (i != ins && i.SourceRegister == destReg && i.SourceRegister != null) {
                                        results.Add(i);
                                    }
                                }
                            }

                            return results;
                        }
                    }

                    // Finished with this instruction
                    ReadyInstructions.Enqueue(DecodedInstructions.Dequeue());
                }
                
            }
        }
    }
}