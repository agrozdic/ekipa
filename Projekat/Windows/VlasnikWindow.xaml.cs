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
    /// Interaction logic for VlasnikWindow.xaml
    /// </summary>
    public partial class VlasnikWindow : Window
    {
        public VlasnikWindow()
        {
            InitializeComponent();
        }

        private void btnPrikazIzvestaja_Click(object sender, RoutedEventArgs e)
        {
            PrikazIzvestajaWindow izvestajiWindow = new PrikazIzvestajaWindow();
            this.Hide();
            izvestajiWindow.Show();
        }
    }
}
