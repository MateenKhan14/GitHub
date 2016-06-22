using System;
using System.Windows.Input;

namespace PostApiCore
{
    public class Command : ICommand
    {
        /// <summary>
        /// Represents the Action that is also a type of delegate that does not return values
        /// </summary>
        private Action<object> _action;

        /// <summary>
        /// Represents the Predicate that is also a type of delegate that return values but always bolean.
        /// </summary>
        Predicate<object> _canexecute;

        /// <summary>
        /// Construct the Command object
        /// </summary>
        /// <param name="action">The delegate Action</param>
        /// <param name="canexecute">The delegate Predicate that returns a flag to execute the method</param>
        public Command(Action<object> action, Predicate<object> canexecute)
        {
            this._action = action;
            this._canexecute = canexecute;
            
        }

        /// <summary>
        /// Return the true of false on the bases of condition
        /// </summary>
        /// <param name="parameter">The Parameter</param>
        /// <returns>True or False</returns>
        public bool CanExecute(object parameter)
        {
            if (_canexecute != null)
            {
                return _canexecute.Invoke(parameter);
            }

            return true;
        }

        /// <summary>
        /// Handles the event
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executes the method
        /// </summary>
        /// <param name="parameter"> The parameter</param>
        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
