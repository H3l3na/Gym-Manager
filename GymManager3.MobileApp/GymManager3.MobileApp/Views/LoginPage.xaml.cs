﻿using GymManager3.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymManager3.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel model = null;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = model = new LoginViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ///await model.Init();
        }
    }
}