using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace VKClient.Common.Market.Views
{
  public class ProductsTwoInARowUC : UserControl
  {
    private bool _contentLoaded;

    public ProductsTwoInARowUC()
    {
      //base.\u002Ector();
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent(this, new Uri("/VKClient.Common;component/Market/Views/ProductsTwoInARowUC.xaml", UriKind.Relative));
    }
  }
}
