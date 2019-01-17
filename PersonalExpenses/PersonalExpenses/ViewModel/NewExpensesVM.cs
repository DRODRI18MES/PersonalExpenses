using PersonalExpenses.Model;
using PersonalExpenses.View;
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
    class NewExpensesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveExpenseCommand { get; set; }

        bool IsEditing;

        public Expense Expenses;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged("Amount"); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged("Category"); }
        }


        public ObservableCollection<string> Categories { get; set; }

        public NewExpensesVM()
        {
            IsEditing = false;
            Date = DateTime.Now;
            SaveExpenseCommand = new Command(SaveExpense);

            Categories = new ObservableCollection<string>();
            foreach (string category in Model.Category.GetCategories())
            {
                Categories.Add(category);
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SaveExpense(object parameter)
        {
           
            int filasModificadas = 0;

            if (!IsEditing)
            {
                Expense expense = new Expense
                {
                    Name = Name,
                    Amount = Amount,
                    Date = Date,
                    Category = Category
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Expense>();
                    filasModificadas = conn.Insert(expense);
                }
            }
            else
            {
                Expenses.Name = this.Name;
                Expenses.Amount = this.Amount;
                Expenses.Date = this.Date;
                Expenses.Category = this.Category;


                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Expense>();
                    filasModificadas = conn.Update(Expenses);
                }
            }

            if (filasModificadas > 0)

                App.Current.MainPage.Navigation.PopAsync(true);
            else
                App.Current.MainPage.DisplayAlert("Error", "No se inserto el contacto", "Cancelar");


        }
    }
}
