namespace PipelineSimulation.Core.Instructions
{
    public class FDIVR : Instruction
    {
        public override ushort OpCode => 0x1D;
        public override int Cycles => 11;

        public FDIVR(CPU cpuref) : base(cpuref)
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
            return "FDIVR";
        }
    }
}