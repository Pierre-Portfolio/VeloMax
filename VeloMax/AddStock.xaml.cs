﻿using System;
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
    /// Logique d'interaction pour AddStock.xaml
    /// </summary>
    public partial class AddStock : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;

        public AddStock(MySqlConnection connection, MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;

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
            while (reader.Read())// parcours ligne par ligne
            {
                listItems.Add($"Piece : {reader.GetValue(0)} | {reader.GetValue(1)}");
            }
            connection.Close();
            BoxItemStock.ItemsSource = listItems;
        }

        private void AjouterStock(object sender, RoutedEventArgs e)
        {
            if (BoxItemStock.Text != "" && BoxItemStock.Text.Length != 0)
            {

            }
            else
            {
                MessageBox.Show("Erreur le champ de choix d'item est vide !");
            }
        }

    }
}
