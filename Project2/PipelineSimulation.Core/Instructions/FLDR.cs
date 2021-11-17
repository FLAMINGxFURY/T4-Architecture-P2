using System;

namespace PipelineSimulation.Core.Instructions
{
    public class FLDR : Instruction
    {
        public override ushort OpCode => 0x10;
        public override int Cycles { get; set; } = 2;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FLDR(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            var reg = SourceRegister;

            cpu.FPU.Push((Half)reg.Data);

            return 0;
        }

        public override string ToText(ushort operand)
        {
            return $"FLDR {SourceRegister}";
        }

        public override string ToString()
        {
            return "FLDR";
        }
    }
}