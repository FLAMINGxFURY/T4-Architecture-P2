namespace PipelineSimulation.Core.Instructions
{
    public class FADDR : Instruction
    {
        public override ushort OpCode => 0x14;
        public override int Cycles => 4;

        public FADDR(CPU cpuref) : base(cpuref)
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
            return "FADDR";
        }
    }
}