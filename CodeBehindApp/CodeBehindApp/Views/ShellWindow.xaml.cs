using System;
using System.Linq;
using System.Windows.Controls;
using CodeBehindApp.Services;

using MahApps.Metro.Controls;

namespace CodeBehindApp.Views
{
    public partial class ShellWindow : MetroWindow
    {
        public ShellWindow()
        {
            InitializeComponent();            
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            hamburgerMenu.Items.Add(new HamburgerMenuGlyphItem() { Label = Properties.Resources.ShellMainPage, Glyph = "\uE8A5", TargetPageType = typeof(MainPage) });
            hamburgerMenu.Items.Add(new HamburgerMenuGlyphItem() { Label = Properties.Resources.ShellMasterDetailPage, Glyph = "\uE8A5", TargetPageType = typeof(MasterDetailPage) });
            hamburgerMenu.OptionsItems.Add(new HamburgerMenuGlyphItem() { Label = Properties.Resources.ShellSettingsPage, Glyph = "\uE713", TargetPageType = typeof(SettingsPage) });
            NavigationService.Navigated += OnNavigated;
        }

        private void OnUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigated -= OnNavigated;
        }

        private void OnNavigated(object sender, Type pageType)
        {
            var item = hamburgerMenu.Items
                        .OfType<HamburgerMenuItem>()
                        .FirstOrDefault(i => pageType == i.TargetPageType);
            if (item != null)
            {
                hamburgerMenu.SelectedItem = item;
            }
            else
            {
                hamburgerMenu.SelectedOptionsItem = hamburgerMenu.OptionsItems
                        .OfType<HamburgerMenuItem>()
                        .FirstOrDefault(i => pageType == i.TargetPageType);
            }

            goBackButton.IsEnabled = NavigationService.CanGoBack;
        }

        private void OnGoBack(object sender, System.Windows.RoutedEventArgs e)
            => NavigationService.GoBack();

        private void OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs args)
        {
            if (args.InvokedItem is HamburgerMenuItem hamburgerMenuItem)
            {
                NavigationService.NavigateTo(hamburgerMenuItem.TargetPageType);
            }
        }
    }
}
