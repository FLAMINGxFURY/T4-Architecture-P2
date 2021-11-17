namespace PipelineSimulation.Core.Instructions
{
    public class FADD : Instruction
    {
        public override ushort OpCode => 0x13;
        public override int Cycles { get; set; } = 4;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FADD(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            cpu.FPU.Add();

            return 0;
        }

        public override string ToText(ushort operand)
        {
            return "FADD";
        }

        public override string ToString()
        {
            return "FADD";
        }
    }
}