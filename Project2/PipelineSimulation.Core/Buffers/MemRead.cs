
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
                var regCode = (ushort) (WorkingInstruction >> 8);
                var register = cpu.GetRegister(regCode);

                var valueInMemory = cpu.Memory.MemorySpace[register.Data];
            }

            // Send value to functional unit
            // TODO

            // TODO: Handle data races
        }
    }
}