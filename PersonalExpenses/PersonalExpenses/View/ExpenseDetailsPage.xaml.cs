using PersonalExpenses.Model;
using PersonalExpenses.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalExpenses.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExpenseDetailsPage : ContentPage
	{

        ExpenseDetailsVM viewModel;
        

		public ExpenseDetailsPage (Expense selectedExpense)
		{
			InitializeComponent ();
            viewModel = Resources["vm"] as ExpenseDetailsVM;
            viewModel.Selected = selectedExpense;
        }

    }
}