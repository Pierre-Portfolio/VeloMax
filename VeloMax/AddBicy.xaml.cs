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
    /// Logique d'interaction pour AddBicy.xaml
    /// </summary>
    public partial class AddBicy : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;
        public List<Object> listBicy;
        public int key;
        public AddBicy(MySqlConnection connection, int key)
        {
            InitializeComponent();
            this.key = key;

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

        private void BoxNom_SelectionChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void BoxGrandeur_SelectionChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("2");
        }



        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            if (BoxNom.Text != "" && BoxNom.Text.Length != 0)
            {
                if (BoxGrandeur.Text != "" && BoxGrandeur.Text.Length != 0)
                {
                    if (BoxPrix.Text != "" && BoxPrix.Text.Length != 0)
                    {
                        int res;
                        if (int.TryParse(BoxPrix.Text.ToString(), out res))
                        {
                            if (res >= 0)
                            {
                                if(BoxligneProd.Text != "" && BoxGrandeur.Text.Length != 0)
                                {
                                    
                                    DateTime res2;
                                    if (DateTime.TryParse(BoxDateDisc.Text.ToString(), out res2))
                                    {
                                        Bicyclette b1 = new Bicyclette(key, BoxNom.Text.ToString(), BoxGrandeur.Text.ToString(), res, BoxligneProd.Text.ToString(), DateTime.Now, res2);
                                        /*
                                        connection.Open();
                                        MySqlCommand command = connection.CreateCommand();
                                        string textSQL = "";
                                        command.CommandText = "SELECT * FROM velomax.piecedetache;";
                                        reader = command.ExecuteReader();
                                        Dictionary<int, PieceDetache> myDictPiece = new Dictionary<int, PieceDetache>();
                                        key = 0;
                                        while (reader.Read())// parcours ligne par ligne
                                        {
                                            myDictPiece.Add(key++, new PieceDetache(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2).ToString()), Convert.ToInt32(reader.GetValue(3).ToString()), Convert.ToDateTime(reader.GetValue(4).ToString()), Convert.ToDateTime(reader.GetValue(5).ToString()), Convert.ToInt32(reader.GetValue(6).ToString()), reader.GetValue(7).ToString()));
                                            key++;
                                        }
                                        myGridPiece.ItemsSource = myDictPiece.Values;
                                        connection.Close();

                                        this.Close();
                                        */
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erreur , veuillez modifier la saisie de la date de discontinuation !");
                                    }

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
                            MessageBox.Show("Erreur le champ prix est doit contenir que un nombre ronds !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erreur le champ prix est vide !");
                    }



                }
                else
                    {
                        MessageBox.Show("Erreur le champ grandeur est vide !");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur le champ nom est vide !");
                }

            
        }
    }
}
