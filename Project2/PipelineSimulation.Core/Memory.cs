using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core
{
    public class Memory
    {

        public static Memory Instance;
        private static readonly object InstanceLock = new object();
        public static byte[] MemorySpace { get; set; } = new byte[1048576]; //1 MiB = 1024 KiB = 1024 * 1024 B

        public static List<uint> LockedAddresses = new List<uint>();

        public static Memory GetInstance()
        {
            if (Instance == null)
            {
                lock (InstanceLock)
                {
                    if (Instance == null)
                        Instance = new Memory();
                }
            }
            return Instance;
        }

        //TODO: we need a method for requesting access to a memory location. If that memory location is busy, deny access and stall.

        // returns whether or not a memory address is locked
        public static bool IsLocked(uint addr) {
            if (LockedAddresses.Contains(addr)) return true;
            else return false;
		}

        // removes the locked state from the address
        public static void Unlock(uint addr) {
            if (LockedAddresses.Contains(addr)) LockedAddresses.Remove(addr);
        }

        // Requests data from a memory location
        // Throws AccessViolationException when location is locked
        public static ushort RequestMemoryFromAddr(uint addr) {
            if (IsLocked(addr)) throw new AccessViolationException("The memory location is currently being used by another instruction");
            else {

                //add address to lock list
                LockedAddresses.Add(addr);

                //get the 2 bytes from memory; force types to allow shift
                ushort byte1 = (ushort)(MemorySpace[addr]);
                //next byte is 1 byte forward
                ushort byte2 = (ushort)(MemorySpace[addr + 1]);

                //stored little endian, shift byte 2 because it is the upper order bits
                byte2 = (ushort)(byte2 << 2);

                //add together
                ushort data = (ushort)(byte1 + byte2);

                return data;
            }
		}

        // Stores data at a memory location
        // Throws AccessViolationException when location is locked
        public static void StoreMemoryAtAddr(ushort data, uint addr) {
            if (IsLocked(addr)) throw new AccessViolationException("The memory location is currently being used by another instruction");
            else {

                //add address to lock list
                LockedAddresses.Add(addr);

                //Get data as tuple of bytes
                var dataAsBytes = BitConverter.GetBytes(data);

                // Put contents of regsiter into memory stored little endian
                MemorySpace[addr] = dataAsBytes[1];
                MemorySpace[addr + 1] = dataAsBytes[0];
            }
        }

    }
}
