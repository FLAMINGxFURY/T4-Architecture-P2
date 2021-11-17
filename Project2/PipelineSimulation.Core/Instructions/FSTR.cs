namespace PipelineSimulation.Core.Instructions
{
    public class FSTR : Instruction
    {
        public override ushort OpCode => 0x12;
        public override int Cycles { get; set; } = 2;
        public override bool WritesToRegister => false;
        public override bool UsesRegister => false;

        public FSTR(CPU cpuref) : base(cpuref)
        {

        }

        public override ushort Execute(ushort operand)
        {
            return (ushort)cpu.FPU.Pop();
        }

        public override string ToText(ushort operand)
        {
            return "FSTR";
        }

        public override string ToString()
        {
            return "FSTR";
        }
    }
}