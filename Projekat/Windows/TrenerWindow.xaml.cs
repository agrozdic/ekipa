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
    /// Interaction logic for TrenerWindow.xaml
    /// </summary>
    public partial class TrenerWindow : Window
    {
        private Korisnik Korisnik;
        public TrenerWindow(Korisnik korisnik)
        {
            InitializeComponent();
            Korisnik = korisnik;
        }

        private void btnMojiTreninzi_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeTerminaWindow treninziWindow = new ZakazivanjeTerminaWindow(Korisnik);
            this.Hide();
            treninziWindow.Show();
            treninziWindow.btnZakaziTermin.Visibility = Visibility.Collapsed;
        }

        private void btnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();

        }
    }
}
