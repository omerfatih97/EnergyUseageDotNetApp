using Newtonsoft.Json;
using Syncfusion.XForms.ProgressBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.DataVisualization.Gauges;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Btn_Clicked(object sender, EventArgs e)
        {
            bar.Value = 80;
            bar.GradientStops.Clear();
            bar.GradientStops.Add(new RadGradientStop { Color = Color.Yellow, Offset = 25 });
            bar.GradientStops.Add(new RadGradientStop { Color = Color.Red, Offset = 50 });
        }

        //private void Guncelle_BTN_Clicked(object sender, EventArgs e)
        //{
        //    /* RangeColorCollection rangeColors = new RangeColorCollection();

        //     rangeColors.Add(new RangeColor() { Color = Color.FromHex("00bdaf"), Start = 0, End = 25 });

        //     rangeColors.Add(new RangeColor() { Color = Color.FromHex("2f7ecc"), Start = 25, End = 80 });

        //     rangeColors.Add(new RangeColor() { Color = Color.FromHex("e9648e"), Start = 80, End = 90});

        //     rangeColors.Add(new RangeColor() { Color = Color.FromHex("fbb78a"), Start = 90, End = 100 });

        //     progressBar1.RangeColors = rangeColors;*/
        //    RangeColorCollection rangeColors = new RangeColorCollection();

        //    rangeColors.Add(new RangeColor()
        //    {
        //        Color = Color.FromHex("88A0D9EF"),
        //        IsGradient = true,
        //        Start = 0,
        //        End = 25
        //    });
        //    rangeColors.Add(new RangeColor()
        //    {
        //        Color = Color.FromHex("AA62C1E5"),
        //        IsGradient = true,
        //        Start = 25,
        //        End = 50
        //    });
        //    rangeColors.Add(new RangeColor()
        //    {
        //        Color = Color.FromHex("DD20A7DB"),
        //        IsGradient = true,
        //        Start = 50,
        //        End = 75
        //    });
        //    rangeColors.Add(new RangeColor()
        //    {
        //        Color = Color.FromHex("FF1C96C5"),
        //        IsGradient = true,
        //        Start = 75,
        //        End = 100
        //    });

        //    progressBar1.RangeColors = rangeColors;

        //    Grid grid = new Grid();

        //    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3, GridUnitType.Star) });

        //    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

        //    Label label = new Label();

        //    label.BindingContext = progressBar1;

        //    Binding binding = new Binding();

        //    binding.Path = "Progress";

        //    binding.StringFormat = "60%\nused";

        //    label.SetBinding(Label.TextProperty, binding);

        //    label.HorizontalTextAlignment = TextAlignment.Center;

        //    label.VerticalOptions = LayoutOptions.End;

        //    label.FontSize = 10;

        //    label.TextColor = Color.FromHex("007cee");

        //    Grid.SetRow(label, 0);

        //    grid.Children.Add(label);

        //    progressBar1.Content = grid; 

        //}
    }
}
