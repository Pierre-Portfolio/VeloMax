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
    /// Logique d'interaction pour modifFournisseur.xaml
    public partial class modifFournisseur : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;
        public Fournisseur f1;
        public modifFournisseur(MySqlConnection connection, Fournisseur f1,MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.f1 = f1;
            this.mw = mw;

            BoxSiret.Text = f1.Siret;
            BoxNomEntreprise.Text = f1.Nomentreprise;
            BoxContact.Text = f1.Contact;
            BoxLibelle.Text = f1.Libellefourniseur;
            BoxAddresse.Text = f1.Adrfour;
        }

        private void ModifFournisseur(object sender, RoutedEventArgs e)
        {
            if (BoxSiret.Text != "" && BoxSiret.Text.Length != 0)
            {
                if (BoxNomEntreprise.Text != "" && BoxNomEntreprise.Text.Length != 0)
                {
                    if (BoxSiret.Text.ToString().Length == 15)
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "UPDATE velomax.fournisseur set siret = " + BoxSiret.Text.ToString() + ", nomentreprise = '" + BoxNomEntreprise.Text.ToString() + "', contact = '" + BoxContact.Text.ToString() + "', adrfour = '" + BoxAddresse.Text.ToString() + "', libellefourniseur = '" + BoxLibelle.Text.ToString() + "' where libellefourniseur = '" + BoxLibelle.Text.ToString() + "';";
                        MySqlDataReader reader = command.ExecuteReader();
                        connection.Close();

                        mw.RefreshFournisseur();
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
