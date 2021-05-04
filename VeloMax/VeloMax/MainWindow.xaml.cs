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
        // creation de l'objet mysql
        MySqlConnection connection = createDB();

        /*
        // permet de savoir la fenetre actuel
        // On crée toutes les pages dynamique
        Grid DynamicGridClient = new Grid();
        public DataGrid myGridClient = new DataGrid();
        public DataGrid myGridCommis = new DataGrid();
        public DataGrid myGridLivreur = new DataGrid();

        Grid DynamicGridCommands = new Grid();
        ListView ListeViewCommande = new ListView();
        ComboBox cbRecherche = new ComboBox();

        Grid DynamicGridStat = new Grid();
        Grid DynamicGridAdmin = new Grid();
        */
        #endregion

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
        }

        #endregion Refresh

        public MainWindow()
        {
        
        }

        #region Evenement
        private void MaterielBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            MaterielBtn.Background = new SolidColorBrush(Colors.Olive) { Opacity = 0 };
            MessageBox.Show("En cour de dev par Pierre");
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            ClientsBtn.Background = new SolidColorBrush(Colors.Olive) { Opacity = 0 };
            MessageBox.Show("En cour de dev par Pierre");
        }

        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            CommandesBtn.Background = new SolidColorBrush(Colors.Olive) { Opacity = 0 };
            MessageBox.Show("En cour de dev par Amine");
        }

        private void StatistiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            StatistiqueBtn.Background = new SolidColorBrush(Colors.Olive) { Opacity = 0 };
            MessageBox.Show("En cour de dev par Amine");
        }

        private void FournisseurBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            FournisseurBtn.Background = new SolidColorBrush(Colors.Olive) { Opacity = 0 };
            MessageBox.Show("En cour de dev par Yanis");
        }

        private void DemoBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            DemoBtn.Background = new SolidColorBrush(Colors.Olive) { Opacity = 0 };
            MessageBox.Show("En cour de dev par Yanis");
        }
        #endregion Evenement
    }
}