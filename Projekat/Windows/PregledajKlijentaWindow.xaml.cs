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
using static System.Net.Mime.MediaTypeNames;

namespace ProjekatGNS.Windows
{
    /// <summary>
    /// Interaction logic for PregledajKlijentaWindow.xaml
    /// </summary>
    public partial class PregledajKlijentaWindow : Window
    {
        Korisnik Korisnik;
        public PregledajKlijentaWindow(Korisnik klijent, Korisnik korisnik)
        {
            InitializeComponent();

            this.DataContext = klijent;
            Korisnik = korisnik;

            cmbTipKorisnika.ItemsSource = Enum.GetValues(typeof(ETipKorisnika)).Cast<ETipKorisnika>();


            txtIme.IsEnabled = false;
            txtPrezime.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtAdresa.IsEnabled = false;
            txtKartica.IsEnabled = false;
            txtOsnovniJezik.IsEnabled = false;
            txtDodatniJezik.IsEnabled = false;
            cmbTipKorisnika.IsEnabled = false;
            txtLozinka.IsEnabled = false;
            txtTelefon.IsEnabled = false;

        }
        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeTerminaWindow zakazivanje = new ZakazivanjeTerminaWindow(Params.UlogovaniKorisnik);
            this.Close();
            zakazivanje.Show();
            
        }
    }
}
