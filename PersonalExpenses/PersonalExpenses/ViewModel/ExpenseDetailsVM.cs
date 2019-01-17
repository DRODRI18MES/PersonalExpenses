using PersonalExpenses.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PersonalExpenses.ViewModel
{
    class ExpenseDetailsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Expense selected;
        public Expense Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");

            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
