using GUI.MVVM.ViewModel;
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
        Window ShowWindow(ViewModelBase viewModel);
        void CloseWindow(ViewModelBase viewModel);
    }
    /// <summary>
    /// - Service der zum Öffnen und Schließen von Fenstern über Command zuständig ist.
    /// - verwendet WindowMapper um Fenster über zugehöriges ViewModel anzustuern
    /// - Windows -> alle laufenden Fenster -> ermöglicht Kommunikation zwischen ViewModels
    /// </summary>
    public class WindowManager : IWindowManager
    {
        private WindowMapper _windowMapper;

        public Dictionary<Type, Window> Windows { get; set; } = new Dictionary<Type, Window>();   

        public WindowManager(WindowMapper windowMapper)
        {
            _windowMapper = windowMapper;
        }  

        public Window ShowWindow(ViewModelBase viewModel)
        {
            Type windowType = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType());
            if(windowType != null)
            {
                var window = Activator.CreateInstance(windowType) as Window;
                Windows.Add(windowType,window);
                window.DataContext = viewModel;
                window.Show();

                return window;
            }

            return null;
        }

        public void CloseWindow(ViewModelBase viewModel) 
        {
            Type windowType = _windowMapper.GetWindowTypeForViewModel(viewModel.GetType());
            if(windowType != null)
            {
                Windows[windowType].Close();
                Windows.Remove(windowType);
            }
        }
    }
}
