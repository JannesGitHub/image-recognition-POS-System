using GUI.MVVM.ViewModel;
using GUI.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.Services
{
    public class WindowMapper
    {
        private readonly Dictionary<Type, Type> _mappings = new();

        public WindowMapper()
        {
            RegisterMapping<MainWindowViewModel, MainWindow>();
            RegisterMapping<addManuallyViewModel, addManuallyWindow>();
            RegisterMapping<editLineOfGoodsViewModel, editLineOfGoodsWindow>();
            RegisterMapping<editProductInLineOfGoodsViewModel, editProductInLineOfGoodsWindow>();
            RegisterMapping<addProductToLineOfGoodsViewModel, addProductToLineOfGoodsWindow>();
            RegisterMapping<searchProductInLineOfGoodsViewModel, searchProductInLineOfGoodsWindow>();
        }

        public void RegisterMapping<TViewModel, TWindow>() where TViewModel : ViewModelBase where TWindow : Window
        {
            _mappings[typeof(TViewModel)] = typeof(TWindow);
        }

        public Type GetWindowTypeForViewModel(Type viewModelType)
        {
            _mappings.TryGetValue(viewModelType, out var windowType);
            return windowType;
        }

    }
}
