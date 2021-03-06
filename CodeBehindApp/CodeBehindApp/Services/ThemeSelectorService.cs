﻿using System;
using System.Windows;
using CodeBehindApp.Models;

using ControlzEx.Theming;

using Microsoft.Win32;

namespace CodeBehindApp.Services
{
    public static class ThemeSelectorService
    {
        private static bool IsHighContrastActive
                        => SystemParameters.HighContrast;

        static ThemeSelectorService()
        {
            SystemEvents.UserPreferenceChanging += OnUserPreferenceChanging;
        }

        public static bool SetTheme(AppTheme? theme = null)
        {
            if (IsHighContrastActive)
            {
                // TODO WTS: Set high contrast theme
                // You can add custom themes following the docs on https://mahapps.com/docs/themes/thememanager
            }
            else if (theme == null)
            {
                if (App.Current.Properties.Contains("Theme"))
                {
                    // Read saved theme from properties
                    var themeName = App.Current.Properties["Theme"].ToString();
                    theme = (AppTheme)Enum.Parse(typeof(AppTheme), themeName);
                }
                else
                {
                    // Set default theme
                    theme = AppTheme.Light;
                }
            }

            var currentTheme = ThemeManager.Current.DetectTheme(Application.Current);
            if (currentTheme == null || currentTheme.Name != theme.ToString())
            {
                ThemeManager.Current.ChangeTheme(Application.Current, $"{theme}.Blue");
                App.Current.Properties["Theme"] = theme.ToString();
                return true;
            }

            return false;
        }

        public static AppTheme GetCurrentTheme()
        {
            var themeName = App.Current.Properties["Theme"]?.ToString();
            Enum.TryParse(themeName, out AppTheme theme);
            return theme;
        }

        private static void OnUserPreferenceChanging(object sender, UserPreferenceChangingEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.Color ||
                e.Category == UserPreferenceCategory.VisualStyle)
            {
                SetTheme();
            }
        }
    }
}
