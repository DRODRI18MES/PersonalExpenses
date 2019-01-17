using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenses.ViewModel.Interfaces
{
    public interface IShare
    {
        Task Show(string title, string message, string path);
    }
}
