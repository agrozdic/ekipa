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
    /// Interaction logic for PrikazTreneraWindow.xaml
    /// </summary>
    public partial class PrikazTreneraWindow : Window
    {
        ICollectionView view;

        public PrikazTreneraWindow()
        {
            InitializeComponent();
            UpdateView();
            view.Filter = CustomFilter;
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

        private void UpdateView()
        {
            DGTreneri.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            DGTreneri.ItemsSource = view;
            DGTreneri.IsSynchronizedWithCurrentItem = true;

            DGTreneri.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private void DGTreneri_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // if(e.PropertyName.Equals("Aktivan"))
            //  {
            // e.Column.Visibility = Visibility.Collapsed; //sakrivamo kolonu ili red
            //  }

        }

        private void txtPretragaIme_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();

        }

        private void bntOdjava_Click(object sender, RoutedEventArgs e)
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
