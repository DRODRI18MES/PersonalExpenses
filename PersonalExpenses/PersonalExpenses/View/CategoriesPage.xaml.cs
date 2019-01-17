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
	public partial class CategoriesPage : ContentPage
	{
        CategoriesVM viewModel;

        public CategoriesPage ()
		{
			InitializeComponent ();
            viewModel = Resources["vm"] as CategoriesVM;
            SizeChanged += CategoriesPage_SizeChanged;
        }

        private void CategoriesPage_SizeChanged(object sender, EventArgs e)
        {
            string visualState = Width > Height ? "Landscape" : "Portrait";
            VisualStateManager.GoToState(titleLabel, visualState);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.GetProgress();
        }

    }
}