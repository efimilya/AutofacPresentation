using System.Windows;
using AutofacPresentation.Frontend;

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
            DataContext = BadCompositionRoot.CreateMainWindowViewModel();
        }
    }
}