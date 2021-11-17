using System;

namespace PipelineSimulation.Core.Instructions
{
    public class FADDM : Instruction
    {
        public override ushort OpCode => 0x15;
        public override int Cycles { get; set; } = 4;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FADDM(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            cpu.FPU.Add((Half)DataBuffer);

            return 0;
        }

        public override string ToText(ushort operand)
        {
            return $"FADD {DataBuffer}";
        }

        public override string ToString()
        {
            return "FADDM";
        }
    }
}