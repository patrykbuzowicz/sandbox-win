﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Contracts;

namespace Sandbox.Environment.Compiler
{
    class Manager
    {
        public static ICompiler GetCompiler(PlatformType type)
        {
            switch (type)
            {
                case PlatformType.Native:
                    return new NativeCompiler();
            }

            throw new NotImplementedException("No compiler implementation for " + type);
        }
    }
}
