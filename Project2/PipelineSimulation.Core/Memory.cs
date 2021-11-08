﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineSimulation.Core
{
    public class Memory
    {

        //TODO: We need an access table

        public static Memory Instance;
        public byte[] MemorySpace { get; set; } = new byte[1048576]; //1 MiB = 1024 KiB = 1024 * 1024 B

        public static Memory GetInstance()
        {
            // TODO: we need this to have a thread safe lock. 
            if (Instance == null)
                Instance = new Memory();
            return Instance;
        }

        //TODO: we need a method for requesting access to a memory location. If that memory location is busy, deny access and stall.

    }
}
