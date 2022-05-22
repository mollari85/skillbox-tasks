using System;
using System.Windows.Input;

namespace task6.Tools
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;// private Predicate<object> canExecut;
        private Func<object,object, string> executeFunc;


        public event EventHandler CanExecuteChanged
        {
            add { /*CommandManager.RequerySuggested += value; */}
            remove { /*CommandManager.RequerySuggested -= value;*/ }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public RelayCommand(Func<object,object,string> func)
        {
            this.executeFunc = func;

        }


        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
        // for my function which returning  string type
        public string Execute(object parameterIn1,object parameterIn2)
        {
            return (this.executeFunc(parameterIn1,parameterIn2));
        }
    }
}
