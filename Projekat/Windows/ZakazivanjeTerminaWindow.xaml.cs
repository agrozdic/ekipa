using ProjekatGNS.Model;
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

namespace ProjekatGNS.Windows
{
    /// <summary>
    /// Interaction logic for ZakazivanjeTerminaWindow.xaml
    /// </summary>
    public partial class ZakazivanjeTerminaWindow : Window
    {
        ICollectionView view;
        private EStatusTreninga odabraniStatusTreninga;
        private Korisnik Korisnik;

        public ZakazivanjeTerminaWindow(Korisnik korisnik)
        {
            InitializeComponent();
            UpdateView();
            Korisnik = korisnik;
            view.Filter = CustomFilter;

            if (!Korisnik.TipKorisnika.Equals(ETipKorisnika.TRENER))
            {
                btnPregledPolaznika.Visibility = Visibility.Collapsed;
            }


        }

        private bool CustomFilter(object obj)
        {
            Trening trening = obj as Trening;
            if (trening.Aktivan)
            {

                if (odabraniStatusTreninga.Equals(EStatusTreninga.SLOBODAN) && Korisnik.TipKorisnika.Equals(ETipKorisnika.KLIJENT))
                {
                    return trening.StatusTreninga.Equals(EStatusTreninga.SLOBODAN);

                }
                else if (Korisnik.TipKorisnika.Equals(ETipKorisnika.ADMINISTRATOR))
                {
                    return true;
                }
                else if (Korisnik.TipKorisnika.Equals(ETipKorisnika.TRENER))
                {
                    //return trening.Trener.Korisnik.Email.Equals(Korisnik.Email);
                    return true;
                    
                }

            }
            return false;



        }
        private void DGTreninzi_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {


        }
        private void UpdateView()
        {
            DGTreninzi.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Main.Instance.Treninzi);
            DGTreninzi.ItemsSource = view;
            DGTreninzi.IsSynchronizedWithCurrentItem = true;

            DGTreninzi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private void btnDodajTermin_Click(object sender, RoutedEventArgs e)
        {

            Trening trening = new Trening();
            DodajIzmeniTreningWindow dodajIzmeniTrening = new DodajIzmeniTreningWindow(EStatus.DODAJ, trening, Korisnik);
            this.Hide();
            if (!(bool)dodajIzmeniTrening.ShowDialog()) { }
            this.Show();


        }

        private void btnObrisiTrening_Click(object sender, RoutedEventArgs e)
        {
            Trening treningZaBrisanje = view.CurrentItem as Trening;

            Main.Instance.DeleteTrening(treningZaBrisanje.Sifra);

            // int index = Main.Instance.Treninzi.ToList().FindIndex(trening=> trening.Sifra.Equals(treningZaBrisanje.Sifra));
            //Main.Instance.Treninzi[index].Aktivan = false;

            UpdateView();
            view.Refresh();

        }

        private void btnZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            Trening treningZaZakazivanje = view.CurrentItem as Trening;
            treningZaZakazivanje.StatusTreninga = EStatusTreninga.REZERVISAN;
            treningZaZakazivanje.Klijent = Main.Instance.Klijenti.ToList().Find(k => k.Korisnik.Email.Equals(Korisnik.Email));
            MessageBox.Show("Uspesno ste zakazali termin");

            UpdateView();
            view.Refresh();
            Main.Instance.SacuvajEntitet("treninzi.txt");

        }

        private void btnPregledKlijenta_Click(object sender, RoutedEventArgs e)
        {
            Trening trening = view.CurrentItem as Trening;
            if (trening.StatusTreninga.Equals(EStatusTreninga.REZERVISAN))
            {
                PregledajKlijentaWindow reviewKlijent = new PregledajKlijentaWindow(trening.Klijent.Korisnik, Korisnik);
                this.Hide();
                reviewKlijent.Show();
            }
            else
            {
                MessageBox.Show("Izaberite rezervisan trening.");
            }
        }

        private void btnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();

        }

        private void btnVratiSe_Click(object sender, RoutedEventArgs e)
        {
            KlijentWindow loginWindow = new KlijentWindow(Params.UlogovaniKorisnik);
            this.Hide();
            loginWindow.Show();
        }
    }
}
