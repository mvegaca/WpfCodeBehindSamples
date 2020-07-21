using System.Windows.Controls;

using DataBindingCodeBehindApp.ViewModels;

namespace DataBindingCodeBehindApp.Views
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
