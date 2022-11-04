using ListMVVM.ViewModel;
using MahApps.Metro.Controls;

namespace ListMVVM
{
    /// <summary>
    /// Lógica interna para MainView.xaml
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
            InitializeComponent();
            //única janela secundária é InfoView então é preciso definir o DataContext para uma eventual chamada desta janela
            DataContext = new MainViewModel(Helpers.InfoViewHelper.OpenInfoView);
        }

    }
}
