using System;

namespace PipelineSimulation.Core.Instructions
{
    public class FLDM : Instruction
    {
        public override ushort OpCode => 0x0F;
        public override int Cycles { get; set; } = 2;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FLDM(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            cpu.FPU.Push((Half)DataBuffer);

            return 0;
        }

        public override string ToText(ushort operand)
        {
            return $"FLDM {DataBuffer}";
        }

        public override string ToString()
        {
            return "FLDM";
        }
    }
}