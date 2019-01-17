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
	public partial class ExpensesPage : ContentPage
	{
        ExpensesVM viewModel;

		public ExpensesPage ()
		{
			InitializeComponent ();

            viewModel = Resources["vm"] as ExpensesVM;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.ReadExpenses();
        }
    }
}