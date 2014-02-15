using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.Windows;

namespace Lights_Out
{
    public partial class altro : PhoneApplicationPage
    {
        // VAR: Isolate storage per salvare/caricare
        private IsolatedStorageSettings appSettings;
        public altro()
        {
            
            appSettings = IsolatedStorageSettings.ApplicationSettings;
            InitializeComponent();
            if (appSettings.Contains("mossetotali"))
                mossefatte.Text = appSettings["mossetotali"].ToString();
            else { appSettings.Add("mossetotali", "0");  mossefatte.Text = "0"; }
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
    }
}