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
    /// Logique d'interaction pour AddCommande.xaml
    /// </summary>
    public partial class AddCommande : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;
        public List<string> ClientCmd = new List<string>();
        public AddCommande(MySqlConnection connection , MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT nomentre,nomclient,prenomclient FROM velomax.entreprise as e right JOIN velomax.clientele as c ON e.idclient = c.idclient left JOIN velomax.particulier as p ON p.idclient = c.idclient;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            List<string> listNom = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                if(reader.GetValue(0).ToString() == "")
                {
                    string nomPrenom = reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString();
                    listNom.Add(nomPrenom);
                }
                else
                {
                    listNom.Add(reader.GetValue(0).ToString());
                }
            }
            BoxNomClient.ItemsSource = listNom;
            connection.Close();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select nom, grandeur, ligneproduit from velomax.bicyclette";
            reader = command.ExecuteReader();
            List<string> listBicyCmd = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listBicyCmd.Add($"{reader.GetValue(0)} | {reader.GetValue(1)} | {reader.GetValue(2)} ");
            }
            connection.Close();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select numpiece,descpiece from velomax.piecedetache";
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                listBicyCmd.Add($"{reader.GetValue(0)} | {reader.GetValue(1)}");
            }
            connection.Close();
            BoxAddItems.ItemsSource = listBicyCmd;
        }

        private void BoxAddItems_SelectionChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(BoxAddItems.SelectedItem.ToString());
            ClientCmd.Add(BoxAddItems.SelectedItem.ToString());
            listCmdClient.ItemsSource = ClientCmd;
            listCmdClient.Items.Refresh();
            /*
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT grandeur FROM velomax.assemblage where nom='" + BoxNom.SelectedItem.ToString() + "';";
            MySqlDataReader reader = command.ExecuteReader();
            List<string> listNom = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listNom.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxGrandeur.Items.Refresh();
            BoxGrandeur.ItemsSource = listNom;
            */
        }

        private void AjouterCmd(object sender, RoutedEventArgs e)
        {
            if (BoxAddrLivraison.Text != "" && BoxAddrLivraison.Text.Length != 0)
            {
                if (BoxNomClient.Text != "" && BoxNomClient.Text.Length != 0)
                {
                    
                    
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur le champ nom est vide !");
                }
            }
            else
            {
                MessageBox.Show("Erreur le champ de nom de livraison est vide !");
            }
        }
    }
}
