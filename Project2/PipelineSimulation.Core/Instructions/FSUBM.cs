using System;

namespace PipelineSimulation.Core.Instructions
{
    public class FSUBM : Instruction
    {
        public override ushort OpCode => 0x18;
        public override int Cycles { get; set; } = 4;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FSUBM(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            cpu.FPU.Sub((Half)DataBuffer);

            return 0;
        }

        public override string ToText(ushort operand)
        {
            // TODO

            return string.Empty;
        }

        public override string ToString()
        {
            return "FSUBM";
        }
    }
}