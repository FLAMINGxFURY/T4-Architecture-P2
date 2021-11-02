namespace PipelineSimulation.Core.Instructions
{
    public class FSUBM : Instruction
    {
        public override ushort OpCode => 0x18;
        public override int Cycles => 4;

        public FSUBM(CPU cpuref) : base(cpuref)
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
            return "FSUBM";
        }
    }
}