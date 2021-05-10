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
    /// Logique d'interaction pour AddAssemblage.xaml
    /// </summary>
    public partial class AddAssemblage : Window
    {
        MySqlConnection connection;
        public AddAssemblage(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Cadre';";
            MySqlDataReader reader = command.ExecuteReader();
            List<string> listCadre = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listCadre.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxCadre.ItemsSource = listCadre;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Guidon';";
            reader = command.ExecuteReader();
            List<string> listGuidon = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listGuidon.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxGuidon.ItemsSource = listGuidon;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Frein';";
            reader = command.ExecuteReader();
            List<string> listFreins = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listFreins.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxFrein.ItemsSource = listFreins;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Cadre';";
            reader = command.ExecuteReader();
            List<string> listSelle = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listSelle.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxSelle.ItemsSource = listSelle;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Dérailleur avant'; ";
            reader = command.ExecuteReader();
            List<string> listderailleuravant = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listderailleuravant.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxDeraillieurA.ItemsSource = listderailleuravant;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Dérailleur arrière'; ";
            reader = command.ExecuteReader();
            List<string> listderailleurarriere = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listderailleurarriere.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxDeraillieurB.ItemsSource = listderailleurarriere;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Roue avant'; ";
            reader = command.ExecuteReader();
            List<string> listroueAvant = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listroueAvant.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxRoueAvant.ItemsSource = listroueAvant;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Roue arrière'; ";
            reader = command.ExecuteReader();
            List<string> listroueArrierre = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listroueArrierre.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxRoueArriere.ItemsSource = listroueArrierre;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Réflecteur'; ";
            reader = command.ExecuteReader();
            List<string> listreflecteur = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listreflecteur.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxReflecteur.ItemsSource = listreflecteur;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Pédaleur'; ";
            reader = command.ExecuteReader();
            List<string> listpedalleur = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listpedalleur.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxPedalleur.ItemsSource = listpedalleur;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Ordinateur'; ";
            reader = command.ExecuteReader();
            List<string> listordinateur = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listordinateur.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxOrdinateur.ItemsSource = listordinateur;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Panier'; ";
            reader = command.ExecuteReader();
            List<string> listpanier = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listpanier.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxPanier.ItemsSource = listpanier;
        }

        private void AjouterAssemblage(object sender, RoutedEventArgs e)
        {
            if (BoxNom.Text != "" && BoxNom.Text.Length != 0)
            {
                if (BoxGrandeur.Text != "" && BoxGrandeur.Text.Length != 0)
                {
                    Assemblage a1 = new Assemblage(BoxNom.Text.ToString(), BoxGrandeur.Text.ToString(),BoxCadre.Text.ToString(),BoxGuidon.Text.ToString(),BoxFrein.Text.ToString(),BoxSelle.Text.ToString(),BoxDeraillieurA.Text.ToString(),BoxDeraillieurB.Text.ToString(),BoxRoueAvant.Text.ToString(),BoxRoueArriere.Text.ToString(),BoxReflecteur.Text.ToString(),BoxPedalleur.Text.ToString(),BoxOrdinateur.Text.ToString(),BoxPanier.Text.ToString());
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO velomax.assemblage (nom,grandeur,cadre,guidon,freins,selle,derailleuravant,derailleurarriere,roueavant,rouearriere,reflecteur,pedalleur,ordinateur,panier)VALUES('" + BoxNom.Text.ToString() + "','" + BoxGrandeur.Text.ToString() + "','" + BoxCadre.Text.ToString() + "','" + BoxGuidon.Text.ToString() + "','" + BoxFrein.Text.ToString() + "','" + BoxSelle.Text.ToString() + "','" + BoxDeraillieurA.Text.ToString() + "','" + BoxDeraillieurB.Text.ToString() + "','" + BoxRoueAvant.Text.ToString() + "','" + BoxRoueArriere.Text.ToString() + "','" + BoxReflecteur.Text.ToString() + "','" + BoxPedalleur.Text.ToString() + "','" + BoxOrdinateur.Text.ToString() + "','" + BoxPanier.Text.ToString() + "');";
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                    this.Close();
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
