using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace Classroom
{
    public class BaseWindow : MetroWindow
    {
        public BaseWindow()
        {
            SetParentWindowStyle();
            PreviewKeyDown += BaseWindow_PreviewKeyDown;
        }

        private void BaseWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Close();
                    break;
            }
        }

        public bool IsSubWindow
        {
            get { return (bool) GetValue(IsSubWindowProperty); }
            set { SetValue(IsSubWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSubWindowProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSubWindowProperty =
            DependencyProperty.Register("IsSubWindow", typeof(bool), typeof(BaseWindow),
                new PropertyMetadata(false, OnIsSubWindowPropertyChangedCallback));

        private static void OnIsSubWindowPropertyChangedCallback(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                var window = (BaseWindow) d;
                if ((bool) e.NewValue)
                {
                    window.SetSubWindowStyle();
                }
                else
                {
                    window.SetParentWindowStyle();
                }
            }
        }

        private void SetCommonWindowStyle()
        {
            FontFamily = new FontFamily("Microsoft YaHei");
            ResizeMode = ResizeMode.NoResize;
            Topmost = true;
            UseNoneWindowStyle = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void SetSubWindowStyle()
        {
            SetCommonWindowStyle();

            ShowInTaskbar = false;
            IgnoreTaskbarOnMaximize = false;
            WindowState = WindowState.Normal;
        }

        private void SetParentWindowStyle()
        {
            SetCommonWindowStyle();

            IgnoreTaskbarOnMaximize = true;
            WindowState = WindowState.Maximized;
        }
    }
}