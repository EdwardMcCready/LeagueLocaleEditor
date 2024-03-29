﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LeagueLocaleEditor.UI
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        readonly Action execute;
        public Command(Action action)
        {
            execute = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
