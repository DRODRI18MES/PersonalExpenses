using PCLStorage;
using PersonalExpenses.Model;
using PersonalExpenses.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalExpenses.ViewModel
{
    public class CategoriesVM : INotifyPropertyChanged
    {
        public class Progress
        {
            public string Name { get; set; }
            public double ProgressValue { get; set; }
        }

        public ObservableCollection<Progress> Progresses { get; set; }
        public ICommand ExportButtonCommand { get; set; }


        public CategoriesVM()
        {
            hasProgresses = false;
            Progresses = new ObservableCollection<Progress>();
            ExportButtonCommand = new Command<bool>(ExportCategories, ExportCommandCanExecute);
            GetProgress();
        }

        public bool ExportCommandCanExecute(bool arg)
        {
            return arg;
        }

        async void ExportCategories(bool obj)
        {
            //Creating the file....
            IFileSystem fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var reportsFolder = await rootFolder.CreateFolderAsync("Reports", CreationCollisionOption.OpenIfExists);
            var reportFile = await reportsFolder.CreateFileAsync("Report.txt", CreationCollisionOption.ReplaceExisting);
            using (StreamWriter streamWriter = new StreamWriter(reportFile.Path))
            {
                foreach (Progress progress in Progresses)
                    streamWriter.WriteLine($"{progress.Name} - {progress.ProgressValue:p}");
            }

            //Sharing the file...
            IShare shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Reporte de Gastos", "Reporte de gastos por categoría", reportFile.Path);
            //App.Current.MainPage.DisplayAlert("Error", "Test", "Cancelar");
        }

        public void GetProgress()
        {
            var categories = Category.GetCategories();
            var expenses = Expense.GetExpenses();

            double totalExpenses = expenses.Sum(e => e.Amount);
            Progresses.Clear();

            if (categories != null && categories.Count > 0)
            {
                hasProgresses = true;
                foreach (var category in categories)
                {
                    var totalAmount = expenses.Where(x => x.Category == category).Sum(e => e.Amount);
                    Progresses.Add(new Progress() { Name = category, ProgressValue = totalAmount / totalExpenses });
                }
            }
            else
                hasProgresses = false;
        }

        private bool hasProgresses;
        public bool HasProgresses
        {
            get { return hasProgresses; }
            set
            {
                hasProgresses = value;
                OnPropertyChanged("HasProgresses");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
