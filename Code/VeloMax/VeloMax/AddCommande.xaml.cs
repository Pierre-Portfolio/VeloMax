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
                    string nomPrenom = "Particulier : " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString();
                    listNom.Add(nomPrenom);
                }
                else
                {
                    listNom.Add("Entreprise : " + reader.GetValue(0).ToString());
                }
            }
            BoxNomClient.ItemsSource = listNom;
            connection.Close();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select nom, grandeur, ligneproduit, prixbicy from velomax.bicyclette";
            reader = command.ExecuteReader();
            List<string> listBicyCmd = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listBicyCmd.Add($"Bicyclette : {reader.GetValue(0)} : {reader.GetValue(1)} : {reader.GetValue(2)} : {reader.GetValue(3)} $");
            }
            connection.Close();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select numpiece,descpiece,prixpiece from velomax.piecedetache";
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                listBicyCmd.Add($"Piece : {reader.GetValue(0)} : {reader.GetValue(1)} : {reader.GetValue(2)} $");
            }
            connection.Close();
            BoxAddItems.ItemsSource = listBicyCmd;

            boxQuantiteProd.ItemsSource = "1 2 3 4 5 6 7 8 9".Split();
        }

        private void AjouterItem(object sender, RoutedEventArgs e)
        {
            ClientCmd.Add(BoxAddItems.SelectedItem.ToString() + " : " + boxQuantiteProd.SelectedItem.ToString());
            listCmdClient.ItemsSource = ClientCmd;
            listCmdClient.Items.Refresh();
        }

        private void AjouterCmd(object sender, RoutedEventArgs e)
        {
            if (BoxAddrLivraison.Text != "" && BoxAddrLivraison.Text.Length != 0)
            {
                if (BoxNomClient.Text != "" && BoxNomClient.Text.Length != 0)
                {
                    DateTime dt1 = DateTime.Now;
                    string residclient = "";
                    MySqlCommand command;
                    MySqlDataReader reader;
                    string[] recupnomClient = BoxNomClient.Text.ToString().Split();
                    if(recupnomClient[0] == "Particulier")
                    {
                        connection.Open();
                        command = connection.CreateCommand();
                        command.CommandText = "SELECT idclient FROM velomax.particulier where nomclient = '" + recupnomClient[2] + "' AND prenomclient='" + recupnomClient[3] + "';";
                        reader = command.ExecuteReader();

                        while (reader.Read())// parcours ligne par ligne
                        {
                            residclient = reader.GetValue(0).ToString();
                        }
                    }
                    else
                    {
                        connection.Open();
                        command = connection.CreateCommand();
                        command.CommandText = "SELECT idclient FROM velomax.entreprise where nomentre = '" + recupnomClient[2] + "';";
                        reader = command.ExecuteReader();
                        while (reader.Read())// parcours ligne par ligne
                        {
                            residclient = reader.GetValue(0).ToString();
                        }
                    }
                    connection.Close();
                    MessageBox.Show("Delai de livraison estimé : 3 jours");

                    mw.keyCommande++;
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO velomax.commande (numcommande,datecommande,adrlivraison,datelivraison,idclient)VALUES(" + mw.keyCommande.ToString() + ",'" + dt1.ToString("yyyy-MM-dd HH:mm:ss") + "','" + BoxAddrLivraison.Text.ToString() + "','" + dt1.AddDays(3).ToString("yyyy-MM-dd HH:mm:ss") + "'," + residclient + ");";
                    reader = command.ExecuteReader();
                    connection.Close();

                    mw.RefreshCommandes();

                    foreach (string MyItem in listCmdClient.Items)
                    {
                        string[] separatingStrings = { " : " };
                        string[] ItemsRecup = MyItem.ToString().Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                        if(ItemsRecup[0] == "Bicyclette")
                        {

                            connection.Open();
                            command = connection.CreateCommand();
                            command.CommandText = "SELECT idbicy FROM velomax.bicyclette where nom = '" + ItemsRecup[1] + "' AND grandeur = '" + ItemsRecup[2]  + "';";
                            reader = command.ExecuteReader();
                            string res = "";
                            while (reader.Read())// parcours ligne par ligne
                            {
                                res = reader.GetValue(0).ToString();
                            }
                            connection.Close();

                            // ON VERIF SI YEN A EN STOCK




                        }
                        else
                        {
                            
                        }

                        connection.Open();
                        command = connection.CreateCommand();
                        command.CommandText = "INSERT INTO velomax.itemcmd (quantite,iditemstock,numcommande)VALUES(" + boxQuantiteProd.SelectedItem.ToString() + ",null,'" + mw.keyCommande.ToString() + "');";
                        reader = command.ExecuteReader();
                        connection.Close();
                    }
                    this.Close();
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
