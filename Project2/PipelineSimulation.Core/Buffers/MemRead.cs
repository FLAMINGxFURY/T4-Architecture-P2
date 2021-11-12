
namespace PipelineSimulation.Core.Buffers
{
    public class MemRead : CPUBuffer
    {
        public override int ID => 2;

        public override void PerformBehavior(CPU cpu)
        {
            // Mem read
            if (DecodedInstruction != null && DecodedInstruction.GetType().Name.EndsWith("M"))
            {
                var remainder = (ushort)(0b_0000_0111_1111_1111 & WorkingInstruction);
                var register = cpu.GetRegister(DecodedInstruction.GetRegister1Code(remainder));

                var valueInMemory = cpu.Memory.MemorySpace[register.Data];
            }

            // TODO: It is implied that the data being grabbed here is from the S0/S1 pair. 

            // Send value to functional unit
            // TODO

            // TODO: Handle data races
        }
    }
}