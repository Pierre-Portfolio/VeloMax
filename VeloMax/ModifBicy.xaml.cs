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
    /// Logique d'interaction pour ModifBicy.xaml
    /// </summary>
    public partial class ModifBicy : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;
        public Bicyclette b;
        public ModifBicy(MySqlConnection connection, Bicyclette b,MainWindow mw)
        {
            InitializeComponent();
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;
            this.b = b;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT DISTINCT nom FROM velomax.bicyclette;";
            MySqlDataReader reader = command.ExecuteReader();
            List<string> listNom = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listNom.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxNom.ItemsSource = listNom;

            connection.Open();
            command.CommandText = "SELECT DISTINCT grandeur FROM velomax.bicyclette;";
            reader = command.ExecuteReader();
            List<string> listGrandeur = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listGrandeur.Add(reader.GetValue(0).ToString());
            }
            BoxGrandeur.ItemsSource = listGrandeur;
            connection.Close();

            connection.Open();
            command.CommandText = "SELECT DISTINCT ligneproduit FROM velomax.bicyclette;";
            reader = command.ExecuteReader();
            List<string> listProduit = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listProduit.Add(reader.GetValue(0).ToString());
            }
            BoxligneProd.ItemsSource = listProduit;
            connection.Close();
        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("haha");
        }
    }
}
