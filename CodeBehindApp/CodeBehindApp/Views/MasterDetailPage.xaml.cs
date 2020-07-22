using System.Windows.Controls;
using CodeBehindApp.Contracts.Views;
using CodeBehindApp.Core.Services;
using System.Linq;

namespace CodeBehindApp.Views
{
    public partial class MasterDetailPage : Page, INavigationAware
    {
        private readonly SampleDataService _sampleDataService;

        public MasterDetailPage()
        {
            _sampleDataService = new SampleDataService();
            InitializeComponent();
        }

        public async void OnNavigatedTo(object parameter)
        {
            listView.Items.Clear();

            var data = await _sampleDataService.GetMasterDetailDataAsync();

            foreach (var item in data)
            {
                listView.Items.Add(item);
            }

            listView.SelectedIndex = 0;
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                detailControl.Content = e.AddedItems[0];
            }
        }
    }
}
