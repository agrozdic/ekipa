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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatGNS.Windows
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow(Korisnik korisnik)
        {
            InitializeComponent();
            Util.Instance.CitanjeEntiteta("korisnici.txt");
            Util.Instance.CitanjeEntiteta("treneri.txt");
        }

        private void btnPrikazTrenera_Click(object sender, RoutedEventArgs e)
        {
            DodajIzmeniTreneraWindow mainWindow = new DodajIzmeniTreneraWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
}
