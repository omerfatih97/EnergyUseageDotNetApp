using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
            UpdateMap();

        }
        List<Place> placesList = new List<Place>();
        private async void UpdateMap()
        {
            try
            {
                placesList.Add(new Place
                {
                    PlaceName = "CodeBase Burada",
                    Address = "adres1",
                    Position = new Position(39.877171, 32.746860),
                });
                placesList.Add(new Place
                {
                    PlaceName = "CodeBase Burada",
                    Address = "adres2",
                    Position = new Position(39.949279, 32.603858),
                });
                placesList.Add(new Place
                {
                    PlaceName = "CodeBase Burada",
                    Address = "adres3",
                    Position = new Position(39.961794, 32.866136),
                });
            }
            catch(Exception e) { }

            MyMap.ItemsSource = placesList;
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(39.933288, 32.859813), Distance.FromKilometers(25)));
        }
	}
}