﻿using GUI.MVVM.ViewModel;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Services
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider _provider;

        public ViewModelLocator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public MainWindowViewModel MainWindowViewModel => _provider.GetRequiredService<MainWindowViewModel>();

        public addManuallyViewModel addManuallyViewModel => _provider.GetRequiredService<addManuallyViewModel>();

        public addProductToLineOfGoodsViewModel addProductToLineOfGoodsViewModel => _provider.GetRequiredService<addProductToLineOfGoodsViewModel>();

        public editProductInLineOfGoodsViewModel editProductInLineOfGoodsViewModel => _provider.GetRequiredService<editProductInLineOfGoodsViewModel>();

        public searchProductInLineOfGoodsViewModel SearchProductInLineOfGoodsViewModel => _provider.GetRequiredService<searchProductInLineOfGoodsViewModel>();

        public PayWindowViewModel PayWindowViewModel => _provider.GetRequiredService<PayWindowViewModel>();

    }
}
