﻿using GymManager3.MobileApp.Views;
using GymManager3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GymManager3.MobileApp.ViewModels
{
    public class PolaznikMojeUplateVM
    {
        private readonly APIService _service =new APIService("Uplate");
        public PolaznikMojeUplateVM()
        {

        }

        public PolaznikMojeUplateVM(int polaznikId, List<uplate> lista)
        {
            Load(polaznikId, lista);

            Nazad_Command = new Command(() =>
            {
                Application.Current.MainPage = new PolaznikMainPage(polaznikId);
            });
        }

        public List<uplate> listaUplata { get; set; } = new List<uplate>();

        public ICommand Nazad_Command { get; set; }

        public void Load(int userId,  List<uplate> lista)
        {
            foreach (var x in lista)
            {
                if (x.PolaznikId == userId)
                {
                    listaUplata.Add(new uplate
                    {
                        AdministracijaId = x.AdministracijaId,
                        DatumUplate = x.DatumUplate,
                        Evidentirao = x.Evidentirao,
                        Iznos = x.Iznos,
                        PolaznikId=x.PolaznikId,
                        Svrha = x.Svrha,
                        UplataId = x.UplataId,
                        Uplatio = x.Uplatio
                    });
                }
            }
        }
    }
}
