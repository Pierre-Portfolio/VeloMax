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
using MySql.Data.MySqlClient;

namespace VeloMax
{
    /// <summary>
    /// Logique d'interaction pour ModifAssemblage.xaml
    /// </summary>
    public partial class ModifAssemblage : Window
    {
        MySqlConnection connection;
        MainWindow mw;

        public ModifAssemblage(MySqlConnection connection, MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;
        }

        private void BtnModifAssemblage(object sender, RoutedEventArgs e)
        {
        }
        }
}
