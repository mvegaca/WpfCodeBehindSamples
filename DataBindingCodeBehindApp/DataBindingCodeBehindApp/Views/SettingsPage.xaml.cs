using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DataBindingCodeBehindApp.Contracts.Services;
using DataBindingCodeBehindApp.Contracts.Views;
using DataBindingCodeBehindApp.Models;
using Microsoft.Extensions.Options;

namespace DataBindingCodeBehindApp.Views
{
    public partial class SettingsPage : Page, INotifyPropertyChanged, INavigationAware
    {
        private readonly AppConfig _appConfig;
        private readonly IThemeSelectorService _themeSelectorService;
        private readonly ISystemService _systemService;
        private readonly IApplicationInfoService _applicationInfoService;
        private AppTheme _theme;
        private string _versionDescription;

        public AppTheme Theme
        {
            get { return _theme; }
            set { Set(ref _theme, value); }
        }

        public string VersionDescription
        {
            get { return _versionDescription; }
            set { Set(ref _versionDescription, value); }
        }
        public SettingsPage(IOptions<AppConfig> appConfig, IThemeSelectorService themeSelectorService, ISystemService systemService, IApplicationInfoService applicationInfoService)
        {
            _appConfig = appConfig.Value;
            _themeSelectorService = themeSelectorService;
            _systemService = systemService;
            _applicationInfoService = applicationInfoService;
            InitializeComponent();
            DataContext = this;
        }

        public void OnNavigatedTo(object parameter)
        {
            VersionDescription = $"DataBindingCodeBehindApp - {_applicationInfoService.GetVersion()}";
            Theme = _themeSelectorService.GetCurrentTheme();
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnSetTheme(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement radioButton)
            {
                var theme = (AppTheme)Enum.Parse(typeof(AppTheme), radioButton.Tag.ToString());
                _themeSelectorService.SetTheme(theme);
            }
        }

        private void OnPrivacyStatement(object sender, RoutedEventArgs e)
            => _systemService.OpenInWebBrowser(_appConfig.PrivacyStatement);

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
