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
    /// Logique d'interaction pour ModifPiece.xaml
    /// </summary>
    public partial class ModifPiece : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;
        public PieceDetache p;
        public ModifPiece(MySqlConnection connection, PieceDetache p , MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;
            this.p = p;

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
            //CONVERTIR EN ISTE CAR A C UN TABLEAU
            string[] listPossibilité = "Cadre,Guidon,Freins,Selle,Derailleuravant,Derailleurarriere,Roue,Roueavant,Rouearriere,Reflecteur,Pedalleur,Ordinateur,Panier".Split(',');
            List<string> lp = new List<string>();

            for (int i = 0; i < listPossibilité.Length;i++){
                lp.Add(listPossibilité[i]);
            }
            BoxDescPiece.ItemsSource = lp;

            BoxNumPiece.Text = p.Numpiece;
            BoxDescPiece.Text = p.Descpiece;
            BoxDescPiece.IsEnabled = false;
            BoxPrix.Text = p.Prixpiece.ToString();
            BoxDateDisc.Text = p.Datediscontprod.ToString();
            BoxDelai.Text = p.Delaiapprovprod.ToString();
            BoxSiret.Text = p.Siret;
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
                                    if (int.TryParse(BoxDelai.Text.ToString(), out res3))
                                    {
                                        if (res3 >= 0)
                                        {
                                            if (BoxSiret.Text != "" && BoxSiret.Text.Length != 0)
                                            {
                                                    connection.Open();
                                                    MySqlCommand command = connection.CreateCommand();
                                                    command.CommandText = "SELECT COUNT(*) from velomax.piecedetache where numpiece = '" + BoxNumPiece.Text + "';";
                                                    MySqlDataReader reader = command.ExecuteReader();
                                                    int nbrow = 0;
                                                    while (reader.Read())// parcours ligne par ligne
                                                    {
                                                        nbrow = Convert.ToInt32(reader.GetValue(0));
                                                    }
                                                    connection.Close();

                                                    if (nbrow == 0 || BoxNumPiece.Text == p.Numpiece)
                                                    {

                                                        connection.Open();
                                                        command = connection.CreateCommand();
                                                        command.CommandText = "UPDATE velomax.piecedetache SET numpiece = '" + BoxNumPiece.Text.ToString() + "', descpiece = '" + BoxDescPiece.Text.ToString() + "', numprodcatalogue = " + mw.keyPiece + ", prixpiece = " + res + ", datediscontprod = '" + res2.ToString("yyyy-MM-dd HH:mm:ss") + "', delaiapprovprod = " + res3 + ", siret = '" + BoxSiret.Text.ToString()  + "' where numpiece = '" + p.Numpiece + "';";
                                                        reader = command.ExecuteReader();
                                                        connection.Close();

                                                        mw.RefreshPiece();

                                                        if(BoxNumPiece.Text.ToString() != p.Numpiece)
                                                        {
                                                            connection.Open();
                                                            command = connection.CreateCommand();
                                                            command.CommandText = "UPDATE velomax.assemblage SET " + BoxDescPiece.Text + " = '" + BoxNumPiece.Text + "' WHERE " + BoxDescPiece.Text.ToLower() + " = '" + p.Numpiece + "';";
                                                            reader = command.ExecuteReader();
                                                            connection.Close();

                                                            mw.RefreshAssemblage();
                                                        }

                                                        this.Close();
                                                    
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Erreur, une piece porte deja ce nom !");
                                                    }
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
