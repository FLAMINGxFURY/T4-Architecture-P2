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
            return "FLDR";
        }
    }
}