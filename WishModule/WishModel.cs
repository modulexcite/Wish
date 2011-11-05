﻿using System;
using System.Windows.Input;
using Wish.Common;
using Wish.Scripts;

namespace Wish
{
    public class WishModel
    {
        private readonly IRepl _repl;

        public WishModel(IRepl repl)
        {
            _repl = repl;
        }

        public CommandResult Raise(Key key, string text)
        {
            if (key.Equals(Key.Enter))
            {
                return _repl.Loop(text);
            }
            return new CommandResult { Handled = false, IsExit = false, Text = string.Empty, Error = "massive fail" };
        }

        public CommandResult Start()
        {
            return _repl.Start();
        }
    }
}
