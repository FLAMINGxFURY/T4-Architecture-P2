using System;

namespace PipelineSimulation.Core.Functional_Units 
{
	public class FPU : FunctionalUnit
	{
		/// <summary>
		/// Refers to the top of the FPUStack. Is actually three bits in reality.
		/// </summary>
		public byte TOP { get; set; } = MAX_REG - 1;
		private Half?[] _FPUStack { get; set; } = new Half?[MAX_REG];
		private const int MAX_REG = 8;

		/// <summary>
		/// Pushes a value onto the FPU stack. If there's data that would be 
		/// overwritten, an exception will be thrown.
		/// </summary>
		/// <param name="data">The data to push.</param>
		public void Push(Half data)
		{
			TOP--;
			if (TOP < 0)
			{
				TOP = MAX_REG - 1;
			}

			if (_FPUStack[TOP].HasValue)
            {
				throw new Exception("Floating point exception. Attemped to overwite values on the FPU stack.");
            }

			_FPUStack[TOP] = data;		
        }

		/// <summary>
		/// Pops a value from the FPU stack. If there's no data to pop, an 
		/// exception will be thrown.
		/// </summary>
		public Half Pop()
        {
			if (!_FPUStack[TOP].HasValue)
            {
				throw new Exception("Floating point exception. Attempted to pop value that does not exist.");
			}

			var data = _FPUStack[TOP];
			_FPUStack[TOP] = null;

			TOP++;
			if (TOP > MAX_REG - 1)
			{
				TOP = 0;
			}

			return data.Value;
		}

		/// <summary>
		/// Reads the value on the stack at the position specified. Will return 
		/// null if no value is present. Index refers to the offset from TOP.
		/// For example, ST(0) (index = 0), means that it gets the value at TOP.
		/// ST(1) means that it gets TOP  + 1.
		/// </summary>
		public Half? Read(int index)
        {
			index = TOP + index;
			if (index > MAX_REG - 1)
            {
				index -= MAX_REG;
            }

			if (_FPUStack[index].HasValue)
            {
				return _FPUStack[index].Value;
            }
			else
            {
				return null;
            }
        }
    }
}
