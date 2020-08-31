using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GymManager3.MobileApp.Models;

namespace GymManager3.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Polaznici:
                        MenuPages.Add(id, new NavigationPage(new PolazniciPage()));
                        break;
                    case (int)MenuItemType.Administracija:
                        MenuPages.Add(id, new NavigationPage(new AdministracijaPage()));
                        break;
                    case (int)MenuItemType.Treneri:
                        MenuPages.Add(id, new NavigationPage(new TreneriPage()));
                        break;
                    case (int)MenuItemType.Treninzi:
                        MenuPages.Add(id, new NavigationPage(new TreninziPage()));
                        break;
                    case (int)MenuItemType.Uplate:
                        MenuPages.Add(id, new NavigationPage(new UplatePage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}