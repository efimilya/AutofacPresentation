using System.Windows;

namespace AutofacPresentation
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = GoodCompositionRoot.CreateMainWindowViewModel();
        }
    }
}