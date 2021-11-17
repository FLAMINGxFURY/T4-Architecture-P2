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
		public Half Read(int index)
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
				return (Half)0;
            }
        }

		/// <summary>
		/// Adds the two values at the specified indeces together. The value
		/// is temporarily stored in ST(Y), the stack is then popped, so it
		/// may be found in ST(X).
		/// </summary>
		/// <param name="index1">X or the first index.</param>
		/// <param name="index2">Y or the second index.</param>
        public void Add(int index1 = 0, int index2 = 1)
        {
            var num1 = Read(index1);
            var num2 = Read(index2);

            var result = (Half)((float)num1 + (float)num2);

			Write(index2, result);

            Pop();
        }

		/// <summary>
		/// Adds the specified value to ST(0).
		/// </summary>
        public void Add(Half value)
        {
            var num1 = Read(0);

            var result = (Half)((float)num1 + (float)value);

            Write(0, result);
        }

        /// <summary>
        /// Subtracts the two values at the specified indeces together. The value
        /// is temporarily stored in ST(Y), the stack is then popped, so it
        /// may be found in ST(X).
        /// </summary>
        /// <param name="index1">X or the first index.</param>
        /// <param name="index2">Y or the second index.</param>
        public void Sub(int index1 = 0, int index2 = 1)
        {
            var num1 = Read(index1);
            var num2 = Read(index2);

            var result = (Half)((float)num1 - (float)num2);

            Write(index2, result);

            Pop();
        }

        /// <summary>
        /// Subtracts the specified value to ST(0).
        /// </summary>
        public void Sub(Half value)
        {
            var num1 = Read(0);

            var result = (Half)((float)num1 - (float)value);

            Write(0, result);
        }

        /// <summary>
        /// Multiplies the two values at the specified indeces together. The value
        /// is temporarily stored in ST(Y), the stack is then popped, so it
        /// may be found in ST(X).
        /// </summary>
        /// <param name="index1">X or the first index.</param>
        /// <param name="index2">Y or the second index.</param>
        public void Mul(int index1 = 0, int index2 = 1)
        {
            var num1 = Read(index1);
            var num2 = Read(index2);

            var result = (Half)((float)num1 * (float)num2);

            Write(index2, result);

            Pop();
        }

        /// <summary>
        /// Multiplies the specified value to ST(0).
        /// </summary>
        public void Mul(Half value)
        {
            var num1 = Read(0);

            var result = (Half)((float)num1 * (float)value);

            Write(0, result);
        }

        /// <summary>
        /// Divides the two values at the specified indeces together. The value
        /// is temporarily stored in ST(Y), the stack is then popped, so it
        /// may be found in ST(X).
        /// </summary>
        /// <param name="index1">X or the first index.</param>
        /// <param name="index2">Y or the second index.</param>
        public void Div(int index1 = 0, int index2 = 1)
        {
            var num1 = Read(index1);
            var num2 = Read(index2);

            var result = (Half)((float)num1 / (float)num2);

            Write(index2, result);

            Pop();
        }

        /// <summary>
        /// Divides the specified value to ST(0).
        /// </summary>
        public void Div(Half value)
        {
            var num1 = Read(0);

            var result = (Half)((float)num1 / (float)value);

            Write(0, result);
        }

        private void Write(int index, Half value)
        {
            index = TOP + index;
            if (index > MAX_REG - 1)
            {
                index -= MAX_REG;
            }

            _FPUStack[index] = value;
        }
	}
}
