namespace PipelineSimulation.Core.Instructions
{
    public class FSTM : Instruction
    {
        public override ushort OpCode => 0x11;
        public override int Cycles { get; set; } = 2;

        public FSTM(CPU cpuref) : base(cpuref)
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
            return "FSTM";
        }
    }
}