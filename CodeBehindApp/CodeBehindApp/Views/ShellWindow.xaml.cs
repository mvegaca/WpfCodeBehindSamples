using System.Windows.Controls;

using CodeBehindApp.Contracts.Views;
using CodeBehindApp.ViewModels;

using MahApps.Metro.Controls;

namespace CodeBehindApp.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();
    }
}
