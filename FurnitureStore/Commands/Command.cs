using System;
using System.Windows.Input;

namespace FurnitureStore.Commands
{
    /// <summary>
    /// Defines a ICommand implementation for simple bindings.
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action _action;

        public event EventHandler CanExecuteChanged;


        public Command(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }
    }

    /// <summary>
    /// Defines a ICommand implementation for bindings with parameter.
    /// </summary>
    public class Command<TParameter> : ICommand
    {
        private readonly Action<TParameter> _action;

        public event EventHandler CanExecuteChanged;


        public Command(Action<TParameter> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameterObj)
        {
            if (parameterObj is TParameter parameter)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameterObj)
        {
            if (parameterObj is TParameter parameter)
            {
                _action?.Invoke(parameter);
            }
        }
    }
}
