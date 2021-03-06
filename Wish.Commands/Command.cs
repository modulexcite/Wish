﻿using System;
using System.Collections.Generic;
using System.Linq;
using Wish.Commands.Runner;
using Wish.Common;

namespace Wish.Commands
{
    public class Command : ICommand
    {
        private readonly IRunner _runner;
        public CommandLine CommandLine { get; set; }
        public Function Function { get; set; }
        public IEnumerable<Argument> Arguments { get; set; }
        public bool IsExit { get; set; }
        public string Text { get; set; }
        private readonly string _workingDirectory;

        public Command(IRunner runner, string command, string workingDirectory) : this(runner, command)
        {
            _workingDirectory = workingDirectory;
        }

        public Command(IRunner runner, string command)
        {
            _runner = runner;
            CommandLine = new CommandLine(command);
            Function = new Function(CommandLine.Function);
            IsExit = Function.Name.Equals("exit", StringComparison.InvariantCultureIgnoreCase);
            Arguments = CreateArguments(CommandLine.Arguments);
            Text = CommandLine.Text;
        }

        public CommandResult Execute()
        {
            var text = _runner.Execute(new RunnerArgs { Script = Text, WorkingDirectory = _workingDirectory});
            var result = new CommandResult {Text = text, WorkingDirectory = _runner.WorkingDirectory};
            return result;
        }

        public IEnumerable<string> Complete()
        {
            var lastArgument = Arguments.LastOrDefault();
            return null == lastArgument ? Enumerable.Empty<string>() : lastArgument.Complete();
        }

        protected IEnumerable<Argument> CreateArguments(IEnumerable<string> arguments)
        {
            return arguments.Select(argument => ArgumentFactory.Create(_runner, argument));
        }

        public override string ToString()
        {
            return CommandLine.Text;
        }

        public override bool Equals(object obj)
        {
            return ((Command)obj).CommandLine.Text.Equals(CommandLine.Text);
        }

        public override int GetHashCode()
        {
            return CommandLine.Text.GetHashCode();
        }

    }
}
