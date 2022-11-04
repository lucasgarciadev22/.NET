using ListMVVM.ViewModel;
using ListMVVM.Windows;
using System;
using System.Windows;

namespace ListMVVM.Helpers
{
    public class InfoViewHelper
    {
#pragma warning disable CS0169 // O campo "InfoViewHelper._mainViewModel" nunca é usado
        static MainViewModel _mainViewModel;
#pragma warning restore CS0169 // O campo "InfoViewHelper._mainViewModel" nunca é usado
#pragma warning disable CS0649 // Campo "InfoViewHelper._mainViewModel" nunca é atribuído e sempre terá seu valor padrão null
#pragma warning restore CS0649 // Campo "InfoViewHelper._mainViewModel" nunca é atribuído e sempre terá seu valor padrão null

        static InfoView _infoView;

        public static void OpenInfoView()
        {
            try
            {
                _infoView = new InfoView();
                
                _infoView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a InfoView!");
            }
        }

        public static void CloseInfoView()
        {
            _infoView.Close();
        }
    }
}
