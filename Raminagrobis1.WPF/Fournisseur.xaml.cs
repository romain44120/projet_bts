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
    /// Logique d'interaction pour Fournisseur.xaml
    /// </summary>
    public partial class Fournisseur : Page
    {
        public Fournisseur()
        {
            InitializeComponent();
            fetchFournisseurs();
        }
        private async void fetchFournisseurs()
        {
            var clientApi = new Client("https://localhost:44362/", new HttpClient());
            var fournisseurs = await clientApi.AllFounrisseursAsync();

            listFournisseurs.ItemsSource = fournisseurs;
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e) //todo refresh list after update
        {
            if (listFournisseurs.SelectedItem != null)
            {
                var clientApi = new Client("https://localhost:44362/", new HttpClient());
                Fournisseur_DTO fournisseur = (Fournisseur_DTO)listFournisseurs.SelectedItem;
                clientApi.FournisseurPUTAsync(fournisseur);
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
           if (listFournisseurs.SelectedItem != null)
           {
                var clientApi = new Client("https://localhost:44362/", new HttpClient());
                Fournisseur_DTO fournisseur = (Fournisseur_DTO)listFournisseurs.SelectedItem;
                clientApi.FournisseurDELETEAsync(fournisseur.Id);
           }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44362/", new HttpClient());

            var fournisseur = new Fournisseur_DTO()
            {
                Nom = inputLastName.Text,
                Prenom = inputFirstName.Text,
                Adresse = inputAddress.Text,
                Societe = inputCompany.Text,
                Email = inputEmail.Text,
                Civilite = inputCivility.IsEnabled,
                Status = inputActive.IsEnabled,
            };

            clientApi.FournisseurPOSTAsync(fournisseur);
        }
    }
}
