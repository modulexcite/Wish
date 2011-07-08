﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Wish.Core;

namespace Wish
{
    public class UpStrategy : IKeyStrategy
    {
        private readonly WishModel _wishModel;

        public UpStrategy(WishModel wishModel)
        {
            _wishModel = wishModel;
        }

        public void Handle(KeyEventArgs e)
        {
            if (_wishModel.ActivelyTabbing) return;
            var next = CommandHistory.GetNext();
            _wishModel.ReplaceLine(next);
        }
    }
}
