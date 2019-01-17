using PersonalExpenses.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalExpenses.View.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo cultureInfo = null;

        static readonly Lazy<ResourceManager> resourceManager = new Lazy<ResourceManager>(() => new ResourceManager("PersonalExpenses.Resources.AppResources", IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        public string ResourceName { get; set; }

        public TranslateExtension()
        {
            cultureInfo = AppResources.Culture;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(ResourceName))
                return string.Empty;
            else
            { 
                string value= resourceManager.Value.GetString(ResourceName, cultureInfo);
                if (value == null)
                    return string.Empty;
                else
                    return value;
            }
        }
    }
}
