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
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace VeloMax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Gestion DB
        public static MySqlConnection createDB()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=velomax;UID=root;PASSWORD=root;SSLMODE=none;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("Connection Established!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error!\n" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return connection;
        }
        #endregion

        #region Variable Globale
        //Creation de l'objet mysql
        MySqlConnection connection = createDB();

        // permet de savoir la fenetre actuel
        // On crée toutes les pages dynamique
        Grid DynamicGridMateriel = new Grid();
        public DataGrid myGridAssemblage = new DataGrid();
        public DataGrid myGridBicy = new DataGrid();
        public DataGrid myGridPiece = new DataGrid();
        public int keyBicy = 0;
        public int keyPiece = 0;
        public List<Assemblage> myListAssemblage = new List<Assemblage>();
        public List<Bicyclette> myListBicy = new List<Bicyclette>();
        public List<PieceDetache> myListPiece = new List<PieceDetache>();

        Grid DynamicGridClient = new Grid();
        public DataGrid myGridClient = new DataGrid();
        public DataGrid myGridFidelio = new DataGrid();
        public List<clientele> myListClient = new List<clientele>();
        public List<Fidelio> myListFidelio = new List<Fidelio>();
        Grid DynamicGridCommands = new Grid();
        Grid DynamicGridStats = new Grid();
        Grid DynamicGridFournisseur = new Grid();
        Grid DynamicGridDemo = new Grid();
        #endregion

        #region Génération
        #region Generation Materiel
        public void GeneMateriel()
        {
            /* ==== Creation partie matériel ====*/
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
            DynamicGridMateriel.Margin = new Thickness(0, 0, 0, 0);

            // titre 0
            TextBlock txtBlock0 = new TextBlock();
            txtBlock0.Text = "Liste des assemblages";
            txtBlock0.FontSize = 14;
            txtBlock0.Width = 700;
            txtBlock0.TextAlignment = TextAlignment.Center;
            txtBlock0.Background = new SolidColorBrush(Colors.Black);
            txtBlock0.Foreground = new SolidColorBrush(Colors.White);
            txtBlock0.VerticalAlignment = VerticalAlignment.Top;
            txtBlock0.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock0.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtBlock0, 0);
            Grid.SetColumn(txtBlock0, 0);
            Grid.SetColumnSpan(txtBlock0, 6);
            DynamicGridMateriel.Children.Add(txtBlock0);

            // tableau des bicyclette
            myGridAssemblage.Items.Clear();
            myGridAssemblage.Width = 700;
            myGridAssemblage.Height = 100;

            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.assemblage;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                myListAssemblage.Add(new Assemblage(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), reader.GetValue(11).ToString(), reader.GetValue(12).ToString(), reader.GetValue(13).ToString()));

            }
            myGridAssemblage.ItemsSource = myListAssemblage;
            connection.Close();

            //on define le reste
            myGridAssemblage.Foreground = new SolidColorBrush(Colors.Black);
            myGridAssemblage.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridAssemblage.Margin = new Thickness(0, -22, 0, 0);
            myGridAssemblage.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridAssemblage.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridAssemblage.IsReadOnly = true;
            Grid.SetRow(myGridAssemblage, 1);
            Grid.SetColumn(myGridAssemblage, 0);
            Grid.SetColumnSpan(myGridAssemblage, 6);
            DynamicGridMateriel.Children.Add(myGridAssemblage);

            //Btn ajouter
            Button btnAddAssemblage = new Button();
            btnAddAssemblage.Content = "";
            btnAddAssemblage.Background = Brushes.Green;
            btnAddAssemblage.Height = 15;
            btnAddAssemblage.Width = 15;
            Grid.SetRow(btnAddAssemblage, 0);
            Grid.SetColumn(btnAddAssemblage, 0);
            Grid.SetColumnSpan(btnAddAssemblage, 6);
            btnAddAssemblage.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddAssemblage.Margin = new Thickness(175, -12, 0, 0);
            btnAddAssemblage.ToolTip = "Ajouter un Assemblage";
            btnAddAssemblage.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddAssemblage.Click += new RoutedEventHandler(OpenAddAssemblage);
            DynamicGridMateriel.Children.Add(btnAddAssemblage);

            //Btn modifier
            Button btnModifAssemblage = new Button();
            btnModifAssemblage.Content = "";
            btnModifAssemblage.Background = Brushes.Green;
            btnModifAssemblage.Height = 15;
            btnModifAssemblage.Width = 15;
            Grid.SetRow(btnModifAssemblage, 0);
            Grid.SetColumn(btnModifAssemblage, 0);
            Grid.SetColumnSpan(btnModifAssemblage, 6);
            btnModifAssemblage.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifAssemblage.Margin = new Thickness(225, -12, 0, 0);
            btnModifAssemblage.ToolTip = "Modifier un Assemblage";
            btnModifAssemblage.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            //btnModifAssemblage.Click += new RoutedEventHandler(ButtonModifClient);
            DynamicGridMateriel.Children.Add(btnModifAssemblage);

            //Btn del
            Button btnSuprAssemblage = new Button();
            btnSuprAssemblage.Content = "";
            btnSuprAssemblage.Background = Brushes.Red;
            btnSuprAssemblage.Height = 15;
            btnSuprAssemblage.Width = 15;
            Grid.SetRow(btnSuprAssemblage, 0);
            Grid.SetColumn(btnSuprAssemblage, 0);
            Grid.SetColumnSpan(btnSuprAssemblage, 6);
            btnSuprAssemblage.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprAssemblage.ToolTip = "Supprimer un Assemblage";
            btnSuprAssemblage.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprAssemblage.Margin = new Thickness(275, -12, 0, 0);
            //btnSuprClient.Click += new RoutedEventHandler(ButtonSupClient);
            DynamicGridMateriel.Children.Add(btnSuprAssemblage);

            // titre 1
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Liste des bicyclettes";
            txtBlock1.FontSize = 14;
            txtBlock1.Width = 700;
            txtBlock1.TextAlignment = TextAlignment.Center;
            txtBlock1.Background = new SolidColorBrush(Colors.Black);
            txtBlock1.Foreground = new SolidColorBrush(Colors.White);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtBlock1, 2);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 6);
            DynamicGridMateriel.Children.Add(txtBlock1);

            // tableau des bicyclette
            myGridBicy.Items.Clear();
            myGridBicy.Width = 700;
            myGridBicy.Height = 100;

            // on recupere les datas
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.bicyclette;";
            reader = command.ExecuteReader();
            
            while (reader.Read())// parcours ligne par ligne
            {
                myListBicy.Add(new Bicyclette(Convert.ToInt32(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), Convert.ToInt32(reader.GetValue(3).ToString()), reader.GetValue(4).ToString(), Convert.ToDateTime(reader.GetValue(5)), Convert.ToDateTime(reader.GetValue(6))));
                keyBicy = Convert.ToInt32(reader.GetValue(0));
            }
            myGridBicy.ItemsSource = myListBicy;
            connection.Close();

            //on define le reste
            myGridBicy.Foreground = new SolidColorBrush(Colors.Black);
            myGridBicy.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridBicy.Margin = new Thickness(0, -22, 0, 0);
            myGridBicy.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridBicy.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridBicy.IsReadOnly = true;
            Grid.SetRow(myGridBicy, 3);
            Grid.SetColumn(myGridBicy, 0);
            Grid.SetColumnSpan(myGridBicy, 6);
            DynamicGridMateriel.Children.Add(myGridBicy);

            //Btn ajouter
            Button btnAddBicy = new Button();
            btnAddBicy.Content = "";
            btnAddBicy.Background = Brushes.Green;
            btnAddBicy.Height = 15;
            btnAddBicy.Width = 15;
            Grid.SetRow(btnAddBicy, 3);
            Grid.SetColumn(btnAddBicy, 0);
            Grid.SetColumnSpan(btnAddBicy, 6);
            btnAddBicy.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddBicy.Margin = new Thickness(175, -141, 0, 0);
            btnAddBicy.ToolTip = "Ajouter une Bicyclette";
            btnAddBicy.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddBicy.Click += new RoutedEventHandler(OpenAddBicy);
            DynamicGridMateriel.Children.Add(btnAddBicy);

            //Btn modifier
            Button btnModifBicy = new Button();
            btnModifBicy.Content = "";
            btnModifBicy.Background = Brushes.Green;
            btnModifBicy.Height = 15;
            btnModifBicy.Width = 15;
            Grid.SetRow(btnModifBicy, 3);
            Grid.SetColumn(btnModifBicy, 0);
            Grid.SetColumnSpan(btnModifBicy, 6);
            btnModifBicy.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifBicy.Margin = new Thickness(225, -141, 0, 0);
            btnModifBicy.ToolTip = "Modifier une Bicyclette";
            btnModifBicy.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            //btnModifClient.Click += new RoutedEventHandler(ButtonModifClient);
            DynamicGridMateriel.Children.Add(btnModifBicy);

            //Btn del
            Button btnSuprBicy = new Button();
            btnSuprBicy.Content = "";
            btnSuprBicy.Background = Brushes.Red;
            btnSuprBicy.Height = 15;
            btnSuprBicy.Width = 15;
            Grid.SetRow(btnSuprBicy, 3);
            Grid.SetColumn(btnSuprBicy, 0);
            Grid.SetColumnSpan(btnSuprBicy, 6);
            btnSuprBicy.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprBicy.ToolTip = "Supprimer une Bicyclette";
            btnSuprBicy.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprBicy.Margin = new Thickness(275, -141, 0, 0);
            //btnSuprClient.Click += new RoutedEventHandler(ButtonSupClient);
            DynamicGridMateriel.Children.Add(btnSuprBicy);

            // titre 2
            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.Text = "Liste des pieces";
            txtBlock2.FontSize = 14;
            txtBlock2.Width = 700;
            txtBlock2.TextAlignment = TextAlignment.Center;
            txtBlock2.Background = new SolidColorBrush(Colors.Black);
            txtBlock2.Foreground = new SolidColorBrush(Colors.White);
            txtBlock2.VerticalAlignment = VerticalAlignment.Top;
            txtBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock2.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtBlock2, 4);
            Grid.SetColumn(txtBlock2, 0);
            Grid.SetColumnSpan(txtBlock2, 6);
            DynamicGridMateriel.Children.Add(txtBlock2);

            // tableau des bicyclette
            myGridPiece.Items.Clear();
            myGridPiece.Width = 700;
            myGridPiece.Height = 100;

            // on recupere les datas
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.piecedetache;";
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                myListPiece.Add(new PieceDetache(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2).ToString()), Convert.ToInt32(reader.GetValue(3).ToString()), Convert.ToDateTime(reader.GetValue(4).ToString()), Convert.ToDateTime(reader.GetValue(5).ToString()), Convert.ToInt32(reader.GetValue(6).ToString()), reader.GetValue(7).ToString()));
            }
            myGridPiece.ItemsSource = myListPiece;
            connection.Close();

            //on define le reste
            myGridPiece.Foreground = new SolidColorBrush(Colors.Black);
            myGridPiece.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridPiece.Margin = new Thickness(0, -22, 0, 0);
            myGridPiece.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridPiece.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridPiece.IsReadOnly = true;
            Grid.SetRow(myGridPiece, 5);
            Grid.SetColumn(myGridPiece, 0);
            Grid.SetColumnSpan(myGridPiece, 6);
            DynamicGridMateriel.Children.Add(myGridPiece);

            //Btn ajouter
            Button btnAddPiece = new Button();
            btnAddPiece.Content = "";
            btnAddPiece.Background = Brushes.Green;
            btnAddPiece.Height = 15;
            btnAddPiece.Width = 15;
            Grid.SetRow(btnAddPiece, 5);
            Grid.SetColumn(btnAddPiece, 0);
            Grid.SetColumnSpan(btnAddPiece, 6);
            btnAddPiece.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddPiece.Margin = new Thickness(175, -141, 0, 0);
            btnAddPiece.ToolTip = "Ajouter une Piece";
            btnAddPiece.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddPiece.Click += new RoutedEventHandler(OpenAddPiece);
            DynamicGridMateriel.Children.Add(btnAddPiece);

            //Btn modifier
            Button btnModifPiece = new Button();
            btnModifPiece.Content = "";
            btnModifPiece.Background = Brushes.Green;
            btnModifPiece.Height = 15;
            btnModifPiece.Width = 15;
            Grid.SetRow(btnModifPiece, 5);
            Grid.SetColumn(btnModifPiece, 0);
            Grid.SetColumnSpan(btnModifPiece, 6);
            btnModifPiece.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifPiece.Margin = new Thickness(225, -141, 0, 0);
            btnModifPiece.ToolTip = "Modifier une Piece";
            btnModifPiece.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            //btnModifClient.Click += new RoutedEventHandler(ButtonModifClient);
            DynamicGridMateriel.Children.Add(btnModifPiece);

            //Btn del
            Button btnSuprPiece = new Button();
            btnSuprPiece.Content = "";
            btnSuprPiece.Background = Brushes.Red;
            btnSuprPiece.Height = 15;
            btnSuprPiece.Width = 15;
            Grid.SetRow(btnSuprPiece, 5);
            Grid.SetColumn(btnSuprPiece, 0);
            Grid.SetColumnSpan(btnSuprPiece, 6);
            btnSuprPiece.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprPiece.ToolTip = "Supprimer une Piece";
            btnSuprPiece.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprPiece.Margin = new Thickness(275, -141, 0, 0);
            //btnSuprClient.Click += new RoutedEventHandler(ButtonSupClient);
            DynamicGridMateriel.Children.Add(btnSuprPiece);
        }
        #endregion Generation Materiel
        
        #region Client
        public void GeneClient()
        {
            /* ==== Creation partie matériel ====*/
            // création grid dynamic
            DynamicGridClient.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridClient.Height = 400;
            DynamicGridClient.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridClient.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridClient.Width = 780;

            // Create Columns
            Grid.SetRow(DynamicGridClient, 6);
            Grid.SetColumn(DynamicGridClient, 0);
            Grid.SetColumnSpan(DynamicGridClient, 6);
            ColumnDefinition gridColClient1 = new ColumnDefinition();
            DynamicGridClient.ColumnDefinitions.Add(gridColClient1);

            // Create Rows
            RowDefinition gridRowClient1 = new RowDefinition();
            gridRowClient1.Height = new GridLength(30);
            RowDefinition gridRowClient2 = new RowDefinition();
            gridRowClient2.Height = new GridLength(100);
            RowDefinition gridRowClient3 = new RowDefinition();
            gridRowClient3.Height = new GridLength(30);
            RowDefinition gridRowClient4 = new RowDefinition();
            gridRowClient4.Height = new GridLength(100);
            RowDefinition gridRowClient5 = new RowDefinition();
            gridRowClient5.Height = new GridLength(30);
            RowDefinition gridRowClient6 = new RowDefinition();
            gridRowClient6.Height = new GridLength(100);
            DynamicGridClient.RowDefinitions.Add(gridRowClient1);
            DynamicGridClient.RowDefinitions.Add(gridRowClient2);
            DynamicGridClient.RowDefinitions.Add(gridRowClient3);
            DynamicGridClient.RowDefinitions.Add(gridRowClient4);
            DynamicGridClient.RowDefinitions.Add(gridRowClient5);
            DynamicGridClient.RowDefinitions.Add(gridRowClient6);
            DynamicGridClient.Margin = new Thickness(0, 0, 0, 0);

            // titre 0
            TextBlock txtBlock0 = new TextBlock();
            txtBlock0.Text = "Liste des Clients";
            txtBlock0.FontSize = 14;
            txtBlock0.Width = 700;
            txtBlock0.TextAlignment = TextAlignment.Center;
            txtBlock0.Background = new SolidColorBrush(Colors.Black);
            txtBlock0.Foreground = new SolidColorBrush(Colors.White);
            txtBlock0.VerticalAlignment = VerticalAlignment.Top;
            txtBlock0.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock0.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtBlock0, 0);
            Grid.SetColumn(txtBlock0, 0);
            Grid.SetColumnSpan(txtBlock0, 6);
            DynamicGridClient.Children.Add(txtBlock0);

            // tableau des Clients
            myGridClient.Items.Clear();
            myGridClient.Width = 700;
            myGridClient.Height = 100;

            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.clientele;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())// parcours ligne par ligne
            {
                myListClient.Add(new clientele(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2)), reader.GetValue(3).ToString(), reader.GetValue(4).ToString()));

            }
            myGridClient.ItemsSource = myListClient;
            connection.Close();

            //on define le reste
            myGridClient.Foreground = new SolidColorBrush(Colors.Black);
            myGridClient.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridClient.Margin = new Thickness(0, -22, 0, 0);
            myGridClient.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridClient.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridClient.IsReadOnly = true;
            Grid.SetRow(myGridClient, 1);
            Grid.SetColumn(myGridClient, 0);
            Grid.SetColumnSpan(myGridClient, 6);
            DynamicGridClient.Children.Add(myGridClient);

            //Btn ajouter
            Button btnAddClient = new Button();
            btnAddClient.Content = "";
            btnAddClient.Background = Brushes.Green;
            btnAddClient.Height = 15;
            btnAddClient.Width = 15;
            Grid.SetRow(btnAddClient, 0);
            Grid.SetColumn(btnAddClient, 0);
            Grid.SetColumnSpan(btnAddClient, 6);
            btnAddClient.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddClient.Margin = new Thickness(175, -12, 0, 0);
            btnAddClient.ToolTip = "Ajouter un Client";
            btnAddClient.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            //btnAddClient.Click += new RoutedEventHandler(OpenAddAssemblage);
            DynamicGridClient.Children.Add(btnAddClient);

            //Btn modifier
            Button btnModifClient = new Button();
            btnModifClient.Content = "";
            btnModifClient.Background = Brushes.Green;
            btnModifClient.Height = 15;
            btnModifClient.Width = 15;
            Grid.SetRow(btnModifClient, 0);
            Grid.SetColumn(btnModifClient, 0);
            Grid.SetColumnSpan(btnModifClient, 6);
            btnModifClient.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifClient.Margin = new Thickness(225, -12, 0, 0);
            btnModifClient.ToolTip = "Modifier un Client";
            btnModifClient.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            //btnModifClient.Click += new RoutedEventHandler(ButtonModifClient);
            DynamicGridClient.Children.Add(btnModifClient);

            //Btn del
            Button btnSuprClient = new Button();
            btnSuprClient.Content = "";
            btnSuprClient.Background = Brushes.Red;
            btnSuprClient.Height = 15;
            btnSuprClient.Width = 15;
            Grid.SetRow(btnSuprClient, 0);
            Grid.SetColumn(btnSuprClient, 0);
            Grid.SetColumnSpan(btnSuprClient, 6);
            btnSuprClient.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprClient.ToolTip = "Supprimer un Client";
            btnSuprClient.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprClient.Margin = new Thickness(275, -12, 0, 0);
            //btnSuprClient.Click += new RoutedEventHandler(ButtonSupClient);
            DynamicGridClient.Children.Add(btnSuprClient);

            // Fidelio
            // titre 1
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Liste des Fidelios";
            txtBlock1.FontSize = 14;
            txtBlock1.Width = 700;
            txtBlock1.TextAlignment = TextAlignment.Center;
            txtBlock1.Background = new SolidColorBrush(Colors.Black);
            txtBlock1.Foreground = new SolidColorBrush(Colors.White);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtBlock1, 2);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 6);
            DynamicGridClient.Children.Add(txtBlock1);

            // tableau des Fidelios
            myGridFidelio.Items.Clear();
            myGridFidelio.Width = 700;
            myGridFidelio.Height = 100;

            // on recupere les datas
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.fidelio;";
            reader = command.ExecuteReader();
            
            while (reader.Read())// parcours ligne par ligne
            {
                myListFidelio.Add(new Fidelio(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2)), Convert.ToInt32(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4))));
            }
            myGridFidelio.ItemsSource = myListBicy;
            connection.Close();

            //on define le reste
            myGridFidelio.Foreground = new SolidColorBrush(Colors.Black);
            myGridFidelio.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridFidelio.Margin = new Thickness(0, -22, 0, 0);
            myGridFidelio.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridFidelio.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridFidelio.IsReadOnly = true;
            Grid.SetRow(myGridFidelio, 3);
            Grid.SetColumn(myGridFidelio, 0);
            Grid.SetColumnSpan(myGridFidelio, 6);
            DynamicGridClient.Children.Add(myGridFidelio);

            //Btn ajouter
            Button btnAddFidelio = new Button();
            btnAddFidelio.Content = "";
            btnAddFidelio.Background = Brushes.Green;
            btnAddFidelio.Height = 15;
            btnAddFidelio.Width = 15;
            Grid.SetRow(btnAddFidelio, 3);
            Grid.SetColumn(btnAddFidelio, 0);
            Grid.SetColumnSpan(btnAddFidelio, 6);
            btnAddFidelio.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddFidelio.Margin = new Thickness(175, -141, 0, 0);
            btnAddFidelio.ToolTip = "Ajouter un Fidelio";
            btnAddFidelio.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            //btnAddFidelio.Click += new RoutedEventHandler(OpenAddBicy);
            DynamicGridClient.Children.Add(btnAddFidelio);

            //Btn modifier
            Button btnModifFidelio = new Button();
            btnModifFidelio.Content = "";
            btnModifFidelio.Background = Brushes.Green;
            btnModifFidelio.Height = 15;
            btnModifFidelio.Width = 15;
            Grid.SetRow(btnModifFidelio, 3);
            Grid.SetColumn(btnModifFidelio, 0);
            Grid.SetColumnSpan(btnModifFidelio, 6);
            btnModifFidelio.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifFidelio.Margin = new Thickness(225, -141, 0, 0);
            btnModifFidelio.ToolTip = "Modifier un Fidelio";
            btnModifFidelio.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            //btnModifFidelio.Click += new RoutedEventHandler(ButtonModifClient);
            DynamicGridMateriel.Children.Add(btnModifFidelio);

            //Btn del
            Button btnSuprFidelio = new Button();
            btnSuprFidelio.Content = "";
            btnSuprFidelio.Background = Brushes.Red;
            btnSuprFidelio.Height = 15;
            btnSuprFidelio.Width = 15;
            Grid.SetRow(btnSuprFidelio, 3);
            Grid.SetColumn(btnSuprFidelio, 0);
            Grid.SetColumnSpan(btnSuprFidelio, 6);
            btnSuprFidelio.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprFidelio.ToolTip = "Supprimer un Fidelio";
            btnSuprFidelio.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprFidelio.Margin = new Thickness(275, -141, 0, 0);
            //btnSuprFidelio.Click += new RoutedEventHandler(ButtonSupClient);
            DynamicGridMateriel.Children.Add(btnSuprFidelio);
        }
        #endregion Client
        #endregion Generation

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
            GeneClient();
            //requeteSQL(connection);
        }
        #endregion

        #region Evenement
        #region Evenement Matériel
        private void MaterielBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            MaterielBtn.Background = new SolidColorBrush(Colors.White);
            MainGrid.Children.Add(DynamicGridMateriel);
        }

        private void OpenAddAssemblage(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddAssemblage(connection,this);
            WindowAddClient.Show();
        }

        private void OpenAddBicy(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddBicy(connection, this);
            WindowAddClient.Show();
            
        }

        private void OpenAddPiece(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddPiece(connection, this);
            WindowAddClient.Show();

        }
        #endregion Evenement Matériel

        #region Evenement Client
        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            ClientsBtn.Background = new SolidColorBrush(Colors.White);
            MainGrid.Children.Add(DynamicGridClient);
        }
        #endregion Evenement Client

        #region Evenement Commandes
        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            CommandesBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Amine");
        }
        #endregion Evenement Commandes

        #region Evenement Commandes
        private void StatistiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            StatistiqueBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Amine");
        }
        #endregion Evenement Commandes

        #region Evenement Fournisseur
        private void FournisseurBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            FournisseurBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Yanis");
        }
        #endregion Evenement Fournisseur

        #region Evenement Demo
        private void DemoBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            DemoBtn.Background = new SolidColorBrush(Colors.White);
            MessageBox.Show("En cour de dev par Yanis");
        }
        #endregion Evenement Demo
        #endregion Evenement

    }
}