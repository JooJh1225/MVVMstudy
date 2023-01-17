using System;
using System.Windows.Input;

namespace WPF_Subway.ViewModels
{
    internal class DelegateCommand : ICommand
    {
        //커맨드 바인딩을 위한 클래스

        private readonly Func<bool> canExecute;
        private readonly Action execute;

        public DelegateCommand(Action execute) : this(execute, null)
        {

        }
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
        {
            if(this.canExecute == null)
            {
                return true;
            }
            return this.canExecute();
        }

        public void Execute(object o)
        {
            this.execute();
        }

        public void RaiseCanExecuteChanged()
        {
            if(this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}