using System;

namespace PipelineSimulation.Core.Instructions
{
    public class FDIVM : Instruction
    {
        public override ushort OpCode => 0x1E;
        public override int Cycles { get; set; } = 11;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FDIVM(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            cpu.FPU.Div((Half)DataBuffer);

            return 0;
        }

        public override string ToText(ushort operand)
        {
            // TODO

            return string.Empty;
        }

        public override string ToString()
        {
            return "FDIVM";
        }
    }
}