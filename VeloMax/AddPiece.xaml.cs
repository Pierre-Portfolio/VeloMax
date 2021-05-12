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
    /// Logique d'interaction pour AddPiece.xaml
    /// </summary>
    public partial class AddPiece : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;

        public AddPiece(MySqlConnection connection, MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;
        }

        private void AjouterPiece(object sender, RoutedEventArgs e)
        {
        }
    }
}
