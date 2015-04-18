﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Sandbox.Contracts;
using Sandbox.Environment.Configuration;

namespace Sandbox.Environment.Compiler
{
    abstract class Compiler : ICompiler
    {
        protected bool Used;
        protected CompilerArgs Args;

        //protected abstract string TargetDirectory { get; }

        //protected string PackageDirectory
        //{
        //    get { return Path.Combine(TargetDirectory, Args.PackageName); }
        //}

        //protected string TemporaryDirectory
        //{
        //    get { return Path.Combine(PackageDirectory, "tmp"); }
        //}

        public virtual void Compile(CompilerArgs args)
        {
            if (Used)
            {
                throw new InvalidOperationException("This compiler instance has already been used");
            }

            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            if (string.IsNullOrWhiteSpace(args.PackageName))
            {
                throw new ArgumentException("The PackageName property cannot be empty");
            }

            Args = args;

            if (Directory.Exists(EnvironmentPath.GetPackageDirectory(args.Platform, args.PackageName)))
            {
                throw new InvalidOperationException(string.Format("A package with name \"{0}\" already exists", Args.PackageName));
            }

            Used = true;
        }

        public virtual void CompileLibrary(CompilerArgs args)
        {
        }
    }
}
