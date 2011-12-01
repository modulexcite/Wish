﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace Wish.Commands.Runner
{
    public class Powershell : IRunner
    {
        private readonly Runspace _runspace;
        private Pipeline _pipeline;

        public Powershell(int id)
        {
            _runspace = RunspaceSingleton.GetInstance(id);
        }

        public string Execute(RunnerArgs args)
        {
            _pipeline = _runspace.CreatePipeline();
            _pipeline.Commands.AddScript(args.Script);
            _pipeline.Commands.Add("Out-String");
            Collection<PSObject> psObjects;
            try
            {
                psObjects = _pipeline.Invoke();
            } catch(Exception e)
            {
                return e.Message;
            }
            if(_pipeline.Error.Count > 0)
            {
                var firstOrDefault = _pipeline.Error.ReadToEnd().FirstOrDefault();
                if (firstOrDefault != null)
                {
                    return firstOrDefault.ToString();
                }
            }
            if(_pipeline.Output.Count > 0)
            {
                var firstOrDefault = _pipeline.Output.ReadToEnd().FirstOrDefault();
                if (firstOrDefault != null)
                {
                    return firstOrDefault.ToString();
                }
            }
            var sb = new StringBuilder();
            foreach (var psObject in psObjects)
            {
                sb.AppendLine(psObject.ToString());
            }
            return sb.ToString();
        }

        public string WorkingDirectory
        {
            get
            {
                var pipeline = _runspace.CreatePipeline();
                pipeline.Commands.AddScript("pwd");
                var results = pipeline.Invoke();
// ReSharper disable PossibleNullReferenceException
                return results.FirstOrDefault().ToString();
// ReSharper restore PossibleNullReferenceException
            }
        }

        public override string ToString()
        {
            return "[P]";
        }
    }
}
