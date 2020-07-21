using System.Windows.Controls;

using CodeBehindApp.ViewModels;

namespace CodeBehindApp.Views
{
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
