using System;
using System.Linq;
using System.Threading.Tasks;
using CodeBehindApp.Views;

namespace CodeBehindApp.Services
{
    public class ApplicationHostService
    {
        private readonly PersistAndRestoreService _persistAndRestoreService;
        private ShellWindow _shellWindow;

        public ApplicationHostService()
        {
            _persistAndRestoreService = new PersistAndRestoreService();
        }

        public async Task StartAsync()
        {
            // Initialize services that you need before app activation
            await InitializeAsync();

            await HandleActivationAsync();

            // Tasks after activation
            await StartupAsync();
        }

        public async Task StopAsync()
        {
            _persistAndRestoreService.PersistData();
            await Task.CompletedTask;
        }

        private async Task InitializeAsync()
        {
            _persistAndRestoreService.RestoreData();
            ThemeSelectorService.SetTheme();
            await Task.CompletedTask;
        }

        private async Task StartupAsync()
        {
            await Task.CompletedTask;
        }

        private async Task HandleActivationAsync()
        {
            if (App.Current.Windows.OfType<ShellWindow>().Count() == 0)
            {
                // Default activation that navigates to the apps default page
                _shellWindow = new ShellWindow();
                NavigationService.Initialize(_shellWindow.GetNavigationFrame());
                _shellWindow.ShowWindow();
                NavigationService.NavigateTo(typeof(MainPage));
                await Task.CompletedTask;
            }
        }
    }
}
