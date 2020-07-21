using System.Windows.Controls;

using DataBindingCodeBehindApp.ViewModels;

namespace DataBindingCodeBehindApp.Views
{
    public partial class MasterDetailPage : Page
    {
        public MasterDetailPage(MasterDetailViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
