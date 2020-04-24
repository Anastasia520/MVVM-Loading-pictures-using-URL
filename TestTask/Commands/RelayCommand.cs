using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestTask.Commands
{
    class RelayCommand : ICommand
    {
        Action<object> executeAction;
        Func<object, bool> canExecute;
        bool canExecuteCache;
         public RelayCommand(Action<object> executeAction, Func<object,bool> canExecute, bool canExecuteCache)
        {
            this.canExecute = canExecute;
            this.executeAction = executeAction;
            canExecuteCache = canExecuteCache;
        }
        public bool CanExecute(object parametr)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute(parametr);
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

       

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
    }
}
