using PersonalExpenses.Model;
using PersonalExpenses.View;
using PersonalExpenses.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalExpenses.ViewModel
{
    public class ExpensesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public NewExpensesCommand NewExpenseCommand { get; set; }
        public ICommand DeleteExpenseCommand { get; set; }
        public ObservableCollection<Expense> Expenses { get; set; }
        public ICommand RefreshExpensesCommand { get; set; }

        public ExpensesVM()
        {
            Expenses = new ObservableCollection<Expense>();
            NewExpenseCommand = new NewExpensesCommand(this);
            DeleteExpenseCommand = new Command<Expense>(DeleteExpense);
            RefreshExpensesCommand = new Command(ReadExpenses);
        }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; OnPropertyChanged("IsRefreshing"); }
        }


        public void NewExpense()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewExpensePage(), true);
        }

        public void DeleteExpense(Expense expense)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.Delete(expense);
                ReadExpenses();
            }

        }

        public void ReadExpenses()
        {
            IsRefreshing = true;

            var expenses = Expense.GetExpenses();

            Expenses.Clear();

            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
            IsRefreshing = false;

        }

        private Expense selectedExpense;

        public Expense SelectedExpense
        {
            get { return selectedExpense; }
            set
            {
                selectedExpense = value;
                OnPropertyChanged("SelectedExpense");
                App.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(selectedExpense));
            }
        }


        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
