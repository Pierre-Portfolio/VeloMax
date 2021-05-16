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
        public AddBicy(MySqlConnection connection, MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT DISTINCT nom FROM velomax.assemblage;";
            MySqlDataReader reader = command.ExecuteReader();
            List<string> listNom = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listNom.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxNom.ItemsSource = listNom;

            connection.Open();
            command.CommandText = "SELECT DISTINCT grandeur FROM velomax.assemblage;";
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

        private void BoxGrandeur_SelectionChanged(object sender, RoutedEventArgs e)
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



        private void AjouterBicy(object sender, RoutedEventArgs e)
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
                                        DateTime dt1 = DateTime.Now;
                                        mw.keyBicy = mw.keyBicy + 1;
                                        Bicyclette b1 = new Bicyclette(mw.keyBicy, BoxNom.Text.ToString(), BoxGrandeur.Text.ToString(), res, BoxligneProd.Text.ToString(), dt1, res2);
                                        mw.myListBicy.Add(b1);
                                        mw.myGridBicy.ItemsSource = mw.myListBicy;
                                        mw.myGridBicy.Items.Refresh();

                                        connection.Open();
                                        MySqlCommand command = connection.CreateCommand();
                                        command.CommandText = "INSERT INTO velomax.bicyclette (idbicy,nom,grandeur,prixbicy,ligneproduit,dateintrobicy,datediscontinuationbicy)VALUES(" + mw.keyBicy.ToString() + ",'" + BoxNom.Text.ToString() + "','" + BoxGrandeur.Text.ToString() + "'," + BoxPrix.Text + ",'" + BoxligneProd.Text.ToString() + "','" + dt1.ToString("yyyy-MM-dd HH:mm:ss") + "','" + res2.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                        MySqlDataReader reader = command.ExecuteReader();
                                        connection.Close();

                                        mw.RefreshBicyClette();

                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erreur , veuillez modifier la saisie de la date de discontinuité !");
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
