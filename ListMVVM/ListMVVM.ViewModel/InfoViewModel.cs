using quickmvvm;
using System;
using System.Windows.Input;

namespace ListMVVM.ViewModel
{
    public class InfoViewModel : ObservableObject, IViewModel
    {
        //usando DelegateCommand para controlar eventos 
        Action Close;
        //public ICommand Close_ClickCommand => new DelegateCommand(CloseWindow);
        public ICommand OK_ClickCommand => new DelegateCommand(OK);

       

#pragma warning disable CS0649 // Campo "InfoViewModel._mainViewModel" nunca é atribuído e sempre terá seu valor padrão null
        MainViewModel _mainViewModel= new MainViewModel();
#pragma warning restore CS0649 // Campo "InfoViewModel._mainViewModel" nunca é atribuído e sempre terá seu valor padrão null

        public InfoViewModel() { }
        //construtor alternativo com Action 
        public InfoViewModel(Action Close)
        {
            this.Close = Close;
            _mainViewModel.TitleState = "Menu Inicial";
            _mainViewModel.Icon = "Home";
           
        }

        //implementando método CloseWindow(arg)
        //private void CloseWindow(object parameter)
        //{
        //    _mainViewModel.Return();
        //    Close();
        //}

        public void OK(object parameter)
        {
            Close();
        }


    }
}
