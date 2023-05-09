using System;

namespace MVVMTools
{
    public class CommandBase
    {
        public event EventHandler? CanExecuteChanged;
        protected Func<bool> canExecute;

        public bool CanExecute(object? parameter) => canExecute?.Invoke() ?? true;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
