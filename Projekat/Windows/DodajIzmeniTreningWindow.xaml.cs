using Projekat.Models;
using Projekat.services;
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

namespace Projekat.Windows
{
    /// <summary>
    /// Interaction logic for DodajIzmeniTreningWindow.xaml
    /// </summary>
    public partial class DodajIzmeniTreningWindow : Window
    {
        private EStatus odabraniStatus;
        private Trening odabraniTrening;
        RegistrovaniKorisnik registrovaniKorisnik;
        public DodajIzmeniTreningWindow(EStatus status, Trening trening, RegistrovaniKorisnik korisnik)
        {
            InitializeComponent();
            ComboStatusTreninga.ItemsSource = Enum.GetValues(typeof(EStatusTreninga)).Cast<EStatusTreninga>();
            ComboStatusTreninga.IsEnabled = false;
            odabraniStatus = status;
            odabraniTrening = trening;
            this.DataContext = trening;
            registrovaniKorisnik = korisnik;

            foreach (Trener trener in Main.Instance.Treneri)
            {
                /*if (Korisnik.TipKorisnika.Equals(ETipKorisnika.ADMINISTRATOR))
                {
                    if (trener.Korisnik.Aktivan)
                    {
                        ComboTipTreneri.Items.Add(trener);
                    }
                }
                else if (Korisnik.TipKorisnika.Equals(ETipKorisnika.TRENER))
                {
                    if (trener.Korisnik.Aktivan && trener.Korisnik.Email.Equals(Korisnik.Email))
                    {
                        ComboTipTreneri.Items.Add(trener);
                    }
                }*/
                if (trener.Korisnik.Aktivan)
                {
                    ComboTipTreneri.Items.Add(trener.Korisnik.Email);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (odabraniStatus.Equals(EStatus.DODAJ))

            {
                KlijentService klijentService = new KlijentService();
                odabraniTrening = new Trening();
                odabraniTrening.Aktivan = true;
                //odabraniTrening.Klijent = klijentService.NadjiKlijentaPrekoEmaila("xxxxx");
                //odabraniTrening.Trener = (Trener)ComboTipTreneri.SelectedValue;
                odabraniTrening.Klijent = null;
                Trener temp = new Trener();
                foreach(Trener t in Main.Instance.Treneri)
                {
                    if(t.Korisnik.Email == ComboTipTreneri.SelectedItem.ToString())
                    {
                        temp = t;
                        break;
                    }
                }
                odabraniTrening.Trener = temp;
                odabraniTrening.Sifra = Convert.ToInt32(txtSifra.Text);
                odabraniTrening.Datum = DateTime.Now;
                odabraniTrening.TrajanjeTreninga = Convert.ToInt32(txtTrajanjeTreninga.Text);
                odabraniTrening.StatusTreninga = EStatusTreninga.SLOBODAN;
                Main.Instance.Treninzi.Add(odabraniTrening);
                Main.Instance.SacuvajEntitet("treninzi.txt");

            }       
            this.DialogResult = true;
            this.Close();

        }
    }
}
