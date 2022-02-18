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
    /// Logique d'interaction pour AddClientPart.xaml
    /// </summary>
    public partial class AddClientPart : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;

        public AddClientPart(MySqlConnection connection, MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT descfidelio FROM velomax.fidelio;";
            MySqlDataReader reader = command.ExecuteReader();
            List<string> listNom = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listNom.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxNomFidelio.ItemsSource = listNom;
        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            
            if (BoxNomClient.Text != "" && BoxNomClient.Text.Length != 0)
            {
                if (BoxPrenomClient.Text != "" && BoxPrenomClient.Text.Length != 0)
                {
                    if (BoxNomFidelio.Text != "" && BoxNomFidelio.Text.Length != 0)
                    {
                        if (BoxRueClient.Text != "" && BoxRueClient.Text.Length != 0)
                        {
                            if (BoxCodePostale.Text != "" && BoxCodePostale.Text.Length != 0)
                            {
                                if (BoxProvinceClient.Text != "" && BoxProvinceClient.Text.Length != 0)
                                {
                                    if (BoxVilleClient.Text != "" && BoxVilleClient.Text.Length != 0)
                                    {
                                        mw.keyClient = mw.keyClient + 1;
                                        mw.keyClientPart = mw.keyClientPart + 1;
                                        int idfidel = -1; 

                                        connection.Open();
                                        MySqlCommand command = connection.CreateCommand();
                                        command.CommandText = "SELECT idfidelio FROM velomax.fidelio where descfidelio = '" + BoxNomFidelio.Text.ToString() + "';";
                                        MySqlDataReader reader = command.ExecuteReader();
                                        while (reader.Read())// parcours ligne par ligne
                                        {
                                            idfidel = Convert.ToInt32(reader.GetValue(0));
                                        }
                                        connection.Close();

                                        Particulier p1 = new Particulier(mw.keyClient, mw.keyClientPart,BoxNomClient.Text.ToString() ,BoxPrenomClient.Text.ToString(), idfidel, BoxRueClient.Text.ToString(), BoxCodePostale.Text.ToString(), BoxProvinceClient.Text.ToString(), BoxVilleClient.Text.ToString());
                                        mw.myListClientParti.Add(p1);
                                        mw.myGridClientParti.ItemsSource = mw.myListClientParti;
                                        mw.myGridClientParti.Items.Refresh();

                                        connection.Open();
                                        command = connection.CreateCommand();
                                        command.CommandText = "INSERT INTO velomax.clientele (idclient,rueclient,codepostaleclient,provinceclient,villeclient)VALUES(" + mw.keyClient.ToString() + ",'" + BoxRueClient.Text.ToString() + "','" + BoxCodePostale.Text.ToString() + "','" + BoxProvinceClient.Text.ToString() + "','" + BoxVilleClient.Text.ToString() + "');";
                                        reader = command.ExecuteReader();
                                        connection.Close();

                                        connection.Open();
                                        command = connection.CreateCommand();
                                        command.CommandText = "INSERT INTO velomax.particulier (idparticulier,nomclient,prenomclient,idclient,idfidelio)VALUES(" + mw.keyClientPart.ToString() + ",'" + BoxNomClient.Text.ToString() + "','" + BoxPrenomClient.Text.ToString() + "'," + mw.keyClient + "," + idfidel + ");";
                                        reader = command.ExecuteReader();
                                        connection.Close();

                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erreur le champ ville est vide !");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Erreur le champ province est vide !");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Erreur le code Postale est vide !");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Erreur le champ rue client est vide !");
                        }
                    }   
                    else
                    {
                        MessageBox.Show("Erreur le champ nom fidelio est vide !");
                    }
                }
               else
               {
                    MessageBox.Show("Erreur le champ prenom est vide !");
               }
            }
            else
            {
                MessageBox.Show("Erreur le champ nom est vide !");
            }
            
        }
    }
}
