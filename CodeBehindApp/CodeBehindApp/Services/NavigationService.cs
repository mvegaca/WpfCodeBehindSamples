using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using CodeBehindApp.Contracts.Views;

namespace CodeBehindApp.Services
{
    public static class NavigationService
    {
        private static Frame _frame;
        private static object _lastParameterUsed;

        public static event EventHandler<Type> Navigated;

        public static bool CanGoBack => _frame.CanGoBack;

        public static void Initialize(Frame shellFrame)
        {
            if (_frame == null)
            {
                _frame = shellFrame;
                _frame.Navigated += OnNavigated;
            }
        }

        public static void UnsubscribeNavigation()
        {
            _frame.Navigated -= OnNavigated;
            _frame = null;
        }

        public static void GoBack()
            => _frame.GoBack();

        public static bool NavigateTo(Type pageType, object parameter = null, bool clearNavigation = false)
        {
            if (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParameterUsed)))
            {
                _frame.Tag = clearNavigation;
                var navigated = _frame.Navigate(Activator.CreateInstance(pageType), parameter);
                if (navigated)
                {
                    _lastParameterUsed = parameter;
                    if (_frame.Content is INavigationAware navigationAware)
                    {
                        navigationAware.OnNavigatedFrom();
                    }
                }

                return navigated;
            }

            return false;
        }

        public static void CleanNavigation()
            => _frame.CleanNavigation();

        private static void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                bool clearNavigation = (bool)frame.Tag;
                if (clearNavigation)
                {
                    frame.CleanNavigation();
                }

                if (frame.Content is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(e.ExtraData);
                }

                Navigated?.Invoke(sender, frame.Content.GetType());
            }
        }
    }
}
