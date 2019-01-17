using PersonalExpenses.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Model
{
    public class Category
    {

        public static List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            //categories.Add("Transporte");
            //categories.Add("Personal");
            //categories.Add("Salud");
            //categories.Add("Ocio");
            //categories.Add("Hogar");
            //categories.Add("Otros");

            categories.Add(AppResources.transportCategory);
            categories.Add(AppResources.savingsCategory);
            categories.Add(AppResources.healthCategory);
            categories.Add(AppResources.playCategory);
            categories.Add(AppResources.homeCategory);
            categories.Add(AppResources.otherCategory);

            return categories;
        }
    }
}
