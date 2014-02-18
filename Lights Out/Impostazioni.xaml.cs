using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace Lights_Out
{
    public partial class Impostazioni : PhoneApplicationPage
    {

        private bool audio = false;
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        public Impostazioni()
        {
            InitializeComponent();
            if (appSettings.Contains("mossetotali"))
                mossefatte.Text = appSettings["mossetotali"].ToString();
            else { appSettings.Add("mossetotali", "0"); mossefatte.Text = "0"; }
        }

        public int mossetotali;



        private void resetGame_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Resettare tutti i dati di gioco?", "Cancella", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (appSettings.Contains("bestscore" + i))
                    { appSettings["bestscore" + i] = "-"; }
                }
                if (appSettings.Contains("mossetotali"))
                { appSettings["mossetotali"] = "0"; }
                mossefatte.Text = "0";


                MessageBox.Show("Tutti i progressi nel gioco sono stati cancellati.");
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            bool ischecked = false;
            if (appSettings.Contains("audio")) ischecked = (bool)appSettings["audio"];
            AudioCheckBox.IsChecked = ischecked;
        }

        private void Audio(object sender, RoutedEventArgs e)
        {
            if (!audio)
            {
                audio = true;
                if (appSettings.Contains("audio"))
                {
                    appSettings.Remove("audio");
                    appSettings.Add("audio", true);
                }
                else appSettings.Add("audio", true);
            }
            else
            {
                throw new Exception("Audio settato male");
            }
        }

        private void NoAudio(object sender, RoutedEventArgs e)
        {
            if (audio)
            {
                audio = false;
                if (appSettings.Contains("audio"))
                {
                    appSettings.Remove("audio");
                    appSettings.Add("audio", false);
                }
                else appSettings.Add("audio", false);
            }
            else
            {
                throw new Exception("Audio settato male");
            }
        }
    }
}