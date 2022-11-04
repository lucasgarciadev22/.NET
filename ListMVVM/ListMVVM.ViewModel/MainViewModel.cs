using quickmvvm;
using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;

namespace ListMVVM.ViewModel
{
    #region Classes
    public class MainViewModel : ObservableObject
    {
        public MainViewModel() { }
        //construtor alternativo da MainView que leva um argumento Action
        public MainViewModel(Action OpenInfoView)
        {
            TitleState = "Menu Inicial";
            Icon = "Home";
            this.OpenInfoView = OpenInfoView;
            TimerConfig();
        }
        #endregion

        #region Actions
        //definindo as ações para chamada de janela secundária
        Action OpenInfoView;
#pragma warning disable CS0169 // O campo "MainViewModel.GotFocus" nunca é usado

        #endregion

        #region Variables
        //definindo o conteúdo da barra de status 
        public string _titleState; public string TitleState { get { return _titleState; } set { _titleState = value; OnPropertyChanged(); } }
        private string _icon; public string Icon { get { return _icon; } set { _icon = value; OnPropertyChanged(); } }
        private bool _edit; public bool Edit { get { return _edit; } set { _edit = value; OnPropertyChanged(); } }

        #endregion

        #region Event Handlers
        //definindo o conteúdo da janela or meio de modelos de UserControls
        private IViewModel _windowBody; public IViewModel WindowBody { get { return _windowBody; } set { _windowBody = value; OnPropertyChanged(); } }
        //definindo todos os possíveis comandos da tela (no caso ações de botões)
        public ICommand CRUD_ClickCommand => new DelegateCommand(ChangeBodyToCRUD);
        public ICommand Info_ClickCommand => new DelegateCommand(ShowInfoView);
        public ICommand GiHub_ClickCommand => new DelegateCommand(GitHub);

        DispatcherTimer _addStatus = new DispatcherTimer();


        #endregion

        #region Mehtods

        //definindo a Action OpenInfoView pois ela é janela e não UserControl
        public void ShowInfoView(object parameter)
        {
            //ao abrir a Info...
            TitleState = "Visualizando Info";
            Icon = "CheckboxMultipleBlank";

            OpenInfoView(); //chamando a Action declarada anteriormente

            //apos abrir a Info...
            TitleState = "Menu Inicial";
            Icon = "Home";
        }

        //método público para Bindings funcionar -> cria nova instância de CRUDView (UserControl) para alterar o conteúdo da MainView
        public void ChangeBodyToCRUD(object parameter)
        {
            ChangeBodyViewModel(new CRUDViewModel(this));
            TitleState = "Visualizando CRUD";
            Icon = "FormSelect";
            Edit = true;
        }

        //limpando o conteúdo do WindowBody na tela
        public void ClearScreen()
        {
            ChangeBodyViewModel(null);
            TitleState = "Menu Inicial";
            Icon = "Home";
            Edit = false;
        }

        void TimerConfig()
        {
            _addStatus.Interval = TimeSpan.FromSeconds(4);
            _addStatus.Tick += SetDefaultStatusMsg;
        }

        void SetDefaultStatusMsg(object sender, EventArgs e)
        {
            TitleState = "Visualizando Info";
            Icon = "CheckboxMultipleBlank";
            _addStatus.Stop();
        }

        void GitHub(object parameter)
        {
            Process.Start("https://github.com/lucasgarciadev22");
        }

        //definindo a interface padrão que carregará o conteúdo do WindowBody cada vez que um novo UserControl for carregado para dentro do viewModel
        private void ChangeBodyViewModel(IViewModel viewModel)
        {
            WindowBody = viewModel;
        }
        #endregion
    }
}
