using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Raminagrobis.API.Client;

namespace Raminagrobis1.WPF
{
    /// <summary>
    /// Logique d'interaction pour References.xaml
    /// </summary>
    public partial class References : Page
    {
        public References()
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

        private async void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            Fournisseur_DTO fournisseur = (Fournisseur_DTO)listFournisseurs.SelectedItem;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true && fournisseur != null)
            {
                var clientApi = new Client("https://localhost:44362/", new HttpClient());

                var referencesCSV = File.ReadAllText(openFileDialog.FileName).Split(new[] { '\r', '\n' });

                await clientApi.ImportCSVAsync(fournisseur.Id, referencesCSV);
            }
            else if (fournisseur == null) MessageBox.Show("Vous devez choisir un fournisseur.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

        }
    }
}
