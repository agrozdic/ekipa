using Projekat.Models;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat.Windows
{
    /// <summary>
    /// Interaction logic for IzmenaKorisnikaWindow.xaml
    /// </summary>
    public partial class IzmenaKorisnikaWindow : Window
    {
        private RegistrovaniKorisnik selektovaniKorisnik;
        private EStatus selektovaniStatus;
        public IzmenaKorisnikaWindow(EStatus status, RegistrovaniKorisnik korisnik)
        {
            InitializeComponent();
            selektovaniKorisnik = korisnik;
            selektovaniStatus = status;

            this.DataContext = korisnik;

            cmbTipKorisnika.ItemsSource = Enum.GetValues(typeof(ETipKorisnika));

            if (status.Equals(EStatus.DODAJ))
            {
                this.Title = "Dodaj korisnika";
            }
            else
            {
                txtEmail.IsEnabled = false;
                this.Title = "Izmeni korisnika";
            }
        }
        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            Trener trener = new Trener
            {
                Korisnik = selektovaniKorisnik
            };

            if (selektovaniStatus.Equals(EStatus.DODAJ))
            {
                selektovaniKorisnik.Aktivan = true;
                Main.Instance.Korisnici.Add(selektovaniKorisnik);
                Main.Instance.Treneri.Add(trener);
            }

            Main.Instance.SacuvajEntitet("korisnici.txt");
            // Data.Instance.SacuvajEntitet("profesori.txt");
            Main.Instance.SacuvajEntitet("treneri.txt");

            this.DialogResult = true;
            this.Close();
        }

    }
}
