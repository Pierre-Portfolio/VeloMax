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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net.NetworkInformation;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace VeloMax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region creation DB
        public static MySqlConnection createDB()
        {
            MySqlConnection maConnexion = null;
            maConnexion = new MySqlConnection("SERVER=localhost;PORT=3306;" + "DATABASE=velomax;" + "UID=root;PASSWORD=root;");
            return maConnexion;
            //maConnexion.Open();
            //maConnexion.Close();
        }
        #endregion 

        #region Variable Globale
        //Creation de l'objet mysql
        MySqlConnection connection = createDB();

        // permet de savoir la fenetre actuel
        // On crée toutes les pages dynamique
        public Grid DynamicGridMateriel = new Grid();
        public Grid DynamicGridClient = new Grid();
        public Grid DynamicGridCommands = new Grid();
        public Grid DynamicGridStats = new Grid();
        public Grid DynamicGridFournisseur = new Grid();
        public Grid DynamicGridDemo = new Grid();
        #endregion

        #region Generation DynamicGrid
        public void GeneMateriel()
        {
            /* ==== Creation partie client ====*/
            // création grid dynamic
            DynamicGridMateriel.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridMateriel.Height = 400;
            DynamicGridMateriel.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridMateriel.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridMateriel.Width = 780;

            // Create Columns
            Grid.SetRow(DynamicGridMateriel, 6);
            Grid.SetColumn(DynamicGridMateriel, 0);
            Grid.SetColumnSpan(DynamicGridMateriel, 6);
            ColumnDefinition gridColMatos1 = new ColumnDefinition();
            DynamicGridMateriel.ColumnDefinitions.Add(gridColMatos1);

            // Create Rows
            RowDefinition gridRowMatos1 = new RowDefinition();
            gridRowMatos1.Height = new GridLength(30);
            RowDefinition gridRowMatos2 = new RowDefinition();
            gridRowMatos2.Height = new GridLength(100);
            RowDefinition gridRowMatos3 = new RowDefinition();
            gridRowMatos3.Height = new GridLength(30);
            RowDefinition gridRowMatos4 = new RowDefinition();
            gridRowMatos4.Height = new GridLength(100);
            RowDefinition gridRowMatos5 = new RowDefinition();
            gridRowMatos5.Height = new GridLength(30);
            RowDefinition gridRowMatos6 = new RowDefinition();
            gridRowMatos6.Height = new GridLength(100);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos1);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos2);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos3);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos4);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos5);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos6);
            DynamicGridMateriel.Margin = new Thickness(100, 20, 0, 0);

            // titre 1
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Liste des bicyclettes";
            txtBlock1.FontSize = 14;
            txtBlock1.Width = 700;
            txtBlock1.TextAlignment = TextAlignment.Center;
            txtBlock1.Background = new SolidColorBrush(Colors.Black);
            txtBlock1.Foreground = new SolidColorBrush(Colors.Green);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtBlock1, 2);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 1);
            DynamicGridMateriel.Children.Add(txtBlock1);
        }

        #endregion Generation DynamicGrid

        #region Refresh
        public void Refresh()
        {
            // on refresh les couleurs des bouttons
            MaterielBtn.Background = new SolidColorBrush(Colors.Green);
            ClientsBtn.Background = new SolidColorBrush(Colors.Green);
            CommandesBtn.Background = new SolidColorBrush(Colors.Green);
            StatistiqueBtn.Background = new SolidColorBrush(Colors.Green);
            FournisseurBtn.Background = new SolidColorBrush(Colors.Green);
            DemoBtn.Background = new SolidColorBrush(Colors.Green);
          
            // On refresh les dynamicGrid
            if (MainGrid.Children.Contains(DynamicGridMateriel))
            {
                MainGrid.Children.Remove(DynamicGridMateriel);
            }
            else if (MainGrid.Children.Contains(DynamicGridClient))
            {
                MainGrid.Children.Remove(DynamicGridClient);
            }
            else if (MainGrid.Children.Contains(DynamicGridCommands))
            {
                MainGrid.Children.Remove(DynamicGridCommands);
            }
            else if (MainGrid.Children.Contains(DynamicGridStats))
            {
                MainGrid.Children.Remove(DynamicGridStats);
            }
            else if (MainGrid.Children.Contains(DynamicGridFournisseur))
            {
                MainGrid.Children.Remove(DynamicGridFournisseur);
            }
            else if (MainGrid.Children.Contains(DynamicGridDemo))
            {
                MainGrid.Children.Remove(DynamicGridDemo);
            }
        }

        #endregion Refresh

        #region main
        public MainWindow()
        {
            //generation des 6 sous menu
            GeneMateriel();
            
        }
        #endregion

        #region Evenement
        private void MaterielBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            MaterielBtn.Background = new SolidColorBrush(Colors.White);

            MainGrid.Children.Add(DynamicGridMateriel);
            MessageBox.Show("En cour de dev par Pierre");
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            ClientsBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Pierre");
        }

        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            CommandesBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Amine");
        }

        private void StatistiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            StatistiqueBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Amine");
        }

        private void FournisseurBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            FournisseurBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Yanis");
        }

        private void DemoBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            DemoBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Yanis");
        }
        #endregion Evenement
    }
}