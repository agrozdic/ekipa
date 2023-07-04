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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat.Windows
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
            view = CollectionViewSource.GetDefaultView(Main.Instance.Korisnici);
            view.Filter = CustomFilter;
            dgTreneri.ItemsSource = view;
        }

        private RegistrovaniKorisnik registrovaniKorisnici;

        public DodajIzmeniTreneraWindow(RegistrovaniKorisnik korisnik)
        {
            InitializeComponent();
            registrovaniKorisnici = korisnik;
        }

        private bool CustomFilter(object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;

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
            RegistrovaniKorisnik k = new RegistrovaniKorisnik();
            IzmenaKorisnikaWindow dodajIzmeniWindow = new IzmenaKorisnikaWindow(EStatus.DODAJ, k);

            dodajIzmeniWindow.ShowDialog();
            view.Refresh();
        }

        private void miIzmeniKorisnika_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik k = (RegistrovaniKorisnik)dgTreneri.SelectedItem;
            RegistrovaniKorisnik kopija = new RegistrovaniKorisnik();
            kopija.Ime = k.Ime;
            kopija.Prezime = k.Prezime;
            kopija.Email = k.Email;
            kopija.Adresa = k.Adresa;
            kopija.BrKartice = k.BrKartice;
            kopija.OsnovniJezik = k.OsnovniJezik;
            kopija.DodatniJezik = k.DodatniJezik;
            kopija.TipKorisnika = k.TipKorisnika;
            kopija.Cilj = k.Cilj;
            kopija.Lozinka = k.Lozinka;
            kopija.Aktivan = k.Aktivan;

            IzmenaKorisnikaWindow dodajIzmeniTreneraWindow = new IzmenaKorisnikaWindow(EStatus.IZMENI, k);


            if ((bool)!dodajIzmeniTreneraWindow.ShowDialog())
            {
                int index = Main.Instance.Korisnici.ToList().FindIndex(ko => ko.Email.Equals(k.Email));
                Main.Instance.Korisnici[index] = kopija;
            }
            view.Refresh();
        }

        private void miObrisi_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik k = (RegistrovaniKorisnik)dgTreneri.SelectedItem;
            Main.Instance.DeleteUser(k.Email);
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
