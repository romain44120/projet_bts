﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Raminagrobis.API.Client;


namespace Raminagrobis1.WPF
{
    /// <summary>
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    public partial class Panier : Page
    {
        public Panier()
        {
            InitializeComponent();
            fecthAdherents();
            fetchFournisseurs();

            semaine.Text = "Semaine N° " + (getWeek(DateTime.Now) + 1).ToString() + "-22"; 
            semaine1.Text = "Semaine N° " + (getWeek(DateTime.Now) + 1).ToString() + "-22";
        }
        private async void fecthAdherents()
        {
            var clientApi = new Client("https://localhost:44362/", new HttpClient());
            var adherents = await clientApi.AllAdherentsAsync();

            listAdherents.ItemsSource = adherents;
        }

        private async void fetchFournisseurs()
        {
            var clientApi = new Client("https://localhost:44362/", new HttpClient());
            var fournisseurs = await clientApi.AllFounrisseursAsync();

            listFournisseurs.ItemsSource = fournisseurs;
        }

        public int getWeek(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private async void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            Adherent_DTO adherent = (Adherent_DTO)listAdherents.SelectedItem;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true && adherent != null)
            {
                var clientApi = new Client("https://localhost:44362/", new HttpClient());
               
                var panierAdherent = await clientApi.PanierAdherentPOSTAsync(new Panier_Adherent_DTO()
                {
                    Semaine = (getWeek(DateTime.Now) + 1).ToString(),
                    ID_ADHERENT = adherent.Id,
                });

                var panierCSV = File.ReadAllText(openFileDialog.FileName).Split(new[] { '\r', '\n' });

                for (var i = 1; i < panierCSV.Length - 1; i++)
                {
                    var panierAdherentDetail = panierCSV[i].Split(";");

                    try
                    {
                        var reference = await clientApi.GetByReferenceAsync(panierAdherentDetail[0]);

                        await clientApi.PanierAdherentDetailPOSTAsync(new Panier_Adherent_Details_DTO()
                        {
                            ID_REFERENCE = reference.Id,
                            Quantite = Int32.Parse(panierAdherentDetail[1]),
                            ID_PANIER_ADHERENT = panierAdherent.Id,
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                    
                }

            }
            else if (adherent == null) MessageBox.Show("Vous devez choisir un adhérent.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private async void btnDownloadGlobalCart(object sender, RoutedEventArgs e)
        {
            var semaine = (getWeek(DateTime.Now) + 1).ToString();
            var clientApi = new Client("https://localhost:44362/", new HttpClient());
            var panierGLobal = await clientApi.PanierGlobalPOSTAsync(new Panier_Global_DTO()
            {
                Semaine = semaine
            });

            var panierAdherents = await clientApi.AllFournisseursAsync();
            var panierAdherentsDetail = await clientApi.AllPaniersAdherentAsync();
            var panierAdherentsFiltered = panierAdherents.Where(panier => panier.Semaine == semaine).ToList();

            List<Panier_Adherent_Details_DTO> panierAdherentsDetailFiltered = new List<Panier_Adherent_Details_DTO>();

            foreach (Panier_Adherent_DTO panierAdherent in panierAdherentsFiltered)
            {
                panierAdherentsDetailFiltered.AddRange(panierAdherentsDetail.Where(panier => panier.ID_PANIER_ADHERENT == panierAdherent.Id).ToList());
            }

            //pour additioner les quantités
            var tmp = panierAdherentsDetailFiltered.GroupBy(i => new { i.Id, i.ID_REFERENCE }).Select(g => new
            {
                Id = g.Key.Id,
                ID_REFERENCE = g.Key.ID_REFERENCE,
                QUANTITE = g.Sum(i => i.Quantite)
               
            }).ToList();

            for(var i = 0; i < tmp.Count; i++)
            {
                await clientApi.PanierGlobalDetailPOSTAsync(new Panier_Global_Details_DTO() {
                
                    ID_REFERENCE = tmp[i].ID_REFERENCE,
                    QuantitE_GLOBAL = tmp[i].QUANTITE,
                ID_PANIER_GLOBAL = panierGLobal.Id
                });
            }

            SaveFileDialog exportDialog = new SaveFileDialog();
            
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\r0main\\Desktop\\panierGlobal.csv");
                sw.Write("reference;quantite;prix unitaire HT\n");

                for (var i = 0; i < tmp.Count; i++)
                {
                    var reference = await clientApi.ReferenceGETAsync(tmp[i].ID_REFERENCE);

                    sw.Write($"{reference.Reference};{tmp[i].QUANTITE};0\n");
                }

                sw.Close();
                Process.Start("C:\\Users\\r0main\\Desktop\\panierGlobal.csv");
            }
            catch (Exception ex)
            { }
        }

        private async void btnDownloadFounirsseurCart(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44362/", new HttpClient());

            //on trouve le panier global actif (moche mais pas d'autre choix dans la couche visuelle WPF)
            var allPaniersGlobaux = await clientApi.AllPanierGlobalAsync();
            var panierGlobal = allPaniersGlobaux.Last();

            var panierGlobalDetail = await clientApi.GetGlobalDetailByPanierAsync(panierGlobal.Id);
           
            //on récupère les produits proposés par le fournisseur
            Fournisseur_DTO fournisseur = (Fournisseur_DTO)listFournisseurs.SelectedItem;
            var listReferenceDetail = await clientApi.GetReferenceDetailsByFournisseurAsync(fournisseur.Id);

            try
            {
                StreamWriter sw = new StreamWriter($"C:\\Users\\r0main\\Desktop\\{fournisseur.Societe}_puht_vide.csv");
                sw.Write("reference;quantite;prix unitaire HT\n");

                foreach (Panier_Global_Details_DTO referencePanier in panierGlobalDetail)
                {
                    //si la reference du panier global est proposé par le fournisseur sélectionné
                    if (listReferenceDetail.FirstOrDefault(referenceDetail => referenceDetail.ID_REFERENCE == referencePanier.ID_REFERENCE) != null)
                    {
                        var reference = await clientApi.ReferenceGETAsync(referencePanier.ID_REFERENCE);
                        sw.Write($"{reference.Reference};{referencePanier.QuantitE_GLOBAL};0\n");
                    }
                }
                sw.Close();

            }
            catch (Exception)
            { }
        }

        private async void btnUploadFounirsseurCart(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44362/", new HttpClient());
            Fournisseur_DTO fournisseur = (Fournisseur_DTO)listFournisseurs.SelectedItem;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true && fournisseur != null)
            {
                var allPaniersGlobaux = await clientApi.AllPanierGlobalAsync();
                var panierGlobal = allPaniersGlobaux.Last();
                var listPanierGlobalDetail = await clientApi.GetGlobalDetailByPanierAsync(panierGlobal.Id);
                
                var offresFournisseurCSV = File.ReadAllText(openFileDialog.FileName).Split(new[] { '\r', '\n' });
                
                //pour le format de l'offre (parse string to float with dot)
                CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.CurrencyDecimalSeparator = ".";

                for (var i = 1; i < offresFournisseurCSV.Length - 1; i++)
                {
                    var offre = offresFournisseurCSV[i].Split(";");
                    Console.WriteLine("test");

                    if (offre.Length > 1 &&  offre[2] != "0")
                    {
                        var reference = await clientApi.GetByReferenceAsync(offre[0]);
                        var reference_PanierGlobalDetail = listPanierGlobalDetail.FirstOrDefault(referenceDetail => referenceDetail.ID_REFERENCE == reference.Id);

                        await clientApi.OffreFournisseurPOSTAsync(new Offres_Fournisseurs_DTO()
                        {
                            Offres = float.Parse(offre[2], NumberStyles.Any, ci),
                            ID_FOURNISSEURS = fournisseur.Id,
                            ID_PANIER_GLOBALS_DETAILS = reference_PanierGlobalDetail.Id,
                        });
                    }

                }
            }
            
            else if (fournisseur == null) MessageBox.Show("Vous devez choisir un fournisseur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private async void btnDownloadFinalCart(object sender, RoutedEventArgs e)
        {
            var semaine = (getWeek(DateTime.Now) + 1).ToString();
            var clientApi = new Client("https://localhost:44362/", new HttpClient());

            var listPanierGlobal = await clientApi.AllPanierGlobalAsync();
            var panierGlobal = listPanierGlobal.FirstOrDefault(panier => panier.Semaine == semaine);

            var listPanierGlobalDetails = await clientApi.GetGlobalDetailByPanierAsync(panierGlobal.Id);

            var listOffresFournisseurs = await clientApi.AllOffresFournisseursAsync();

            StreamWriter sw = new StreamWriter("C:\\Users\\r0main\\Desktop\\panierFinal.csv");
            sw.Write("reference;quantite;prix unitaire HT;fournisseur\n");

            foreach (Panier_Global_Details_DTO panierGlobalDetail in listPanierGlobalDetails)
            {
                var offresFournisseursMatch = listOffresFournisseurs.Where(offreF => offreF.ID_PANIER_GLOBALS_DETAILS == panierGlobalDetail.Id).ToList();

                if (offresFournisseursMatch.Count() >= 1)
                {
                    var bestOffre = offresFournisseursMatch.OrderBy(offre => offre.Offres).First();

                    var reference = await clientApi.ReferenceGETAsync(panierGlobalDetail.ID_REFERENCE);
                    var fournisseur = await clientApi.FournisseurGETAsync(bestOffre.ID_FOURNISSEURS);

                    sw.Write($"{reference.Reference};{panierGlobalDetail.QuantitE_GLOBAL};{Math.Truncate(bestOffre.Offres * 1000) / 1000};{fournisseur.Societe}\n");

                }
            }
            sw.Close();


        }
    }
}
