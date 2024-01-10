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
    /// - Startpunkt des Programms: Initialisiert und registriert den WindowManager, ViewModelLocator und WindowMapper.
    /// - Registriert alle erforderlichen ViewModels und Services im Dependency Injection Container, um die Verwendung von GetRequiredService() im ViewModelLocator zu ermöglichen.
    /// - OnStartUp: Bei Programmstart wird das Hauptfenster (MainWindow) mithilfe des zugehörigen ViewModels (MainVM) angezeigt.
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceCollection services = new ServiceCollection();

        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            //ViewModels
            services.AddSingleton<MainVM>();
            services.AddSingleton<AddManuallyVM>();
            services.AddSingleton<EditProductInLineOfGoodsVM>();
            services.AddSingleton<AddProductToLineOfGoodsVM>();
            services.AddSingleton<SearchProductInLineOfGoodsVM>();
            services.AddSingleton<PayVM>();

            //Services
            services.AddSingleton<ViewModelLocator>();
            services.AddSingleton<WindowMapper>();
            services.AddSingleton<IWindowManager, WindowManager>();
            services.AddSingleton<IAddManuallyService, AddManuallyService>();
            services.AddSingleton<IEditLineOfGoods, EditLineOfGoodsService>();
            services.AddSingleton<IPayService, PayService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e) 
        {
            IWindowManager windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            windowManager.ShowWindow(viewModel: _serviceProvider.GetRequiredService<MainVM>());
            base.OnStartup(e);
        }

    }
}
