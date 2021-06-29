using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace BISCOT_F
{
    class DelegateCommand : ICommand
    {
        private readonly Action executeMethod;

        private readonly Func<bool> canExecuteMethod;

        public DelegateCommand(Action executeMethod)
            : this(executeMethod, null)
        {
        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecuteMethod != null ? this.canExecuteMethod() : true;
        }

        public void Execute(object parameter)
        {
            if (this.executeMethod != null)
            {
                this.executeMethod();
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}