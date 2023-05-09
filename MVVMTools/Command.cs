using System;
using System.Windows.Input;

namespace MVVMTools
{
    public class Command<T> : CommandBase, ICommand
    {
        public Command(Action<T> action, Func<bool> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        private Action<T> action;

        public void Execute(object? parameter)
        {
            action?.Invoke((T)parameter);
        }
    }

    public class Command : CommandBase, ICommand
    {
        public Command(Action<object> action, Func<bool> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        private Action<Object> action;

        public void Execute(object? parameter)
        {
            action?.Invoke(parameter);
        }
    }
}
