namespace PipelineSimulation.Core.Instructions
{
    public class FDIV : Instruction
    {
        public override ushort OpCode => 0x1C;
        public override int Cycles { get; set; } = 11;

        public FDIV(CPU cpuref) : base(cpuref)
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
            return "FDIV";
        }
    }
}