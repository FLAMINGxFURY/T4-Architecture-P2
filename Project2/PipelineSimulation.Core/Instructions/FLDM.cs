namespace PipelineSimulation.Core.Instructions
{
    public class FLDM : Instruction
    {
        public override ushort OpCode => 0x0F;
        public override int Cycles => 2;

        public FLDM(CPU cpuref) : base(cpuref)
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
            return "FLDM";
        }
    }
}