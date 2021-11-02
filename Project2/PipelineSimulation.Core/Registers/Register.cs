
namespace PipelineSimulation.Core.Registers 
{
	public abstract class Register 
	{
		public abstract ushort ID { get; }
		public ushort Data { get; set; }

		public abstract override string ToString();
	}
}
