using System.Windows.Controls;

using DataBindingCodeBehindApp.Contracts.Views;
using DataBindingCodeBehindApp.ViewModels;

using MahApps.Metro.Controls;

namespace DataBindingCodeBehindApp.Views
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
