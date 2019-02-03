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
}
