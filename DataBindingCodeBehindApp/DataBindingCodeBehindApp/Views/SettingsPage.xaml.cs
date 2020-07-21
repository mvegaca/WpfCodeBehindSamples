using System.Windows.Controls;

using DataBindingCodeBehindApp.ViewModels;

namespace DataBindingCodeBehindApp.Views
{
    public partial class SettingsPage : Page
    {
        public SettingsPage(SettingsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
