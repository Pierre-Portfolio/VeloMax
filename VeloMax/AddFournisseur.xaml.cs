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
using MySql.Data.MySqlClient;

namespace VeloMax
{
    /// <summary>
    /// Logique d'interaction pour AddFournisseur.xaml
    /// </summary>
    public partial class AddFournisseur : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;
        public AddFournisseur(MySqlConnection connection, MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;
        }

        private void AjouterFournisseur(object sender, RoutedEventArgs e)
        {
            if (BoxSiret.Text != "" && BoxSiret.Text.Length != 0)
            {
                if (BoxNomEntreprise.Text != "" && BoxNomEntreprise.Text.Length != 0)
                {
                    if (BoxSiret.Text.ToString().Length == 15)
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "INSERT INTO velomax.fournisseur (siret,nomentreprise,contact,adrfour,libellefourniseur)VALUES('" + BoxSiret.Text.ToString() + "','" + BoxNomEntreprise.Text.ToString() + "','" + BoxContact.Text.ToString() + "','" + BoxAddresse.Text.ToString() + "','" + BoxLibelle.Text.ToString() + "');";
                        MySqlDataReader reader = command.ExecuteReader();
                        connection.Close();

                        //mw.RefreshFournisseur();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur , Le numéro de siret doit faire 15 caracteres , il y en a actuellement " + BoxSiret.Text.Length + " !");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur , Le champ comprenant le nom de l'entreprise est vide !");
                }
            }
            else
            {
                MessageBox.Show("Erreur , Le champ comprenant le numéro de siret est vide !");
            }
            
        }
    }
}
