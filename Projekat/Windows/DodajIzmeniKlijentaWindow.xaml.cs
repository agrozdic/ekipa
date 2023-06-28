using ProjekatGNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatGNS.Windows
{
    /// <summary>
    /// Interaction logic for DodajIzmeniKlijentaWindow.xaml
    /// </summary>
    public partial class DodajIzmeniKlijentaWindow : Window

    {
        private Korisnik odabraniKorisnik;
        private EStatus odabraniStatus;
        public DodajIzmeniKlijentaWindow(EStatus status,Korisnik korisnik)
        {
            InitializeComponent();
            odabraniKorisnik = korisnik;
            odabraniStatus = status;

            this.DataContext = korisnik;

            cmbCiljKlijenta.ItemsSource = Enum.GetValues(typeof(ECiljKlijenta));
            //cmbTipKorisnika.ItemsSource = Enum.GetValues(typeof(ETipKorisnika));
            foreach (ETipKorisnika temp in Enum.GetValues(typeof(ETipKorisnika)))
            {
                if (temp == ETipKorisnika.KLIJENT || temp == ETipKorisnika.TRENER)
                {
                    cmbTipKorisnika.Items.Add(temp);
                }

            }





            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj klijenta";
            }
            else
            {
                txtEmail.IsEnabled = false;
                this.Title = "Izmeni klijenta";
            }
        }
        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            if (odabraniStatus.Equals(EStatus.DODAJ))
            {
                if (odabraniKorisnik.TipKorisnika.Equals(ETipKorisnika.KLIJENT))
                {
                    odabraniKorisnik.Aktivan = true;

                    Klijent klijent = new Klijent
                    {
                        Korisnik = odabraniKorisnik
                    };
                    Main.Instance.Korisnici.Add(odabraniKorisnik);
                    Main.Instance.Klijenti.Add(klijent);
                    Main.Instance.SacuvajEntitet("klijenti.txt");

                }
                else if (odabraniKorisnik.TipKorisnika.Equals(ETipKorisnika.TRENER))
                {
                    odabraniKorisnik.Aktivan = true;
                    Trener trener = new Trener
                    {
                        Korisnik = odabraniKorisnik

                    };

                    Main.Instance.Korisnici.Add(odabraniKorisnik);
                    Main.Instance.Treneri.Add(trener);
                    Main.Instance.SacuvajEntitet("treneri.txt");

                }
                else
                {
                    odabraniKorisnik.Aktivan = true;
                    Main.Instance.Korisnici.Add(odabraniKorisnik);
                }
            }

            Main.Instance.SacuvajEntitet("korisnici.txt");

            this.DialogResult = true;
            this.Close();
        }

        private void cmbTipKorisnika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipKorisnika.SelectedItem.ToString() == "TRENER")
            {
                lblCiljKlijenta.Visibility = Visibility.Hidden;
                cmbCiljKlijenta.Visibility = Visibility.Hidden;
            }
            else
            {
                lblCiljKlijenta.Visibility = Visibility.Visible;
                cmbCiljKlijenta.Visibility = Visibility.Visible;
            }
            
        }
    }
}

