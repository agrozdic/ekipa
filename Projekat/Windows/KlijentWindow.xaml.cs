using Projekat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat.Windows
{
    /// <summary>
    /// Interaction logic for KlijentWindow.xaml
    /// </summary>
    public partial class KlijentWindow : Window
    {
        ICollectionView view;
        RegistrovaniKorisnik registrovaniKorisnik;

        public KlijentWindow(RegistrovaniKorisnik korisnik)
        {
            InitializeComponent();
            registrovaniKorisnik = korisnik;
        }

        private void btnPrikazTrenera_Click(object sender, RoutedEventArgs e)
        {
            PrikazTreneraWindow prikazTreneraWindow = new PrikazTreneraWindow();
            this.Hide();
            prikazTreneraWindow.Show();

        }



        private void btnSlobodniTermini_Click(object sender, RoutedEventArgs e)
        {

            ZakazivanjeTerminaWindow treninziWindow = new ZakazivanjeTerminaWindow(registrovaniKorisnik);
            treninziWindow.btnDodajNoviTermin.Visibility = Visibility.Collapsed;
            treninziWindow.btnObrisiTermin.Visibility = Visibility.Collapsed;
            this.Hide();
            treninziWindow.Show();

        }

        private void btnMojiTermini_Click(object sender, RoutedEventArgs e)
        {
            MojiTerminiWindow mojiTerminiWindow = new MojiTerminiWindow(registrovaniKorisnik);
            this.Hide();
            mojiTerminiWindow.Show();


        }

        private void bntOdjava_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();

        }

    }
}
