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

            cpu.Rd.fileStr = @"..\..\..\..\ConditionalLogic.bin";
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
                    if (buffer.ReadyInstructions.Count > 0)
                    {
                        Console.Write($"{buffer.GetType().Name}: {buffer.ReadyInstructions.Peek()}");
                    }
                    else if (buffer.DecodedInstructions.Count > 0)
                    {
                        Console.Write($"{buffer.GetType().Name}: {buffer.DecodedInstructions.Peek()}");
                    }
                    else if (buffer.FetchedInstructions != null && buffer.FetchedInstructions.Count > 0)
                    {
                        Console.Write($"{buffer.GetType().Name}: {buffer.FetchedInstructions.Peek()}");
                    }
                    else 
                    {
                        Console.Write($"{buffer.GetType().Name}: [ ]");
                    }

                    Console.WriteLine();
                }

                Thread.Sleep(1000);
            }
        }
    }
}
