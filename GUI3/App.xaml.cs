using GUI.Services;
using GUI.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI3
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

            services.AddSingleton<ViewModelLocator>();
            services.AddSingleton<WindowMapper>();

            services.AddSingleton<IWindowManager, WindowManager>();

            _serviceProvider = services.BuildServiceProvider(); //CS1061

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            windowManager.ShowWindow(viewModel: _serviceProvider.GetRequiredService<MainWindowViewModel>());
            base.OnStartup(e);
        }

    }
}
