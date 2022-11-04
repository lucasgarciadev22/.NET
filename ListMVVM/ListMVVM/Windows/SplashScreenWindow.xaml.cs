using MahApps.Metro.Controls;

namespace ListMVVM.Windows
{
    /// <summary>
    /// Lógica interna para SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : MetroWindow
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
        }

        public double Progress
        {
            get { return progressBar.Value; }
            set { progressBar.Value = value; }
        }
    }
}
