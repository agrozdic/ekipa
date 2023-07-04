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
    /// Interaction logic for PrikazIzvestajaWindow.xaml
    /// </summary>
    public partial class PrikazIzvestajaWindow : Window
    {
        ICollectionView view;
        public PrikazIzvestajaWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Main.Instance.Korisnici);
            dgTreneri.ItemsSource = view;
        }
        private RegistrovaniKorisnik registrovaniKorisnici;

        public PrikazIzvestajaWindow(RegistrovaniKorisnik korisnik)
        {
            InitializeComponent();
            registrovaniKorisnici = korisnik;
        }

        private void dgTreneri_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Error"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void bntOdjava_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();

        }

    }
}
