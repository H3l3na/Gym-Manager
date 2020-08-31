using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager3.MobileApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About, 
        Polaznici,
        Administracija,
        Treneri,
        Treninzi,
        Uplate
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
