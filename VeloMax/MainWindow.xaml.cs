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
            /*
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
            }*/
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
        public DataGrid myGridClientParti = new DataGrid();
        public DataGrid myGridClientEntre = new DataGrid();
        public List<Particulier> myListClientParti = new List<Particulier>();
        public List<Entreprise> myListClientEntre = new List<Entreprise>();
        public int keyClient = 0;
        public int keyClientEntre = 0;
        public int keyClientPart = 0;
        Grid DynamicGridCommands = new Grid();
        Grid DynamicGridStats = new Grid();
        public DataGrid myGridStat = new DataGrid();
        public DataGrid myGridBicyQ = new DataGrid();
        public DataGrid myGridPieceQ = new DataGrid();
        public List<Bicyclette> myListBicyQ = new List<Bicyclette>();
        public List<PieceDetache> myListPieceDetQ = new List<PieceDetache>();
        Grid DynamicGridFournisseur = new Grid();
        Grid DynamicGridDemo = new Grid();
        //Demo
        public MediaElement meVideo = new MediaElement();
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
            btnModifAssemblage.Click += new RoutedEventHandler(ButtonModifAssemblage);
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
            btnModifBicy.Click += new RoutedEventHandler(ButtonModifBicy);
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
                keyPiece = Convert.ToInt32(reader.GetValue(2));
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
            btnModifPiece.Click += new RoutedEventHandler(ButtonModifPiece);
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
            /* ==== Creation partie Client ====*/
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
            txtBlock0.Text = "Liste des Clients Particulier";
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
            myGridClientParti.Items.Clear();
            myGridClientParti.Width = 700;
            myGridClientParti.Height = 100;

            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.particulier NATURAL JOIN velomax.clientele;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())// parcours ligne par ligne
            {
                myListClientParti.Add(new Particulier(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(4)), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString()));
                keyClient = Convert.ToInt32(reader.GetValue(0));
                keyClientPart = Convert.ToInt32(reader.GetValue(1));
            }
            myGridClientParti.ItemsSource = myListClientParti;
            connection.Close();

            //on define le reste
            myGridClientParti.Foreground = new SolidColorBrush(Colors.Black);
            myGridClientParti.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridClientParti.Margin = new Thickness(0, -22, 0, 0);
            myGridClientParti.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridClientParti.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridClientParti.IsReadOnly = true;
            Grid.SetRow(myGridClientParti, 1);
            Grid.SetColumn(myGridClientParti, 0);
            Grid.SetColumnSpan(myGridClientParti, 6);
            DynamicGridClient.Children.Add(myGridClientParti);



            //Btn ajouter
            Button btnAddClientParti = new Button();
            btnAddClientParti.Content = "";
            btnAddClientParti.Background = Brushes.Green;
            btnAddClientParti.Height = 15;
            btnAddClientParti.Width = 15;
            Grid.SetRow(btnAddClientParti, 0);
            Grid.SetColumn(btnAddClientParti, 0);
            Grid.SetColumnSpan(btnAddClientParti, 6);
            btnAddClientParti.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddClientParti.Margin = new Thickness(225, -12, 0, 0);
            btnAddClientParti.ToolTip = "Ajouter un Client Particulier";
            btnAddClientParti.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddClientParti.Click += new RoutedEventHandler(OpenAddClientParticulier);
            DynamicGridClient.Children.Add(btnAddClientParti);

            //Btn modifier
            Button btnModifClientParti = new Button();
            btnModifClientParti.Content = "";
            btnModifClientParti.Background = Brushes.Green;
            btnModifClientParti.Height = 15;
            btnModifClientParti.Width = 15;
            Grid.SetRow(btnModifClientParti, 0);
            Grid.SetColumn(btnModifClientParti, 0);
            Grid.SetColumnSpan(btnModifClientParti, 6);
            btnModifClientParti.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifClientParti.Margin = new Thickness(275, -12, 0, 0);
            btnModifClientParti.ToolTip = "Modifier un Client Particulier";
            btnModifClientParti.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            btnModifClientParti.Click += new RoutedEventHandler(ModifClientParticulier);
            DynamicGridClient.Children.Add(btnModifClientParti);

            //Btn del
            Button btnSuprClientParti = new Button();
            btnSuprClientParti.Content = "";
            btnSuprClientParti.Background = Brushes.Red;
            btnSuprClientParti.Height = 15;
            btnSuprClientParti.Width = 15;
            Grid.SetRow(btnSuprClientParti, 0);
            Grid.SetColumn(btnSuprClientParti, 0);
            Grid.SetColumnSpan(btnSuprClientParti, 6);
            btnSuprClientParti.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprClientParti.ToolTip = "Supprimer un Client Particulier";
            btnSuprClientParti.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprClientParti.Margin = new Thickness(325, -12, 0, 0);
            //btnSuprClientParti.Click += new RoutedEventHandler(ButtonSupClient);
            DynamicGridClient.Children.Add(btnSuprClientParti);



            // Client entreprise
            // titre 1
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Liste des Client Entreprise";
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
            myGridClientEntre.Items.Clear();
            myGridClientEntre.Width = 700;
            myGridClientEntre.Height = 100;

            // on recupere les datas
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.entreprise NATURAL JOIN velomax.clientele;";
            reader = command.ExecuteReader();

            while (reader.Read())// parcours ligne par ligne
            {
                myListClientEntre.Add(new Entreprise(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetValue(2).ToString(), (float)(reader.GetValue(3)), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString()));
                keyClient = Convert.ToInt32(reader.GetValue(0));
                keyClientEntre = Convert.ToInt32(reader.GetValue(1));
            }
            myGridClientEntre.ItemsSource = myListClientEntre;
            connection.Close();

            //on define le reste
            myGridClientEntre.Foreground = new SolidColorBrush(Colors.Black);
            myGridClientEntre.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridClientEntre.Margin = new Thickness(0, -22, 0, 0);
            myGridClientEntre.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridClientEntre.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridClientEntre.IsReadOnly = true;
            Grid.SetRow(myGridClientEntre, 3);
            Grid.SetColumn(myGridClientEntre, 0);
            Grid.SetColumnSpan(myGridClientEntre, 6);
            DynamicGridClient.Children.Add(myGridClientEntre);


            //Btn ajouter
            Button btnAddClientEntre = new Button();
            btnAddClientEntre.Content = "";
            btnAddClientEntre.Background = Brushes.Green;
            btnAddClientEntre.Height = 15;
            btnAddClientEntre.Width = 15;
            Grid.SetRow(btnAddClientEntre, 3);
            Grid.SetColumn(btnAddClientEntre, 0);
            Grid.SetColumnSpan(btnAddClientEntre, 6);
            btnAddClientEntre.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddClientEntre.Margin = new Thickness(225, -141, 0, 0);
            btnAddClientEntre.ToolTip = "Ajouter un Client Particulier";
            btnAddClientEntre.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddClientEntre.Click += new RoutedEventHandler(OpenAddClientEntreprise);
            DynamicGridClient.Children.Add(btnAddClientEntre);

            //Btn modifier
            Button btnModifClientEntre = new Button();
            btnModifClientEntre.Content = "";
            btnModifClientEntre.Background = Brushes.Green;
            btnModifClientEntre.Height = 15;
            btnModifClientEntre.Width = 15;
            Grid.SetRow(btnModifClientEntre, 3);
            Grid.SetColumn(btnModifClientEntre, 0);
            Grid.SetColumnSpan(btnModifClientEntre, 6);
            btnModifClientEntre.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifClientEntre.Margin = new Thickness(275, -141, 0, 0);
            btnModifClientEntre.ToolTip = "Modifier un Client Particulier";
            btnModifClientEntre.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            //btnModifClientEntre.Click += new RoutedEventHandler(ButtonModifClient);
            DynamicGridClient.Children.Add(btnModifClientEntre);

            //Btn del
            Button btnSuprClientEntre = new Button();
            btnSuprClientEntre.Content = "";
            btnSuprClientEntre.Background = Brushes.Red;
            btnSuprClientEntre.Height = 15;
            btnSuprClientEntre.Width = 15;
            Grid.SetRow(btnSuprClientEntre, 3);
            Grid.SetColumn(btnSuprClientEntre, 0);
            Grid.SetColumnSpan(btnSuprClientEntre, 6);
            btnSuprClientEntre.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprClientEntre.ToolTip = "Supprimer un Client Particulier";
            btnSuprClientEntre.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprClientEntre.Margin = new Thickness(325, -141, 0, 0);
            //btnSuprFidelio.Click += new RoutedEventHandler(ButtonSupClient);
            DynamicGridClient.Children.Add(btnSuprClientEntre);

        }
        #endregion Client
        #region Stats
        public void GeneStat()
        {
            /* ==== Creation partie Stat ====*/
            // création grid dynamic
            DynamicGridStats.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridStats.Height = 400;
            DynamicGridStats.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridStats.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridStats.Width = 780;

            // Create Columns
            Grid.SetRow(DynamicGridStats, 6);
            Grid.SetColumn(DynamicGridStats, 0);
            Grid.SetColumnSpan(DynamicGridStats, 6);
            ColumnDefinition gridColStat1 = new ColumnDefinition();
            DynamicGridStats.ColumnDefinitions.Add(gridColStat1);

            // Create Rows
            RowDefinition gridRowitem1 = new RowDefinition();
            gridRowitem1.Height = new GridLength(30);
            RowDefinition gridRowitem2 = new RowDefinition();
            gridRowitem2.Height = new GridLength(100);
            RowDefinition gridRowitem3 = new RowDefinition();
            gridRowitem3.Height = new GridLength(30);
            RowDefinition gridRowitem4 = new RowDefinition();
            gridRowitem4.Height = new GridLength(100);
            RowDefinition gridRowitem5 = new RowDefinition();
            gridRowitem5.Height = new GridLength(30);
            RowDefinition gridRowitem6 = new RowDefinition();
            gridRowitem6.Height = new GridLength(100);
            DynamicGridStats.RowDefinitions.Add(gridRowitem1);
            DynamicGridStats.RowDefinitions.Add(gridRowitem2);
            DynamicGridStats.RowDefinitions.Add(gridRowitem3);
            DynamicGridStats.RowDefinitions.Add(gridRowitem4);
            DynamicGridStats.RowDefinitions.Add(gridRowitem5);
            DynamicGridStats.RowDefinitions.Add(gridRowitem6);
            DynamicGridStats.Margin = new Thickness(0, 0, 0, 0);

            // titre 0
            TextBlock txtBlock0 = new TextBlock();
            txtBlock0.Text = "Liste des Pieces Det Vendus";
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
            DynamicGridStats.Children.Add(txtBlock0);

            // tableau des Pieces détachées vendues
            myGridPieceQ.Items.Clear();
            myGridPieceQ.Width = 700;
            myGridPieceQ.Height = 100;

            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT piecedetache.numpiece, descpiece, prixpiece, quantite FROM velomax.itemstock natural join velomax.piecedetache natural join velomax.itemcmd where idbicy is Null;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())// parcours ligne par ligne
            {
                PieceDetache temp_piece = new PieceDetache(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), 0, Convert.ToInt32(reader.GetValue(2)), new DateTime(), new DateTime(), 0, null);
                temp_piece.Quantite = Convert.ToInt32(reader.GetValue(3));
                myListPieceDetQ.Add(temp_piece);
            }
            myGridPieceQ.ItemsSource = myListPieceDetQ;
            //myGridPieceQ.Columns[0].Visibility = Visibility.Hidden;
            connection.Close();

            //on define le reste
            myGridPieceQ.Foreground = new SolidColorBrush(Colors.Black);
            myGridPieceQ.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridPieceQ.Margin = new Thickness(0, -22, 0, 0);
            myGridPieceQ.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridPieceQ.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridPieceQ.IsReadOnly = true;
            Grid.SetRow(myGridPieceQ, 1);
            Grid.SetColumn(myGridPieceQ, 0);
            Grid.SetColumnSpan(myGridPieceQ, 6);
            DynamicGridStats.Children.Add(myGridPieceQ);

            // titre 1
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Liste des Bicyclettes Vendues";
            txtBlock1.FontSize = 14;
            txtBlock1.Width = 700;
            txtBlock1.TextAlignment = TextAlignment.Center;
            txtBlock1.Background = new SolidColorBrush(Colors.Black);
            txtBlock1.Foreground = new SolidColorBrush(Colors.White);
            txtBlock1.VerticalAlignment = VerticalAlignment.Top;
            txtBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock1.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            Grid.SetColumnSpan(txtBlock1, 6);
            DynamicGridStats.Children.Add(txtBlock1);

            // tableau des Pieces détachées vendues
            myGridBicyQ.Items.Clear();
            myGridBicyQ.Width = 700;
            myGridBicyQ.Height = 100;

            // on recupere les datas
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT bicyclette.idbicy, nom, grandeur, prixbicy, quantite FROM velomax.itemstock natural join velomax.bicyclette natural join velomax.itemcmd where numpiece is Null; ; ";
            reader = command.ExecuteReader();

            while (reader.Read())// parcours ligne par ligne
            {
                //int idbicy, string nom, string grandeur, int prixbicy, string ligneproduit, DateTime dateintrobicy, DateTime datediscontinuationbicy
                Bicyclette temp_bicy = new Bicyclette(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), Convert.ToInt32(reader.GetValue(3)), null, new DateTime(), new DateTime());
                temp_bicy.Quantite = Convert.ToInt32(reader.GetValue(4));
                myListBicyQ.Add(temp_bicy);
            }
            myGridBicyQ.ItemsSource = myListBicyQ;
            connection.Close();

            //on define le reste
            myGridBicyQ.Foreground = new SolidColorBrush(Colors.Black);
            myGridBicyQ.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridBicyQ.Margin = new Thickness(0, -22, 0, 0);
            myGridBicyQ.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridBicyQ.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridBicyQ.IsReadOnly = true;
            Grid.SetRow(myGridBicyQ, 1);
            Grid.SetColumn(myGridBicyQ, 0);
            Grid.SetColumnSpan(myGridBicyQ, 6);
            DynamicGridStats.Children.Add(myGridBicyQ);
        }
        #endregion
        #region Demo
        public void GeneDemo()
        {
            /* ==== Creation partie matériel ====*/
            // création grid dynamic
            DynamicGridDemo.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridDemo.Height = 400;
            DynamicGridDemo.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridDemo.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridDemo.Width = 780;

            // Create Columns
            Grid.SetRow(DynamicGridDemo, 6);
            Grid.SetColumn(DynamicGridDemo, 0);
            Grid.SetColumnSpan(DynamicGridDemo, 6);
            ColumnDefinition gridColDemo1 = new ColumnDefinition();
            DynamicGridDemo.ColumnDefinitions.Add(gridColDemo1);
            ColumnDefinition gridColDemo2 = new ColumnDefinition();
            DynamicGridDemo.ColumnDefinitions.Add(gridColDemo2);

            // Create Rows
            RowDefinition gridRowDemo1 = new RowDefinition();
            gridRowDemo1.Height = new GridLength(50);
            RowDefinition gridRowDemo2 = new RowDefinition();
            gridRowDemo2.Height = new GridLength(50);
            RowDefinition gridRowDemo3 = new RowDefinition();
            gridRowDemo3.Height = new GridLength(50);
            RowDefinition gridRowDemo4 = new RowDefinition();
            gridRowDemo4.Height = new GridLength(50);
            RowDefinition gridRowDemo5 = new RowDefinition();
            gridRowDemo5.Height = new GridLength(50);
            RowDefinition gridRowDemo6 = new RowDefinition();
            gridRowDemo6.Height = new GridLength(50);
            RowDefinition gridRowDemo7 = new RowDefinition();
            gridRowDemo5.Height = new GridLength(50);
            RowDefinition gridRowDemo8 = new RowDefinition();
            gridRowDemo6.Height = new GridLength(50);
            DynamicGridDemo.RowDefinitions.Add(gridRowDemo1);
            DynamicGridDemo.RowDefinitions.Add(gridRowDemo2);
            DynamicGridDemo.RowDefinitions.Add(gridRowDemo3);
            DynamicGridDemo.RowDefinitions.Add(gridRowDemo4);
            DynamicGridDemo.RowDefinitions.Add(gridRowDemo5);
            DynamicGridDemo.RowDefinitions.Add(gridRowDemo6);
            DynamicGridDemo.RowDefinitions.Add(gridRowDemo7);
            DynamicGridDemo.RowDefinitions.Add(gridRowDemo8);
            DynamicGridDemo.Margin = new Thickness(0, 0, 0, 0);

            // titre 0
            TextBlock txtBlock0 = new TextBlock();
            txtBlock0.Text = "Video de présentation de Velomax YPA";
            txtBlock0.FontSize = 20;
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
            DynamicGridDemo.Children.Add(txtBlock0);

            // On genere la video 
            
            //meVideo.Source = new Uri("C:\\Users\\petil\\OneDrive\\Documents\\GitHub\\VeloMax\\VeloMax\\demoVideo.mp4");
            Uri test = new Uri("http://pierre-petillion.fr/musique/musique.mp4");
            meVideo.Source = test;
            //MessageBox.Show(meVideo.Source.PathAndQuery);
            meVideo.Height = 800;
            meVideo.Width = 800;
            Grid.SetRow(meVideo, 1);
            Grid.SetRowSpan(meVideo, 8);
            Grid.SetColumn(meVideo, 0);
            Grid.SetColumnSpan(meVideo, 2);
            meVideo.Opacity = 100;
            meVideo.Visibility = Visibility.Visible;
            meVideo.LoadedBehavior = MediaState.Manual;
            meVideo.Stretch = Stretch.Uniform;
            meVideo.StretchDirection = StretchDirection.DownOnly;


            //Bouton Pause

            Button btnPause = new Button();
            btnPause.Content = "";
            btnPause.Background = Brushes.Green;
            btnPause.Height = 45;
            btnPause.Width = 45;
            btnPause.Background = new ImageBrush(new BitmapImage(new Uri(@"https://svgsilh.com/png-1024/888513.png")));
            Grid.SetRow(btnPause, 6);
            Grid.SetColumn(btnPause, 1);
            Grid.SetColumnSpan(btnPause, 1);

            //Bouton Play

            Button btnPlay = new Button();
            btnPlay.Content = "";
            btnPlay.Background = Brushes.Green;
            btnPlay.Height = 45;
            btnPlay.Width = 45;
            btnPlay.Background = new ImageBrush(new BitmapImage(new Uri(@"http://assets.stickpng.com/images/580b57fcd9996e24bc43c4f7.png")));
            Grid.SetRow(btnPlay, 6);
            Grid.SetColumn(btnPlay, 0);
            Grid.SetColumnSpan(btnPlay, 1);

            //Slider temps

            //Slider tempsSlider = new Slider();
            //tempsSlider.Width = 200;
            //tempsSlider.Header = "Volume";
            //tempsSlider.ValueChanged += Slider.ValueChanged;

            //meVideo.MouseDown += new MouseButtonEventHandler(meVideo_Clicked);
            meVideo.Play();
            btnPause.Click += new RoutedEventHandler(ButtonPauseVideo);
            btnPlay.Click += new RoutedEventHandler(ButtonPlayVideo);
            //myGrid.ColumnDefinitions.Add(meVideo);
            DynamicGridDemo.Children.Add(meVideo);
            DynamicGridDemo.Children.Add(btnPause);
            DynamicGridDemo.Children.Add(btnPlay);
            // myCanvas.Children.Add(myGrid);
        }

        #endregion Demo
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
            GeneStat();
            GeneDemo();
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

        private void ButtonModifAssemblage(object sender, RoutedEventArgs e)
        {           
            if (myGridAssemblage.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridAssemblage.SelectedItems)
                {
                    ModifAssemblage w = new ModifAssemblage(connection, ((Assemblage)o), this);
                    w.Show();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! vous en avez actuellement selectionné " + myGridAssemblage.SelectedItems.Count);
            }
            
        }

        private void OpenAddBicy(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddBicy(connection, this);
            WindowAddClient.Show();
            
        }

        private void ButtonModifBicy(object sender, RoutedEventArgs e)
        {
            if (myGridBicy.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridBicy.SelectedItems)
                {
                    ModifBicy w = new ModifBicy(connection, ((Bicyclette)o), this);
                    w.Show();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! vous en avez actuellement selectionné " + myGridBicy.SelectedItems.Count);
            }

        }

        private void OpenAddPiece(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddPiece(connection, this);
            WindowAddClient.Show();

        }

        private void ButtonModifPiece(object sender, RoutedEventArgs e)
        {
            if (myGridPiece.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridPiece.SelectedItems)
                {
                    ModifPiece w = new ModifPiece(connection, ((PieceDetache)o), this);
                    w.Show();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! vous en avez actuellement selectionné " + myGridBicy.SelectedItems.Count);
            }

        }
        
        #endregion Evenement Matériel

        #region Evenement Client
        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            ClientsBtn.Background = new SolidColorBrush(Colors.White);
            MainGrid.Children.Add(DynamicGridClient);
        }

        private void OpenAddClientParticulier(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddClientPart(connection, this);
            WindowAddClient.Show();
        }

        private void ModifClientParticulier(object sender, RoutedEventArgs e)
        {
            if (myGridClientParti.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridClientParti.SelectedItems)
                {
                    MotifClientParti w = new MotifClientParti(connection, ((Particulier)o), this);
                    w.Show();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! vous en avez actuellement selectionné " + myGridAssemblage.SelectedItems.Count);
            }

        }

        private void OpenAddClientEntreprise(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddClientEntre(connection, this);
            WindowAddClient.Show();
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

        #region Evenement Statistique
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
            MainGrid.Children.Add(DynamicGridDemo);
        }

        private void ButtonPauseVideo(object sender, RoutedEventArgs e)
        {
            meVideo.Pause();
        }

        private void ButtonPlayVideo(object sender, RoutedEventArgs e)
        {
            meVideo.Play();
        }


        #endregion Evenement Demo
        #endregion Evenement

    }
}