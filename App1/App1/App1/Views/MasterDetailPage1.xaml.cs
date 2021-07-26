using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetailPage1 : MasterDetailPage
    {

        public List<MasterPageItem> menuList
        {
            get;
            set;
        }

        public MasterDetailPage1 ()
		{
			InitializeComponent ();
            //    NavigationPage.SetHasNavigationBar(this, false);
            //    Detail = new NavigationPage(new TabbedPage1());
            //    IsPresented = false;
            //}

            //private void Kullanici_BTN_Clicked(object sender, System.EventArgs e)
            //{
            //    Detail = new NavigationPage(new User());
            //    IsPresented = false;
            //}
            //private void Fatura_BTN_Clicked(object sender, System.EventArgs e)
            //{
            //    Detail = new NavigationPage(new FaturaPage());
            //    IsPresented = false;
            //}

            menuList = new List<MasterPageItem>();
            // Adding menu items to menuList and you can define title ,page and icon  
            menuList.Add(new MasterPageItem()
            {
                Title = "Ana Sayfa",
                Icon = "baseline_home_black_24.png",
                TargetType = typeof(TabbedPage1)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Kullanıcı",
                Icon = "baseline_account_box_black_24.png",
                TargetType = typeof(User)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Faturalar",
                Icon = "baseline_archive_black_24.png",
                TargetType = typeof(FaturaPage)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Ayarlar",
                Icon = "baseline_settings_black_24.png",
                TargetType = typeof(AyarlarPage)
            });
            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page  
            
            TabPage2 page2 = new TabPage2();
            

            MessagingCenter.Subscribe<TabPage2, string>(this, "MyCommandName", (sender, arg) => {
                set_name(arg);
            });

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TabbedPage1)));
            
        }
        public void set_name(string name)
        {
            user_txt.Text = name;
        }
        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}