using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VKClient.Common.Framework;

namespace VKClient.Common.UC
{
    public class SettingsSectionUC : UserControl
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(SettingsSectionUC), new PropertyMetadata("", new PropertyChangedCallback(OnIconChanged)));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(SettingsSectionUC), new PropertyMetadata("", new PropertyChangedCallback(OnTitleChanged)));
        internal TextBlock iconBorder;
        internal TextBlock titleBlock;
        private bool _contentLoaded;

        public string Icon
        {
            get
            {
                return (string)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public string Title
        {
            get
            {
                return (string)base.GetValue(SettingsSectionUC.TitleProperty);
            }
            set
            {
                base.SetValue(SettingsSectionUC.TitleProperty, value);
            }
        }

        public SettingsSectionUC()
        {
            //base.\u002Ector();
            this.InitializeComponent();
        }

        private static void OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SettingsSectionUC settingsSectionUc = (SettingsSectionUC)d;
            // ISSUE: explicit reference operation
            string newValue = (string)e.NewValue;
            // ImageBrush imageBrush = new ImageBrush();
            // ImageLoader.SetImageBrushMultiResSource(imageBrush, newValue);
            settingsSectionUc.iconBorder.Text = newValue;
        }

        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // ISSUE: explicit reference operation
            ((SettingsSectionUC)d).titleBlock.Text = ((string)e.NewValue);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (this._contentLoaded)
                return;
            this._contentLoaded = true;
            Application.LoadComponent(this, new Uri("/VKClient.Common;component/UC/SettingsSectionUC.xaml", UriKind.Relative));
            this.iconBorder = (TextBlock)base.FindName("iconBorder");
            this.titleBlock = (TextBlock)base.FindName("titleBlock");
        }
    }
}
