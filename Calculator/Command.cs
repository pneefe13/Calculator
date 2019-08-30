using System;
using System.Windows.Input;

namespace Calculator
{
    public class Command : ICommand
    {
        public Predicate<object> CanExecuteFunc { get; set; }

        public Action<object> ExecuteFunc { get; set; }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteFunc(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}