using Projekat.Models;
//using Projekat.Resources;
//using Projekat.Resources.services;
using Projekat.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EStatus status;
        public MainWindow()
        {
            InitializeComponent();

            Main.Instance.CitanjeEntiteta("korisnici.txt");
            Main.Instance.CitanjeEntiteta("treneri.txt");
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();
        }
        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik registrovaniKorisnici = new RegistrovaniKorisnik();
            DodajIzmeniKlijentaWindow dodajIzmeniKlijenta = new DodajIzmeniKlijentaWindow(status, registrovaniKorisnici);
            dodajIzmeniKlijenta.cmbTipKorisnika.IsEnabled = true;

            if (!(bool)dodajIzmeniKlijenta.ShowDialog())
            {

            }
            this.Show();
        }
    }
}
