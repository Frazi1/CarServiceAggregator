using System;
using System.Windows.Input;

namespace Mvvm
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _action = action;
            _predicate = predicate;
        }

        //TODO: Переделать реализацию
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_predicate == null) return true;
            return _predicate(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}