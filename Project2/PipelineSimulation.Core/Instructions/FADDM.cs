﻿namespace PipelineSimulation.Core.Instructions
{
    public class FADDM : Instruction
    {
        public override ushort OpCode => 0x15;
        public override int Cycles { get; set; } = 4;

        public FADDM(CPU cpuref) : base(cpuref)
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
            return "FADDM";
        }
    }
}