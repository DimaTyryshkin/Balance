using System;
using System.Windows.Input;

namespace Balance.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;
        
        public event EventHandler CanExecuteChanged;
       
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }
       
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.execute = execute;
            this.canExecute = canExecute;
        }
       
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }
       
        public void Execute(object parameter)
        {
            execute();
        }
        
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
