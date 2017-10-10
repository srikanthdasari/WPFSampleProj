using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfSampleProj.UI.Utils
{
    public class RelayCommand : ICommand
    {
        private bool _canExecute;
        private Action<object> _execute;

        public RelayCommand(bool canExecute, Action<object> execute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        public RelayCommand(Action<object> execute)
        {
            this._canExecute = true;
            this._execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //return (bool)parameter; //just hack for now
            return true;
        }




        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

}
