namespace PipelineSimulation.Core.Instructions
{
    public class FSUB : Instruction
    {
        public override ushort OpCode => 0x16;
        public override int Cycles { get; set; } = 4;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FSUB(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            cpu.FPU.Sub();

            return 0;
        }

        public override string ToText(ushort operand)
        {
            return "FSUB";
        }

        public override string ToString()
        {
            return "FSUB";
        }
    }
}