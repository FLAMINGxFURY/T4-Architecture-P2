using System;
using System.Collections.Immutable;
using System.Threading;
using PipelineSimulation.Core;

namespace PipelineSimulation.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cpu = new CPU();

            cpu.Rd.fileStr = "../../../../../Example 1.bin";
            cpu.Rd.OpenFile();

            while (!cpu.endReached)
            {
                cpu.NextClockCycle();
                Console.WriteLine();
                Console.WriteLine($"Clock Cycle: {cpu.CurrentClockCycle}");
                Console.WriteLine();

                for (var i = 0; i < cpu.Buffers.Count; i++)
                {
                    var buffer = cpu.Buffers[i];
                    Console.Write($"{buffer.GetType().Name}: {buffer.WorkingInstruction}");
                    if (buffer.DecodedInstruction != null && buffer.DecodedInstruction.WaitingFor != null)
                    {
                        Console.Write($" | {buffer.DecodedInstruction} <- {buffer.DecodedInstruction.WaitingFor}");
                    }

                    Console.WriteLine();
                }

                Thread.Sleep(1000);
            }
        }
    }
}
