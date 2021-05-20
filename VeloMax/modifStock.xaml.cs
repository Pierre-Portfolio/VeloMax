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
    /// Logique d'interaction pour modifStock.xaml
    /// </summary>
    public partial class modifStock : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;
        public ItemStock i1;
        public string affichagedebut = "";
        public modifStock(MySqlConnection connection, ItemStock i1 , MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;
            this.i1 = i1;

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select nom, grandeur, ligneproduit from velomax.bicyclette";
            MySqlDataReader reader = command.ExecuteReader();
            List<string> listItems = new List<string>();
            while (reader.Read())// parcours ligne par ligne
            {
                listItems.Add($"Bicyclette : {reader.GetValue(0)} | {reader.GetValue(1)} | {reader.GetValue(2)}");
            }
            connection.Close();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select numpiece,descpiece from velomax.piecedetache";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                listItems.Add($"Piece : {reader.GetValue(0)} | {reader.GetValue(1)}");
            }
            connection.Close();
            BoxItemStock.ItemsSource = listItems;

            if (i1.Idbicy != 0)
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "select nom, grandeur, ligneproduit from velomax.bicyclette where idbicy = " + i1.Idbicy + ";";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BoxItemStock.SelectedItem = $"Bicyclette : {reader.GetValue(0)} | {reader.GetValue(1)} | {reader.GetValue(2)}";
                }
                connection.Close();
            }
            else
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "select numpiece,descpiece from velomax.piecedetache where numpiece = '" + i1.Numpiece + "';";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BoxItemStock.SelectedItem = $"Piece : {reader.GetValue(0)} | {reader.GetValue(1)}";
                }
                connection.Close();
            }
            affichagedebut = BoxItemStock.SelectedItem.ToString();
        }

        private void ModifStock(object sender, RoutedEventArgs e)
        {
            if (BoxItemStock.Text != "" && BoxItemStock.Text.Length != 0)
            {
                if (affichagedebut != BoxItemStock.SelectedItem.ToString())
                {
                    
                    string[] recupItems = BoxItemStock.Text.ToString().Split();

                    if (recupItems[0] == "Bicyclette")
                    {

                        // on recupere les datas
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT idbicy FROM velomax.bicyclette where nom = '" + recupItems[2] + "' AND grandeur = '" + recupItems[4] + "';";
                        MySqlDataReader reader;
                        reader = command.ExecuteReader();
                        string res = "";
                        while (reader.Read())// parcours ligne par ligne
                        {
                            res = reader.GetValue(0).ToString();
                        }
                        connection.Close();

                        
                        connection.Open();
                        command = connection.CreateCommand();
                        command.CommandText = "UPDATE velomax.itemstock SET idbicy = '" + res + "' , numpiece = null WHERE iditemstock = " + i1.Iditemstock + ";";
                        reader = command.ExecuteReader();
                        connection.Close();
                    }
                    else
                    {
                        
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "UPDATE velomax.itemstock SET numpiece = '" + recupItems[2] + "' , idbicy = null WHERE iditemstock = " + i1.Iditemstock + ";";
                        MySqlDataReader reader = command.ExecuteReader();
                        connection.Close();
                        
                     }
                }
                else
                {
                    MessageBox.Show("Aucune modification effectué !");
                }


                mw.RefreshItemStock();
                this.Close();

            }
            else
            {
                MessageBox.Show("Erreur le champ de choix d'item est vide !");
            }
        }
    }
}
