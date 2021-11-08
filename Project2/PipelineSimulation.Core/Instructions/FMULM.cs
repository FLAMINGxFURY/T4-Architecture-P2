namespace PipelineSimulation.Core.Instructions
{
    public class FMULM : Instruction
    {
        public override ushort OpCode => 0x1B;
        public override int Cycles { get; set; } = 4;

        public FMULM(CPU cpuref) : base(cpuref)
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
            return "FMULM";
        }
    }
}