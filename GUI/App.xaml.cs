using GUI.Services;
using GUI.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceCollection services = new ServiceCollection();

        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<addManuallyViewModel>();
            services.AddSingleton<editProductInLineOfGoodsViewModel>();
            services.AddSingleton<addProductToLineOfGoodsViewModel>();
            services.AddSingleton<searchProductInLineOfGoodsViewModel>();
            services.AddSingleton<PayWindowViewModel>();

            services.AddSingleton<ViewModelLocator>();
            services.AddSingleton<WindowMapper>();

            services.AddSingleton<IWindowManager, WindowManager>();
            services.AddSingleton<IaddManuallyService, addManuallyService>();
            services.AddSingleton<IeditLineOfGoods, editLineOfGoodsService>();

            _serviceProvider = services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            windowManager.ShowWindow(viewModel: _serviceProvider.GetRequiredService<MainWindowViewModel>());
            base.OnStartup(e);
        }

    }
}
