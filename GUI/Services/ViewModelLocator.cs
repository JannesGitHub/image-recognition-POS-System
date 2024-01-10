using GUI.MVVM.ViewModel;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Services
{
    /// <summary>
    /// Holt sich die gefordertet registrierten Services automatisch per GetRequiredService()
    /// -> registrierte Services sind in App.xaml.cs deklariert
    /// </summary>
    public class ViewModelLocator
    {
        private readonly IServiceProvider _provider;

        public ViewModelLocator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public MainVM MainVM => _provider.GetRequiredService<MainVM>();

        public AddManuallyVM AddManuallyVM => _provider.GetRequiredService<AddManuallyVM>();

        public AddProductToLineOfGoodsVM AddProductToLineOfGoodsVM => _provider.GetRequiredService<AddProductToLineOfGoodsVM>();

        public EditProductInLineOfGoodsVM EditProductInLineOfGoodsVM => _provider.GetRequiredService<EditProductInLineOfGoodsVM>();

        public SearchProductInLineOfGoodsVM SearchProductInLineOfGoodsVM => _provider.GetRequiredService<SearchProductInLineOfGoodsVM>();

        public PayVM PayVM => _provider.GetRequiredService<PayVM>();

    }
}
