using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabbedPage1 : TabbedPage
    {
		public TabbedPage1 ()
		{
			InitializeComponent ();
        }

        private void Settings_Btn_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Ayarlar", "Ayarlar Formu", "Ok");
        }

        private void Map_Btn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}