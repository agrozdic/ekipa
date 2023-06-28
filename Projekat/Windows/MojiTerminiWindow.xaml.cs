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
    /// Interaction logic for MojiTerminiWindow.xaml
    /// </summary>
    public partial class MojiTerminiWindow : Window
    {
        ICollectionView view;
        private EStatusTreninga odabraniStatusTreninga;
        private Korisnik Korisnik;
        public MojiTerminiWindow(Korisnik korisnik)
        {
            InitializeComponent();
            UpdateView();
            Korisnik = korisnik;
            view.Filter = CustomFilter;
        }

        private bool CustomFilter(object obj)
        {
            Trening trening = obj as Trening;
            if (trening.Aktivan)
            {
                if (odabraniStatusTreninga.Equals(EStatusTreninga.SLOBODAN) && Korisnik.TipKorisnika.Equals(ETipKorisnika.KLIJENT))
                {
                    return trening.StatusTreninga.Equals(EStatusTreninga.REZERVISAN);

                }
                else if (Korisnik.TipKorisnika.Equals(ETipKorisnika.ADMINISTRATOR))
                {
                    return true;
                }
                else if (Korisnik.TipKorisnika.Equals(ETipKorisnika.TRENER))
                {
                    return trening.Trener.Korisnik.Email.Equals(Korisnik.Email);
                }
            }
            return false;
        }
        private void UpdateView()
        {
            DGTreninziPolaznik.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Main.Instance.Treninzi);
            DGTreninziPolaznik.ItemsSource = view;
            DGTreninziPolaznik.IsSynchronizedWithCurrentItem = true;

            DGTreninziPolaznik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private void btnOtkaziTermin_Click(object sender, RoutedEventArgs e)
        {
            Trening treningZaOtkazivanje = view.CurrentItem as Trening;
            treningZaOtkazivanje.StatusTreninga = EStatusTreninga.SLOBODAN;
            treningZaOtkazivanje.Klijent = Main.Instance.Klijenti.ToList().Find(k => k.Korisnik.Email.Equals("xxxxx"));
            MessageBox.Show("Uspesno ste otkazali termin");

            UpdateView();
            view.Refresh();
            Main.Instance.SacuvajEntitet("treninzi.txt");

        }

        private void DGTreninziPolaznik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

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