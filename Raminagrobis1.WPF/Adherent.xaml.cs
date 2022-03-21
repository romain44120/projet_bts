using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Raminagrobis.API.Client;

namespace Raminagrobis1.WPF
{
    /// <summary>
    /// Logique d'interaction pour Adherent.xaml
    /// </summary>
    public partial class Adherent : Page
    {
        public Adherent()
        {
            InitializeComponent();
            fetchAdherents();
        }

        private async void fetchAdherents()
        {
            var clientApi = new Client("https://localhost:44362/", new HttpClient());
            var adherents = await clientApi.AllAdherentsAsync();

            listAdherents.ItemsSource = adherents;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e) //todo refresh list after update
        {
            if (listAdherents.SelectedItem != null)
            {
                var clientApi = new Client("https://localhost:44362/", new HttpClient());
                Adherent_DTO adherent = (Adherent_DTO)listAdherents.SelectedItem;
                clientApi.AdherentPUTAsync(adherent);
                
         
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listAdherents.SelectedItem != null)
            {
                Adherent_DTO adherent = (Adherent_DTO)listAdherents.SelectedItem;            
                var clientApi = new Client("https://localhost:44362/", new HttpClient());
                clientApi.AdherentDELETEAsync(adherent.Id);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44362/", new HttpClient());

            var adherent = new Adherent_DTO()
            {
                Nom = inputLastName.Text,
                Prenom = inputFirstName.Text,
                Adresse = inputAddress.Text,
                Societe = inputCompany.Text,
                Email = inputEmail.Text,
                Civilite = false,
                Status = inputActive.IsEnabled,
                Dateadhesion = DateTime.Now
            };

            clientApi.AdherentPOSTAsync(adherent);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
