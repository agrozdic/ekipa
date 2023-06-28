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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatGNS.Windows
{
    /// <summary>
    /// Interaction logic for DodajIzmeniTreneraWindow.xaml
    /// </summary>
    public partial class DodajIzmeniTreneraWindow : Window
    {
        ICollectionView view;
        public DodajIzmeniTreneraWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            view.Filter = CustomFilter;
            dgTreneri.ItemsSource = view;
        }

        private Korisnik Korisnici;

        public DodajIzmeniTreneraWindow(Korisnik korisnik)
        {
            InitializeComponent();
            Korisnici = korisnik;
        }

        private bool CustomFilter(object obj)
        {
            Korisnik korisnik = obj as Korisnik;

            if (korisnik.Aktivan)
            {
                if (txtPretragaIme.Text != "")
                {
                    return korisnik.Ime.Contains(txtPretragaIme.Text);

                }
                else
                    return true;
            }
            return false;

        }
        private void miDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = new Korisnik();
            IzmenaKorisnikaWindow dodajIzmeniWindow = new IzmenaKorisnikaWindow(EStatus.DODAJ, k);

            dodajIzmeniWindow.ShowDialog();
            view.Refresh();
        }

        private void miIzmeniKorisnika_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = (Korisnik)dgTreneri.SelectedItem;
            Korisnik kopija = new Korisnik();
            kopija.Ime = k.Ime;
            kopija.Prezime = k.Prezime;
            kopija.Email = k.Email;
            kopija.Adresa = k.Adresa;
            kopija.BrKartice = k.BrKartice;
            kopija.OsnovniJezik = k.OsnovniJezik;
            kopija.DodatniJezik = k.DodatniJezik;
            kopija.TipKorisnika = k.TipKorisnika;
            kopija.CiljKlijenta = k.CiljKlijenta;
            kopija.Lozinka = k.Lozinka;
            kopija.Aktivan = k.Aktivan;

            IzmenaKorisnikaWindow dodajIzmeniTreneraWindow = new IzmenaKorisnikaWindow(EStatus.IZMENI, k);


            if ((bool)!dodajIzmeniTreneraWindow.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(ko => ko.Email.Equals(k.Email));
                Util.Instance.Korisnici[index] = kopija;
            }
            view.Refresh();
        }

        private void miObrisi_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = (Korisnik)dgTreneri.SelectedItem;
            Util.Instance.DeleteUser(k.Email);
            view.Refresh();
        }

        private void txtPretragaIme_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
        private void dgTreneri_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Error"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
}
