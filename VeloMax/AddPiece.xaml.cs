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

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT siret FROM velomax.fournisseur;";
            MySqlDataReader reader = command.ExecuteReader();
            List<string> listFournisseur = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listFournisseur.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxSiret.ItemsSource = listFournisseur;

            // on crée une liste pour la desc
            BoxDescPiece.ItemsSource = "cadre,guidon,freins,selle,derailleuravant,derailleurarriere,roueavant,rouearriere,reflecteur,pedalleur,ordinateur,panier".Split(',');
        }

        private void AjouterPiece(object sender, RoutedEventArgs e)
        {
            if (BoxNumPiece.Text != "" && BoxNumPiece.Text.Length != 0)
            {
                if (BoxDescPiece.Text != "" && BoxDescPiece.Text.Length != 0)
                { 
                        int res;
                        if (int.TryParse(BoxPrix.Text.ToString(), out res))
                        {
                            if (res > 0)
                            {
                                if (BoxDateDisc.Text != "" && BoxDateDisc.Text.Length != 0)
                                {

                                    DateTime res2;
                                    if (DateTime.TryParse(BoxDateDisc.Text.ToString(), out res2))
                                    {

                                        int res3;
                                        if (int.TryParse(BoxPrix.Text.ToString(), out res3))
                                        {
                                            if (res >= 0)
                                            {
                                                if (BoxSiret.Text != "" && BoxSiret.Text.Length != 0)
                                                {
                                                    MessageBox.Show("REUSSIE");
                                                    /*
                                                    DateTime dt1 = DateTime.Now;
                                                    mw.key = mw.key + 1;
                                                    Bicyclette b1 = new Bicyclette(mw.key, BoxNom.Text.ToString(), BoxGrandeur.Text.ToString(), res, BoxligneProd.Text.ToString(), dt1, res2);
                                                    mw.myListBicy.Add(b1);
                                                    mw.myGridBicy.ItemsSource = mw.myListBicy;
                                                    mw.myGridBicy.Items.Refresh();

                                                    connection.Open();
                                                    MySqlCommand command = connection.CreateCommand();
                                                    command.CommandText = "INSERT INTO velomax.bicyclette (idbicy,nom,grandeur,prixbicy,ligneproduit,dateintrobicy,datediscontinuationbicy)VALUES(" + mw.key.ToString() + ",'" + BoxNom.Text.ToString() + "','" + BoxGrandeur.Text.ToString() + "'," + BoxPrix.Text + ",'" + BoxligneProd.Text.ToString() + "','" + dt1.ToString("yyyy-MM-dd HH:mm:ss") + "','" + res2.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                                    MessageBox.Show(command.CommandText.ToString());
                                                    MySqlDataReader reader = command.ExecuteReader();
                                                    connection.Close();
                                                    this.Close();*/
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Erreur le champ contenant le champ de numéro de siret est vide !");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Erreur le champ contenant le delai de livraison doit etre  positif !");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Erreur le champ contenant le delai de livraison doit etre un nombre !");
                                        }
                                           
                                            }
                                    else
                                    {
                                        MessageBox.Show("Erreur , veuillez modifier la saisie de la date de discontinuité !");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Erreur le champ contenant la date de discontinuité ne peut pas être vide!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Erreur le champ prix doit etre positif !");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erreur le champ prix doit etre un nombre !");
                        }
                    
                }
                else
                {
                    MessageBox.Show("Erreur le champ Description Piece est vide !");
                }
            }
            else
            {
                MessageBox.Show("Erreur le champ Numero Piece est vide  !");
            }
        }
    }
}
