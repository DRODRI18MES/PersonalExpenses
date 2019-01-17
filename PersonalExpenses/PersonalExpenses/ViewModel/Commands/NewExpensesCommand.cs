using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PersonalExpenses.ViewModel.Commands
{
    public class NewExpensesCommand : ICommand
    {
        public ExpensesVM ViewModel { get; set; }

        public NewExpensesCommand(ExpensesVM vM)
        {
            ViewModel = vM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.NewExpense();
        }


    }
}
