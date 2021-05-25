using System;
using System.Windows.Input;

namespace GtLibHelper.ViewModel
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute; 
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Command creation
        /// </summary>
        /// <param name="execute">Activity to be carried out</param>
        public DelegateCommand(Action<object> execute) : this(null, execute) { }

        /// <summary>
        /// Command creation
        /// </summary>
        /// <param name="canExecute">Condition of enforceability</param>
        /// <param name="execute">Activity to be carried out</param>
        public DelegateCommand(Func<object, bool> canExecute, Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Event of change in enforceability
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Verification of enforceability 
        /// </summary>
        /// <param name="parameter">Parameter of activity</param>
        /// <returns>True if the activity is executable</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Execution of an activity
        /// </summary>
        /// <param name="parameter">Parameter of activity</param>
        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                throw new InvalidOperationException("Command execution is disabled.");
            }
            _execute(parameter);
        }

        /// <summary>
        /// Event triggering a change in executability
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
