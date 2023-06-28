using ProjekatGNS.Model;
using System;
using System.Collections.Generic;
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

namespace ProjekatGNS.Windows
{
    /// <summary>
    /// Interaction logic for PrikazUlogovanogKorisnikaWindow.xaml
    /// </summary>
    public partial class PrikazUlogovanogKorisnikaWindow : Window
    {
        Korisnik prijavljen;


        public PrikazUlogovanogKorisnikaWindow(Korisnik korisnik)
        {
            prijavljen = korisnik;

            InitializeComponent();
            if (korisnik.TipKorisnika.Equals(ETipKorisnika.TRENER))
            {
                btnAdmin.Visibility = Visibility.Collapsed;
                btnKlijent.Visibility = Visibility.Collapsed;
                btnVlasnik.Visibility = Visibility.Collapsed;
            }
            else if (korisnik.TipKorisnika.Equals(ETipKorisnika.ADMINISTRATOR))
            {
                btnStart.Visibility = Visibility.Collapsed;
                btnKlijent.Visibility = Visibility.Collapsed;
                btnVlasnik.Visibility = Visibility.Collapsed;
            }
            else if (korisnik.TipKorisnika.Equals(ETipKorisnika.KLIJENT))
            {
                btnStart.Visibility = Visibility.Collapsed;
                btnAdmin.Visibility = Visibility.Collapsed;
                btnVlasnik.Visibility = Visibility.Collapsed;
            }
        }

        private void btnTrener_Click(object sender, RoutedEventArgs e)
        {
            TrenerWindow trenerWindow = new TrenerWindow(prijavljen);
            this.Hide();
            trenerWindow.Show();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow(prijavljen);
            this.Hide();
            adminWindow.Show();


        }

        private void btnKlijent_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow korisnikWindow = new KlijentWindow(prijavljen);
            this.Hide();
            korisnikWindow.Show();


        }
        private void btnVlasnik_Click(object sender, RoutedEventArgs e)
        {
            VlasnikWindow vlasnikWindow = new VlasnikWindow();
            this.Hide();
            vlasnikWindow.Show();


        }
    }
}
