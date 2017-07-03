using System;
using System.Windows.Input;

namespace MVVM
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> action)
            : this(action, null)
        {
        }

        public RelayCommand(Action<object> action, Predicate<object> predicate)
        {
            if (action == null) throw new ArgumentNullException("Command action must not be null");
            _action = action;
            _predicate = predicate;
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
