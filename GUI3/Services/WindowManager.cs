﻿using GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.Services
{

    public interface IWindowManager
    {
        void ShowWindow(ViewModelBase viewModel);
        void CloseWindow();
    }
    public class WindowManager : IWindowManager
    {
        private WindowMapper _windowMapper;

        public WindowManager(WindowMapper windowMapper)
        {
            _windowMapper = windowMapper;
        }  

        public void ShowWindow(ViewModelBase viewModel)
        {
            var windowType = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType());
            if(windowType != null)
            {
                var window = Activator.CreateInstance(windowType) as Window;
                window.DataContext = viewModel;
                window.Show();
                window.Closed += (sender, args) => CloseWindow();
            }
        }

        public void CloseWindow()
        {
            MessageBox.Show("Test!");
        }
    }
}
