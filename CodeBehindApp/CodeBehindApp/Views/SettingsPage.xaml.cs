using System;
using System.Windows;
using System.Windows.Controls;
using CodeBehindApp.Contracts.Views;
using CodeBehindApp.Models;
using CodeBehindApp.Services;

namespace CodeBehindApp.Views
{
    public partial class SettingsPage : Page, INavigationAware
    {
        private readonly ApplicationInfoService _applicationInfoService;
        private readonly SystemService _systemService;

        public SettingsPage()
        {
            InitializeComponent();
            _applicationInfoService = new ApplicationInfoService();
            _systemService = new SystemService();
        }

        public void OnNavigatedTo(object parameter)
        {
            versionDescriptionText.Text = $"CodeBehindApp - {_applicationInfoService.GetVersion()}";
            var theme = ThemeSelectorService.GetCurrentTheme();
            lightThemeRadioButton.IsChecked = theme == Models.AppTheme.Light;
            darkThemeRadioButton.IsChecked = theme == Models.AppTheme.Dark;
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnPrivacyStatementClick(object sender, RoutedEventArgs e)
            => _systemService.OpenInWebBrowser("https://YourPrivacyUrlGoesHere/");

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement radioButton)
            {
                var theme = (AppTheme)Enum.Parse(typeof(AppTheme), radioButton.Tag.ToString());
                ThemeSelectorService.SetTheme(theme);
            }
        }
    }
}
