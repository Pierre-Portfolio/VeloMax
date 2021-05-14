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

            BoxNom.Text = b.Nom;
            BoxGrandeur.SelectedItem = b.Grandeur;
            BoxPrix.SelectedText = b.Prixbicy.ToString();
            BoxligneProd.SelectedItem = b.Ligneproduit;
            BoxDateDisc.SelectedText = b.Datediscontinuationbicy.ToString();
        }

        private void BoxNom_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (BoxGrandeur.Text.ToString() == "")
            {
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
            }
        }

        private void BoxGrandeur_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (BoxNom.Text.ToString() == "")
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT nom FROM velomax.assemblage where grandeur = '" + BoxGrandeur.SelectedItem.ToString() + "';";
                MySqlDataReader reader = command.ExecuteReader();
                List<string> listGrandeur = new List<string>();
                while (reader.Read())// parcours ligne par ligne
                {
                    listGrandeur.Add(reader.GetValue(0).ToString());
                }
                connection.Close();
                BoxNom.Items.Refresh();
                BoxNom.ItemsSource = listGrandeur;
            }
        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            DateTime res2;
            if (DateTime.TryParse(BoxDateDisc.Text.ToString(), out res2))
            {
                if (BoxPrix.Text != "" && BoxPrix.Text.Length != 0)
                {
                    int res;
                    if (int.TryParse(BoxPrix.Text.ToString(), out res))
                    {
                        if (res >= 0)
                        {
                            if (BoxligneProd.Text != "" && BoxGrandeur.Text.Length != 0)
                            {
                                connection.Open();
                                MySqlCommand command = connection.CreateCommand();
                                MessageBox.Show("UPDATE velomax.bicyclette SET prixbicy = '" + BoxPrix.SelectedText + "',ligneproduit = '" + BoxligneProd.SelectedItem + "', datediscontinuationbicy = '" + res2.ToString("yyyy-MM-dd HH:mm:ss") + "', nom = '" + BoxNom.SelectedItem + "', grandeur = '" + BoxGrandeur.SelectedItem + "' WHERE idbicy = " + b.Idbicy);
                                command.CommandText = "UPDATE velomax.bicyclette SET prixbicy = '" + BoxPrix.SelectedText + "',ligneproduit = '" + BoxligneProd.SelectedItem + "', datediscontinuationbicy = '" + res2.ToString("yyyy-MM-dd HH:mm:ss") + "', nom = '" + BoxNom.SelectedItem + "', grandeur = '" + BoxGrandeur.SelectedItem + "' WHERE idbicy = " + b.Idbicy;
                                MySqlDataReader reader = command.ExecuteReader();
                                connection.Close();

                                // on recupere les datas
                                connection.Open();
                                command = connection.CreateCommand();
                                command.CommandText = "SELECT * FROM velomax.bicyclette;";
                                reader = command.ExecuteReader();
                                List<Bicyclette> myListBicy = new List<Bicyclette>();
                                while (reader.Read())// parcours ligne par ligne
                                {
                                    myListBicy.Add(new Bicyclette(Convert.ToInt32(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), Convert.ToInt32(reader.GetValue(3).ToString()), reader.GetValue(4).ToString(), Convert.ToDateTime(reader.GetValue(5)), Convert.ToDateTime(reader.GetValue(6))));
                                    mw.keyBicy = Convert.ToInt32(reader.GetValue(0));
                                }
                                mw.myGridBicy.ItemsSource = myListBicy;
                                mw.myGridBicy.Items.Refresh();
                                connection.Close();

                                this.Close();

                                }
                                else
                                {
                                    MessageBox.Show("Erreur le champ Ligne Produit ne doit pas être vide!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Erreur le champ prix doit etre positif !");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erreur le champ prix doit contenir que un nombre ronds !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur le champ prix est vide !");
                    }
            }
            else
            {
                MessageBox.Show("Erreur , veuillez modifier la saisie de la date de discontinuité !");
            }
        }
    }
}
