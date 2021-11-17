namespace PipelineSimulation.Core.Instructions
{
    public class FMUL : Instruction
    {
        public override ushort OpCode => 0x19;
        public override int Cycles { get; set; } = 4;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FMUL(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            cpu.FPU.Mul();

            return 0;
        }

        public override string ToText(ushort operand)
        {
            return "FMUL";
        }

        public override string ToString()
        {
            return "FMUL";
        }
    }
}