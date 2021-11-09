﻿namespace PipelineSimulation.Core.Instructions
{
    public class FMULR : Instruction
    {
        public override ushort OpCode => 0x1A;
        public override int Cycles { get; set; } = 4;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FMULR(CPU cpuref) : base(cpuref)
        {

        }

        public override void Execute(ushort operand)
        {
            // TODO
        }

        public override string ToText(ushort operand)
        {
            // TODO

            return string.Empty;
        }

        public override string ToString()
        {
            return "FMULR";
        }
    }
}