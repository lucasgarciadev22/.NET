using ListMVVM.ViewModel;
using MahApps.Metro.Controls;

namespace ListMVVM.Windows
{
    /// <summary>
    /// Lógica interna para InfoView.xaml
    /// </summary>
    public partial class InfoView : MetroWindow
    {
        public InfoView()
        {
            InitializeComponent();
            //criando uma instância de classe e passando a Action do Helpers
            InfoViewModel infoViewModel = new InfoViewModel(Helpers.InfoViewHelper.CloseInfoView);
            DataContext = infoViewModel;
        }
    }
}
