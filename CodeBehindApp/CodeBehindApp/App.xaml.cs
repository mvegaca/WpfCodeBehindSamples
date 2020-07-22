using System.Windows;
using System.Windows.Threading;
using CodeBehindApp.Services;

namespace CodeBehindApp
{
    // For more inforation about application lifecyle events see https://docs.microsoft.com/dotnet/framework/wpf/app-development/application-management-overview

    // WPF UI elements use language en-US by default.
    // If you need to support other cultures make sure you add converters and review dates and numbers in your UI to ensure everything adapts correctly.
    // Tracking issue for improving this is https://github.com/dotnet/wpf/issues/1946
    public partial class App : Application
    {
        private readonly ApplicationHostService _applicationHostService;

        public App()
        {
            _applicationHostService = new ApplicationHostService();
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _applicationHostService.StartAsync();
        }        

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _applicationHostService.StopAsync();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
        }
    }
}
