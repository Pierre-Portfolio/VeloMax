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
    /// Logique d'interaction pour modifClientEntre.xaml
    /// </summary>
    public partial class modifClientEntre : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;
        public Entreprise e1;
        public modifClientEntre(MySqlConnection connection, Entreprise e1, MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.e1 = e1;
            this.mw = mw;

            BoxNomEntre.Text = e1.Nomentre;
            BoxRemiseEntre.Text = e1.Remiseentre.ToString();
            BoxRueClient.Text = e1.Rueclient;
            BoxCodePostale.Text = e1.Codepostaleclient;
            BoxProvinceClient.Text = e1.Provinceclient;
            BoxVilleClient.Text = e1.Villeclient;

        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            if (BoxNomEntre.Text != "" && BoxNomEntre.Text.Length != 0)
            {
                if (BoxRemiseEntre.Text != "" && BoxRemiseEntre.Text.Length != 0)
                {
                    if (BoxRueClient.Text != "" && BoxRueClient.Text.Length != 0)
                    {
                        if (BoxCodePostale.Text != "" && BoxCodePostale.Text.Length != 0)
                        {
                            if (BoxProvinceClient.Text != "" && BoxProvinceClient.Text.Length != 0)
                            {
                                float res;
                                if (float.TryParse(BoxRemiseEntre.Text.ToString(), out res))
                                {
                                    if (res >= 0)
                                    {
                                        if (BoxVilleClient.Text != "" && BoxVilleClient.Text.Length != 0)
                                        {
                                            connection.Open();
                                            MySqlCommand command = connection.CreateCommand();
                                            command.CommandText = "UPDATE velomax.clientele set rueclient= '" + BoxRueClient.Text.ToString() + "', codepostaleclient = '" + BoxCodePostale.Text.ToString() + "', provinceclient = '" + BoxProvinceClient.Text.ToString() + "', villeclient ='" + BoxVilleClient.Text.ToString() + "' where idclient = '" + e1.Idclient + "';";
                                            MySqlDataReader reader = command.ExecuteReader();
                                            connection.Close();

                                            connection.Open();
                                            command = connection.CreateCommand();
                                            command.CommandText = "UPDATE velomax.particulier set nomentre= '" + BoxNomEntre.Text.ToString() + "', remisenetre = '" + BoxRemiseEntre.Text.ToString() + "' where idclient = '" + e1.Idclient + "';";
                                            reader = command.ExecuteReader();
                                            connection.Close();

                                            mw.RefreshClientEntre();



                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Erreur le champ ville est vide !");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("La remise doit être un nombre positif!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La remise doit être un nombre !");
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
                    MessageBox.Show("Erreur le champ remise est vide !");
                }
            }
            else
            {
                MessageBox.Show("Erreur le champ nom est vide !");
            }
        }
    }
}
