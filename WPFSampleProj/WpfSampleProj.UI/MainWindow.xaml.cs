using Microsoft.Practices.Unity;
using System.Windows;
using WpfSampleProj.UI.ViewModel;

namespace WpfSampleProj.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        [Dependency]
        public MainViewModel ViewModel
        {
            set
            {
                DataContext = value;
            }
        }
    }
}
