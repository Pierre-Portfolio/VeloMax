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
    /// Logique d'interaction pour ModifAssemblage.xaml
    /// </summary>
    public partial class ModifAssemblage : Window
    {
        MySqlConnection connection;
        Assemblage a;
        MainWindow mw;
        public ModifAssemblage(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }
        public ModifAssemblage(MySqlConnection connection, Assemblage a,MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.a = a;
            this.mw = mw;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT distinct grandeur FROM velomax.assemblage;";
            MySqlDataReader reader = command.ExecuteReader();
            List<string> listGrandeur = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listGrandeur.Add(reader.GetValue(0).ToString());
            }
            connection.Close();
            BoxGrandeur.ItemsSource = listGrandeur;

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Cadre';";
            reader = command.ExecuteReader();
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
            command.CommandText = "SELECT numpiece FROM velomax.piecedetache where descpiece = 'Selle';";
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

            BoxNom.Text = a.Nom;
            BoxGrandeur.SelectedItem = a.Grandeur;
            BoxNom.IsEnabled = false;
            BoxGrandeur.IsEnabled = false;
            BoxCadre.SelectedItem = a.Cadre;
            BoxGuidon.SelectedItem = a.Guidon;
            BoxFrein.SelectedItem = a.Freins;
            BoxSelle.SelectedItem = a.Selle;
            BoxDeraillieurA.SelectedItem = a.Derailleuravant;
            BoxDeraillieurB.SelectedItem = a.Derailleurarriere;
            BoxRoueAvant.SelectedItem = a.Roueavant;
            BoxRoueArriere.SelectedItem = a.Rouearriere;
            BoxReflecteur.SelectedItem = a.Reflecteur;
            BoxPedalleur.SelectedItem = a.Pedalleur;
            BoxOrdinateur.SelectedItem = a.Ordinateur;
            BoxPanier.SelectedItem = a.Panier;
        }

        private void BtnModifAssemblage(object sender, RoutedEventArgs e)
        {
            
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MessageBox.Show("UPDATE velomax.assemblage SET cadre = '" + BoxCadre.SelectedItem.ToString() + "' AND guidon = '" + BoxGuidon.SelectedItem.ToString() + "' AND freins = '" + BoxFrein.SelectedItem.ToString() + "' AND selle = '" + BoxSelle.SelectedItem.ToString() + "' AND derailleuravant = '" + BoxDeraillieurA.SelectedItem.ToString() + "' AND derailleurarriere = '" + BoxDeraillieurB.SelectedItem.ToString() + "' AND roueavant = '" + BoxRoueAvant.SelectedItem.ToString() + "' AND rouearriere = '" + BoxRoueArriere.SelectedItem.ToString() + "' AND reflecteur = '" + BoxReflecteur.SelectedItem.ToString() + "' AND pedalleur = '" + BoxPedalleur.SelectedItem.ToString() + "' AND ordinateur = '" + BoxOrdinateur.SelectedItem.ToString() + "' AND panier = '" + BoxPanier.SelectedItem.ToString() + "' WHERE nom = '" + BoxNom.Text.ToString() + "' AND grandeur = '" + BoxGrandeur.SelectedItem.ToString() + "'");
            command.CommandText = "UPDATE velomax.assemblage SET cadre = '" + BoxCadre.SelectedItem.ToString() + "' AND guidon = '" + BoxGuidon.SelectedItem.ToString() + "' AND freins = '" + BoxFrein.SelectedItem.ToString() + "' AND selle = '" + BoxSelle.SelectedItem.ToString() + "' AND derailleuravant = '" + BoxDeraillieurA.SelectedItem.ToString() + "' AND derailleurarriere = '" + BoxDeraillieurB.SelectedItem.ToString() + "' AND roueavant = '" + BoxRoueAvant.SelectedItem.ToString() + "' AND rouearriere = '" + BoxRoueArriere.SelectedItem.ToString() + "' AND reflecteur = '" + BoxReflecteur.SelectedItem.ToString() + "' AND pedalleur = '" + BoxPedalleur.SelectedItem.ToString() + "' AND ordinateur = '" + BoxOrdinateur.SelectedItem.ToString() + "' AND panier = '" + BoxPanier.SelectedItem.ToString() + "' WHERE nom = '" + BoxNom.Text.ToString() + "' AND grandeur = '" + BoxGrandeur.SelectedItem.ToString() +"'";
            MySqlDataReader reader = command.ExecuteReader();
            connection.Close();

            // on recupere les datas
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.assemblage;";
            reader = command.ExecuteReader();
            List<Assemblage> myListAssemblage = new List<Assemblage>();
            while (reader.Read())// parcours ligne par ligne
            {
                myListAssemblage.Add(new Assemblage(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), reader.GetValue(11).ToString(), reader.GetValue(12).ToString(), reader.GetValue(13).ToString()));

            }
            mw.myGridAssemblage.ItemsSource = myListAssemblage;
            mw.myGridAssemblage.Items.Refresh();
            connection.Close();

            this.Close();
        }
    }
}
