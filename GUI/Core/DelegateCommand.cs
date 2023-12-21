using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.Core
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public DelegateCommand(Action<object> execute) : this(null, execute) { }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => execute?.Invoke(parameter);

        // Diese Methode informiert WPF, dass der CanExecute-Status sich möglicherweise geändert hat.
        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
    }
}
