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
        public MainWindow()
        {
        
        }
    }
}