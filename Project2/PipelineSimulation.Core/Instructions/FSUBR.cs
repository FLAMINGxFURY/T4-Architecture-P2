namespace PipelineSimulation.Core.Instructions
{
    public class FSUBR : Instruction
    {
        public override ushort OpCode => 0x17;
        public override int Cycles => 4;

        public FSUBR(CPU cpuref) : base(cpuref)
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
            return "FSUBR";
        }
    }
}