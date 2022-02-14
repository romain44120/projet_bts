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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnClickAdherents(object sender, RoutedEventArgs e)
        {
            Main.Content = new Adherent();
        }
        private async void BtnClickFournisseurs(object sender, RoutedEventArgs e)
        {
            Main.Content = new Fournisseur();
        }

        private void BtnClickReferences(object sender, RoutedEventArgs e)
        {
            Main.Content = new References();
        }

        private void BtnClickPanier(object sender, RoutedEventArgs e)
        {
            Main.Content = new Panier();
        }
    }
}
