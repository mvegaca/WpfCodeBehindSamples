using System.Windows.Controls;

using CodeBehindApp.ViewModels;

namespace CodeBehindApp.Views
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
