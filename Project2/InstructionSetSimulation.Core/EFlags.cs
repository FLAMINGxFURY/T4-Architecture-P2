using System;

namespace InstructionSetSimulation.Core
{
    public class EFlags
    {
        private bool[] _flags = new bool[]
        {
            false,  // carry
            false,  // parity
            false,  // adjust
            false,  // zero
            false,  // sign
            false,  // overflow
        };

        public bool this[char flag]
        {
            get
            {
                flag = char.ToLower(flag);

                switch(flag)
                {
                    case 'c':
                        return _flags[0];
                    case 'p':
                        return _flags[1];
                    case 'a':
                        return _flags[2];
                    case 'z':
                        return _flags[3];
                    case 's':
                        return _flags[4];
                    case 'o':
                        return _flags[5];
                    default:
                        throw new ArgumentException($"{flag} is an invalid flag.");
                }
            }
            set
            {
                flag = char.ToLower(flag);

                switch (flag)
                {
                    case 'c':
                        _flags[0] = value;
                        break;
                    case 'p':
                        _flags[1] = value;
                        break;
                    case 'a':
                        _flags[2] = value;
                        break;
                    case 'z':
                        _flags[3] = value;
                        break;
                    case 's':
                        _flags[4] = value;
                        break;
                    case 'o':
                        _flags[5] = value;
                        break;
                    default:
                        throw new ArgumentException($"{flag} is an invalid flag.");
                }
            }
        }

        public bool this[int flag]
        {
            get
            {
                return _flags[flag];
            }
            set
            {
                _flags[flag] = value;
            }
        }

        public void SetAll(bool? carry, bool? parity, bool? adjust, bool? zero, bool? sign, bool? overflow)
        {
            if (carry.HasValue)
                _flags[0] = carry.Value;

            if (parity.HasValue)
                _flags[1] = parity.Value;

            if (adjust.HasValue)
                _flags[2] = adjust.Value;

            if (zero.HasValue)
                _flags[3] = zero.Value;

            if (sign.HasValue)
                _flags[4] = sign.Value;

            if (overflow.HasValue)
                _flags[5] = overflow.Value;
        }
    }
}
