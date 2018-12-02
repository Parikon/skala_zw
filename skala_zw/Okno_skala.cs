using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace skala_zw
{
    public partial class  Okno_skala : Window
    {
        public Okno_skala(int widht, int heigt)
        {
            this.Title = "PI 2019";
            this.Width = widht;
            this.Height = heigt;
            this.MinWidth = widht;
            this.MinHeight = heigt;
            this.MaxWidth = widht;
            this.MaxHeight = heigt;
            UserControl1_skala mojakontrolka = new UserControl1_skala();
            this.AddChild(mojakontrolka);
            this.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            this.VerticalContentAlignment = VerticalAlignment.Stretch;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            Thickness thickness = new System.Windows.Thickness();
            thickness.Top = 0;
            thickness.Left = 0;
            thickness.Right = 0;
            thickness.Bottom = 0;
            this.BorderThickness = thickness;
            this.Topmost = true;
        }
    }
}
