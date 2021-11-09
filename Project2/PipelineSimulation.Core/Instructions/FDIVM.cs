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
            return "FDIVM";
        }
    }
}