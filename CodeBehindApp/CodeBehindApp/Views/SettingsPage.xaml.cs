using System.Windows.Controls;

using CodeBehindApp.ViewModels;

namespace CodeBehindApp.Views
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
