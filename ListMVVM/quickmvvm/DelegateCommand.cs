using System;
using System.Windows.Input;

namespace quickmvvm
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _action;
        private Func<bool> _canExecute;
        public DelegateCommand(Action<object> action, Func<bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }
    }
}
