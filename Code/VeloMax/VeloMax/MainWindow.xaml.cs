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
using Newtonsoft.Json;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
//using Newtonsoft.Json.Linq;

namespace VeloMax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Gestion DB
        public static MySqlConnection CreateDB()
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
        public MySqlConnection connection = CreateDB();

        // permet de savoir la fenetre actuel
        // On crée toutes les pages dynamique
        public Grid DynamicGridMateriel = new Grid();
        public DataGrid myGridAssemblage = new DataGrid();
        public DataGrid myGridBicy = new DataGrid();
        public DataGrid myGridPiece = new DataGrid();
        public int keyBicy = 0;
        public int keyPiece = 0;
        public List<Assemblage> myListAssemblage = new List<Assemblage>();
        public List<Bicyclette> myListBicy = new List<Bicyclette>();
        public List<PieceDetache> myListPiece = new List<PieceDetache>();

        public Grid DynamicGridClient = new Grid();
        public DataGrid myGridClientParti = new DataGrid();
        public DataGrid myGridClientEntre = new DataGrid();
        public List<Particulier> myListClientParti = new List<Particulier>();
        public List<Entreprise> myListClientEntre = new List<Entreprise>();
        public int keyClient = 0;
        public int keyClientEntre = 0;
        public int keyClientPart = 0;

        public Grid DynamicGridCommands = new Grid();
        public List<commande> myListCommande = new List<commande>();
        public DataGrid myGridCommande = new DataGrid();
        public int keyCommande = 0;
        public int keyidItemCommande = 0;

        public Grid DynamicGridStats = new Grid();
        public DataGrid myGridStat = new DataGrid();
        public DataGrid myGridBicyQ = new DataGrid();
        public DataGrid myGridPieceQ = new DataGrid();
        public List<Bicyclette> myListBicyQ = new List<Bicyclette>();
        public List<PieceDetache> myListPieceDetQ = new List<PieceDetache>();

        public Grid DynamicGridFournisseur = new Grid();
        public List<Fournisseur> myListFournisseur = new List<Fournisseur>();
        public DataGrid myGridFournisseur = new DataGrid();
        public int keyFournisseur = 0;

        public Grid DynamicGridStock = new Grid();
        public List<ItemStock> myListStock = new List<ItemStock>();
        public DataGrid myGridStock = new DataGrid();
        public int keyStock = 0;

        public Grid DynamicGridDemo = new Grid();
        //Demo
        public MediaElement meVideo = new MediaElement();
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
            StockBtn.Background = new SolidColorBrush(Colors.Green);
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
            else if (MainGrid.Children.Contains(DynamicGridStock))
            {
                MainGrid.Children.Remove(DynamicGridStock);
            }
            else if (MainGrid.Children.Contains(DynamicGridDemo))
            {
                MainGrid.Children.Remove(DynamicGridDemo);
            }
        }

        public void RefreshAssemblage()
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.assemblage;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            myListAssemblage.Clear();
            while (reader.Read())// parcours ligne par ligne
            {
                myListAssemblage.Add(new Assemblage(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), reader.GetValue(11).ToString(), reader.GetValue(12).ToString(), reader.GetValue(13).ToString()));

            }
            myGridAssemblage.ItemsSource = myListAssemblage;
            myGridAssemblage.Items.Refresh();

            connection.Close();
        }

        public void RefreshBicyClette()
        {
            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.bicyclette;";
            MySqlDataReader reader = command.ExecuteReader();
            myListBicy.Clear();
            while (reader.Read())// parcours ligne par ligne
            {
                myListBicy.Add(new Bicyclette(Convert.ToInt32(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), Convert.ToInt32(reader.GetValue(3).ToString()), reader.GetValue(4).ToString(), Convert.ToDateTime(reader.GetValue(5)), Convert.ToDateTime(reader.GetValue(6))));
                keyBicy = Convert.ToInt32(reader.GetValue(0));
            }
            myGridBicy.ItemsSource = myListBicy;
            myGridBicy.Items.Refresh();
            connection.Close();
        }

        public void RefreshPiece()
        {
            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.piecedetache;";
            MySqlDataReader reader = command.ExecuteReader();
            myListPiece.Clear();
            while (reader.Read())// parcours ligne par ligne
            {
                myListPiece.Add(new PieceDetache(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2).ToString()), Convert.ToInt32(reader.GetValue(3).ToString()), Convert.ToDateTime(reader.GetValue(4).ToString()), Convert.ToDateTime(reader.GetValue(5).ToString()), Convert.ToInt32(reader.GetValue(6).ToString()), reader.GetValue(7).ToString()));
                keyPiece = Convert.ToInt32(reader.GetValue(2));
            }
            myGridPiece.ItemsSource = myListPiece;
            myGridPiece.Items.Refresh();
            connection.Close();
        }

        public void RefreshClientParti()
        {
            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.particulier NATURAL JOIN velomax.clientele;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            myListClientParti.Clear();
            while (reader.Read())// parcours ligne par ligne
            {
                myListClientParti.Add(new Particulier(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(4)), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString()));
                keyClient = Convert.ToInt32(reader.GetValue(0));
                keyClientPart = Convert.ToInt32(reader.GetValue(1));
            }
            myGridClientParti.ItemsSource = myListClientParti;
            myGridClientParti.Items.Refresh();
            connection.Close();
        }

        public void RefreshClientEntre()
        {
            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.entreprise NATURAL JOIN velomax.clientele;";
            MySqlDataReader reader = command.ExecuteReader();
            myListClientEntre.Clear();
            while (reader.Read())// parcours ligne par ligne
            {
                myListClientEntre.Add(new Entreprise(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetValue(2).ToString(), (float)(reader.GetValue(3)), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString()));
                keyClient = Convert.ToInt32(reader.GetValue(0));
                keyClientEntre = Convert.ToInt32(reader.GetValue(1));
            }
            myGridClientEntre.ItemsSource = myListClientEntre;
            myGridClientEntre.Items.Refresh();
            connection.Close();
        }

        public void RefreshCommandes()
        {
            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.commande;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            myListCommande.Clear();
            List<int> idItems = new List<int>(); 
            while (reader.Read())// parcours ligne par ligne
            {
                myListCommande.Add(new commande(Convert.ToInt32(reader.GetValue(0)), Convert.ToDateTime(reader.GetValue(1)), Convert.ToString(reader.GetValue(2)), Convert.ToDateTime(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4))));
                keyCommande = Convert.ToInt32(reader.GetValue(0));
            }
            myGridCommande.ItemsSource = myListCommande;

            myGridCommande.Items.Refresh();
            connection.Close();
        }

        public void RefreshFournisseur()
        {
            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.fournisseur;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            myListFournisseur.Clear();
            while (reader.Read())// parcours ligne par ligne
            {
                myListFournisseur.Add(new Fournisseur(Convert.ToString(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)), Convert.ToString(reader.GetValue(2)), Convert.ToString(reader.GetValue(3)), Convert.ToString(reader.GetValue(4))));
            }
            myGridFournisseur.ItemsSource = myListFournisseur;
            myGridFournisseur.Items.Refresh();
            connection.Close();
        }

        public void RefreshItemStock()
        {
            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.itemstock";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            myListStock.Clear();
            while (reader.Read())// parcours ligne par ligne
            {
                if (reader.GetValue(1).ToString() == "")
                {
                    myListStock.Add(new ItemStock(Convert.ToInt32(reader.GetValue(0)), 0, Convert.ToString(reader.GetValue(2))));
                }
                else
                {
                    myListStock.Add(new ItemStock(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), " "));
                }
            }
            myGridStock.ItemsSource = myListStock;
            myGridStock.Items.Refresh();
            connection.Close();
        }


        public void RefreshAll()
        {
            RefreshAssemblage();
            RefreshBicyClette();
            RefreshPiece();
            RefreshClientParti();
            RefreshClientEntre();
            RefreshCommandes();
        }

        #endregion Refresh

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
            Grid.SetColumnSpan(DynamicGridMateriel, 7);
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
            RowDefinition gridRowMatos7 = new RowDefinition();
            gridRowMatos7.Height = new GridLength(100);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos1);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos2);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos3);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos4);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos5);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos6);
            DynamicGridMateriel.RowDefinitions.Add(gridRowMatos7);
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
            Grid.SetColumnSpan(txtBlock0, 7);
            DynamicGridMateriel.Children.Add(txtBlock0);

            // tableau des assemblage
            myGridAssemblage.Items.Clear();
            myGridAssemblage.Width = 700;
            myGridAssemblage.Height = 100;

            RefreshAssemblage();

            //on define le reste
            myGridAssemblage.Foreground = new SolidColorBrush(Colors.Black);
            myGridAssemblage.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridAssemblage.Margin = new Thickness(0, -22, 0, 0);
            myGridAssemblage.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridAssemblage.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridAssemblage.IsReadOnly = true;
            Grid.SetRow(myGridAssemblage, 1);
            Grid.SetColumn(myGridAssemblage, 0);
            Grid.SetColumnSpan(myGridAssemblage, 7);
            DynamicGridMateriel.Children.Add(myGridAssemblage);

            //Btn ajouter
            Button btnAddAssemblage = new Button();
            btnAddAssemblage.Content = "";
            btnAddAssemblage.Background = Brushes.Green;
            btnAddAssemblage.Height = 15;
            btnAddAssemblage.Width = 15;
            Grid.SetRow(btnAddAssemblage, 0);
            Grid.SetColumn(btnAddAssemblage, 0);
            Grid.SetColumnSpan(btnAddAssemblage, 7);
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
            Grid.SetColumnSpan(btnModifAssemblage, 7);
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
            Grid.SetColumnSpan(btnSuprAssemblage, 7);
            btnSuprAssemblage.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprAssemblage.ToolTip = "Supprimer un Assemblage";
            btnSuprAssemblage.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprAssemblage.Margin = new Thickness(275, -12, 0, 0);
            btnSuprAssemblage.Click += new RoutedEventHandler(ButtonSupAssemblage);
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
            Grid.SetColumnSpan(txtBlock1, 7);
            DynamicGridMateriel.Children.Add(txtBlock1);

            // tableau des bicyclette
            myGridBicy.Items.Clear();
            myGridBicy.Width = 700;
            myGridBicy.Height = 100;

            RefreshBicyClette();

            //on define le reste
            myGridBicy.Foreground = new SolidColorBrush(Colors.Black);
            myGridBicy.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridBicy.Margin = new Thickness(0, -22, 0, 0);
            myGridBicy.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridBicy.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridBicy.IsReadOnly = true;
            Grid.SetRow(myGridBicy, 3);
            Grid.SetColumn(myGridBicy, 0);
            Grid.SetColumnSpan(myGridBicy, 7);
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
            btnSuprBicy.Click += new RoutedEventHandler(ButtonSupBicy);
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

            RefreshPiece();

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
            btnSuprPiece.Click += new RoutedEventHandler(ButtonSupPiece);
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
            Grid.SetColumnSpan(DynamicGridClient, 7);
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
            txtBlock0.Text = "Liste des Clients Particuliers";
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

            RefreshClientParti();

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
            btnSuprClientParti.Click += new RoutedEventHandler(ButtonSupClientParti);
            DynamicGridClient.Children.Add(btnSuprClientParti);



            // Client entreprise
            // titre 1
            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Liste des Clients Entreprise";
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

            RefreshClientEntre();

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
            btnModifClientEntre.Click += new RoutedEventHandler(ModifClientEntre);
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
            btnSuprClientEntre.Click += new RoutedEventHandler(ButtonSupClientEntre);
            DynamicGridClient.Children.Add(btnSuprClientEntre);

        }
        #endregion Client
        #region Commandes
        public void GeneCommande()
        {
            /* ==== Creation partie matériel ====*/
            // création grid dynamic
            DynamicGridCommands.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridCommands.Height = 400;
            DynamicGridCommands.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridCommands.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridCommands.Width = 780;

            // Create Columns
            Grid.SetRow(DynamicGridCommands, 6);
            Grid.SetColumn(DynamicGridCommands, 0);
            Grid.SetColumnSpan(DynamicGridCommands, 7);
            ColumnDefinition gridColCommande1 = new ColumnDefinition();
            DynamicGridCommands.ColumnDefinitions.Add(gridColCommande1);

            // Create Rows
            RowDefinition gridRowCommande1 = new RowDefinition();
            gridRowCommande1.Height = new GridLength(30);
            RowDefinition gridRowCommande2 = new RowDefinition();
            gridRowCommande2.Height = new GridLength(100);
            RowDefinition gridRowCommande3 = new RowDefinition();
            gridRowCommande3.Height = new GridLength(30);
            RowDefinition gridRowCommande4 = new RowDefinition();
            gridRowCommande4.Height = new GridLength(100);
            RowDefinition gridRowCommande5 = new RowDefinition();
            gridRowCommande5.Height = new GridLength(30);
            RowDefinition gridRowCommande6 = new RowDefinition();
            gridRowCommande6.Height = new GridLength(100);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande1);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande2);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande3);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande4);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande5);
            DynamicGridCommands.RowDefinitions.Add(gridRowCommande6);
            DynamicGridCommands.Margin = new Thickness(0, 0, 0, 0);

            // titre 0
            TextBlock txtBlock0 = new TextBlock();
            txtBlock0.Text = "Liste des Commandes";
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
            DynamicGridCommands.Children.Add(txtBlock0);

            myGridCommande.Items.Clear();
            myGridCommande.Width = 700;
            myGridCommande.Height = 500;

            RefreshCommandes();

            //on define le reste
            myGridCommande.Foreground = new SolidColorBrush(Colors.Black);
            myGridCommande.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridCommande.Margin = new Thickness(0, -12, 0, 0);
            myGridCommande.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridCommande.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridCommande.IsReadOnly = true;
            Grid.SetRow(myGridCommande, 1);
            Grid.SetRowSpan(myGridCommande, 5);
            Grid.SetColumn(myGridCommande, 0);
            Grid.SetColumnSpan(myGridCommande, 6);
            DynamicGridCommands.Children.Add(myGridCommande);

            //Btn ajouter
            Button btnAddCommande = new Button();
            btnAddCommande.Content = "";
            btnAddCommande.Background = Brushes.Green;
            btnAddCommande.Height = 15;
            btnAddCommande.Width = 15;
            Grid.SetRow(btnAddCommande, 0);
            Grid.SetColumn(btnAddCommande, 0);
            Grid.SetColumnSpan(btnAddCommande, 6);
            btnAddCommande.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddCommande.Margin = new Thickness(225, -12, 0, 0);
            btnAddCommande.ToolTip = "Ajouter une commande";
            btnAddCommande.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddCommande.Click += new RoutedEventHandler(OpenAddCommandes);
            DynamicGridCommands.Children.Add(btnAddCommande);

            //Btn modifier
            Button btnModifCommande = new Button();
            btnModifCommande.Content = "";
            btnModifCommande.Background = Brushes.Green;
            btnModifCommande.Height = 15;
            btnModifCommande.Width = 15;
            Grid.SetRow(btnModifCommande, 0);
            Grid.SetColumn(btnModifCommande, 0);
            Grid.SetColumnSpan(btnModifCommande, 6);
            btnModifCommande.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifCommande.Margin = new Thickness(275, -12, 0, 0);
            btnModifCommande.ToolTip = "Modifier une commande";
            btnModifCommande.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            //btnModifCommande.Click += new RoutedEventHandler(ButtonModifCommande);
            DynamicGridCommands.Children.Add(btnModifCommande);

            //Btn del
            Button btnSuprCommande = new Button();
            btnSuprCommande.Content = "";
            btnSuprCommande.Background = Brushes.Red;
            btnSuprCommande.Height = 15;
            btnSuprCommande.Width = 15;
            Grid.SetRow(btnSuprCommande, 0);
            Grid.SetColumn(btnSuprCommande, 0);
            Grid.SetColumnSpan(btnSuprCommande, 6);
            btnSuprCommande.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprCommande.ToolTip = "Supprimer une commande";
            btnSuprCommande.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprCommande.Margin = new Thickness(325, -12, 0, 0);
            //btnSuprCommande.Click += new RoutedEventHandler(BoutonSuprCommande);
            DynamicGridCommands.Children.Add(btnSuprCommande);
        }

        #endregion Commande
        #region Fournisseur
        public void GeneFournisseur()
        {
            /* ==== Creation partie matériel ====*/
            // création grid dynamic
            DynamicGridFournisseur.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridFournisseur.Height = 400;
            DynamicGridFournisseur.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridFournisseur.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridFournisseur.Width = 780;


            // Create Columns
            Grid.SetRow(DynamicGridFournisseur, 6);
            Grid.SetColumn(DynamicGridFournisseur, 0);
            Grid.SetColumnSpan(DynamicGridFournisseur, 7);
            ColumnDefinition gridColFournisseur1 = new ColumnDefinition();
            DynamicGridFournisseur.ColumnDefinitions.Add(gridColFournisseur1);

            // Create Rows
            RowDefinition gridRowFournisseur1 = new RowDefinition();
            gridRowFournisseur1.Height = new GridLength(30);
            RowDefinition gridRowFournisseur2 = new RowDefinition();
            gridRowFournisseur2.Height = new GridLength(100);
            RowDefinition gridRowFournisseur3 = new RowDefinition();
            gridRowFournisseur3.Height = new GridLength(30);
            RowDefinition gridRowFournisseur4 = new RowDefinition();
            gridRowFournisseur4.Height = new GridLength(100);
            RowDefinition gridRowFournisseur5 = new RowDefinition();
            gridRowFournisseur5.Height = new GridLength(30);
            RowDefinition gridRowFournisseur6 = new RowDefinition();
            gridRowFournisseur6.Height = new GridLength(100);
            DynamicGridFournisseur.RowDefinitions.Add(gridRowFournisseur1);
            DynamicGridFournisseur.RowDefinitions.Add(gridRowFournisseur2);
            DynamicGridFournisseur.RowDefinitions.Add(gridRowFournisseur3);
            DynamicGridFournisseur.RowDefinitions.Add(gridRowFournisseur4);
            DynamicGridFournisseur.RowDefinitions.Add(gridRowFournisseur5);
            DynamicGridFournisseur.RowDefinitions.Add(gridRowFournisseur6);
            DynamicGridFournisseur.Margin = new Thickness(0, 0, 0, 0);

            // titre 0
            TextBlock txtBlock0 = new TextBlock();
            txtBlock0.Text = "Liste des Fournisseurs";
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
            DynamicGridFournisseur.Children.Add(txtBlock0);

            //Clear

            myGridFournisseur.Items.Clear();
            myGridFournisseur.Width = 700;
            myGridFournisseur.Height = 500;

            RefreshFournisseur();

            //on define le reste
            myGridFournisseur.Foreground = new SolidColorBrush(Colors.Black);
            myGridFournisseur.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridFournisseur.Margin = new Thickness(0, -12, 0, 0);
            //myGridFournisseur.BorderThickness = new Thickness(0, 20, 0, 0);
            //myGridFournisseur.Background = Brushes.Transparent;
            myGridFournisseur.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridFournisseur.IsReadOnly = true;
            Grid.SetRow(myGridFournisseur, 1);
            Grid.SetRowSpan(myGridFournisseur, 5);
            Grid.SetColumn(myGridFournisseur, 0);
            Grid.SetColumnSpan(myGridFournisseur, 6);
            DynamicGridFournisseur.Children.Add(myGridFournisseur);

            //Btn ajouter
            Button btnAddFournisseur = new Button();
            btnAddFournisseur.Content = "";
            btnAddFournisseur.Background = Brushes.Green;
            btnAddFournisseur.Height = 15;
            btnAddFournisseur.Width = 15;
            Grid.SetRow(btnAddFournisseur, 0);
            Grid.SetColumn(btnAddFournisseur, 0);
            Grid.SetColumnSpan(btnAddFournisseur, 6);
            btnAddFournisseur.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddFournisseur.Margin = new Thickness(175, -12, 0, 0);
            btnAddFournisseur.ToolTip = "Ajouter un fournisseur";
            btnAddFournisseur.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddFournisseur.Click += new RoutedEventHandler(OpenAddFournisseur);
            DynamicGridFournisseur.Children.Add(btnAddFournisseur);

            //Btn modifier
            Button btnModifFournisseur = new Button();
            btnModifFournisseur.Content = "";
            btnModifFournisseur.Background = Brushes.Green;
            btnModifFournisseur.Height = 15;
            btnModifFournisseur.Width = 15;
            Grid.SetRow(btnModifFournisseur, 0);
            Grid.SetColumn(btnModifFournisseur, 0);
            Grid.SetColumnSpan(btnModifFournisseur, 6);
            btnModifFournisseur.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifFournisseur.Margin = new Thickness(225, -12, 0, 0);
            btnModifFournisseur.ToolTip = "Modifier un fournisseur";
            btnModifFournisseur.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            btnModifFournisseur.Click += new RoutedEventHandler(OpenModifFournisseur);
            DynamicGridFournisseur.Children.Add(btnModifFournisseur);

            //Btn del
            Button btnSuprFournisseur = new Button();
            btnSuprFournisseur.Content = "";
            btnSuprFournisseur.Background = Brushes.Red;
            btnSuprFournisseur.Height = 15;
            btnSuprFournisseur.Width = 15;
            Grid.SetRow(btnSuprFournisseur, 0);
            Grid.SetColumn(btnSuprFournisseur, 0);
            Grid.SetColumnSpan(btnSuprFournisseur, 6);
            btnSuprFournisseur.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSuprFournisseur.ToolTip = "Supprimer un fournisseur";
            btnSuprFournisseur.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSuprFournisseur.Margin = new Thickness(275, -12, 0, 0);
            btnSuprFournisseur.Click += new RoutedEventHandler(DelFournisseur);
            DynamicGridFournisseur.Children.Add(btnSuprFournisseur);
        }
        #endregion
        #region Stats

        public void GeneStat()
        {
            //==== Creation partie Stat ====
            // création grid dynamic
            DynamicGridStats.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridStats.Height = 400;
            DynamicGridStats.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridStats.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridStats.Width = 780;

            // Create Columns
            Grid.SetRow(DynamicGridStats, 6);
            Grid.SetColumn(DynamicGridStats, 0);
            Grid.SetColumnSpan(DynamicGridStats, 7);
            ColumnDefinition gridColStat1 = new ColumnDefinition();
            DynamicGridStats.ColumnDefinitions.Add(gridColStat1);

            // Create Rows
            RowDefinition gridRowitem1 = new RowDefinition();
            gridRowitem1.Height = new GridLength(60);
            RowDefinition gridRowitem2 = new RowDefinition();
            gridRowitem2.Height = new GridLength(60);
            RowDefinition gridRowitem3 = new RowDefinition();
            gridRowitem3.Height = new GridLength(60);
            RowDefinition gridRowitem4 = new RowDefinition();
            gridRowitem4.Height = new GridLength(60);
            RowDefinition gridRowitem5 = new RowDefinition();
            gridRowitem5.Height = new GridLength(60);
            RowDefinition gridRowitem6 = new RowDefinition();
            gridRowitem6.Height = new GridLength(60);
            DynamicGridStats.RowDefinitions.Add(gridRowitem1);
            DynamicGridStats.RowDefinitions.Add(gridRowitem2);
            DynamicGridStats.RowDefinitions.Add(gridRowitem3);
            DynamicGridStats.RowDefinitions.Add(gridRowitem4);
            DynamicGridStats.RowDefinitions.Add(gridRowitem5);
            DynamicGridStats.RowDefinitions.Add(gridRowitem6);
            DynamicGridStats.Margin = new Thickness(0, 0, 0, 0);

            //Btn ajouter
            Button btnAddCommande = new Button();
            btnAddCommande.Content = "";
            btnAddCommande.Foreground = Brushes.Black;
            btnAddCommande.Height = 50;
            btnAddCommande.Width = 300;
            Grid.SetRow(btnAddCommande, 1);
            Grid.SetColumn(btnAddCommande, 0);
            Grid.SetColumnSpan(btnAddCommande, 6);
            btnAddCommande.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddCommande.Content = "Générer liste client fidelio level 1";
            btnAddCommande.Background = Brushes.Green;
            btnAddCommande.Click += new RoutedEventHandler(JsonFidelio);
            DynamicGridStats.Children.Add(btnAddCommande);

            //Btn ajouter
            Button btnAddCommande2 = new Button();
            btnAddCommande2.Content = "";
            btnAddCommande2.Foreground = Brushes.Black;
            btnAddCommande2.Height = 50;
            btnAddCommande2.Width = 300;
            Grid.SetRow(btnAddCommande2, 2);
            Grid.SetColumn(btnAddCommande2, 0);
            Grid.SetColumnSpan(btnAddCommande2, 6);
            btnAddCommande2.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddCommande2.Content = "Générer liste client fidelio level 2";
            btnAddCommande2.Background = Brushes.Green;
            btnAddCommande2.Click += new RoutedEventHandler(JsonFidelio2);
            DynamicGridStats.Children.Add(btnAddCommande2);

            //Btn ajouter
            Button btnAddCommande3 = new Button();
            btnAddCommande3.Content = "";
            btnAddCommande3.Foreground = Brushes.Black;
            btnAddCommande3.Height = 50;
            btnAddCommande3.Width = 300;
            Grid.SetRow(btnAddCommande3, 3);
            Grid.SetColumn(btnAddCommande3, 0);
            Grid.SetColumnSpan(btnAddCommande3, 6);
            btnAddCommande3.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddCommande3.Content = "Générer liste client fidelio level 2";
            btnAddCommande3.Background = Brushes.Green;
            btnAddCommande3.Click += new RoutedEventHandler(JsonFidelio3);
            DynamicGridStats.Children.Add(btnAddCommande3);

            //Btn ajouter
            Button btnAddCommande4 = new Button();
            btnAddCommande4.Content = "";
            btnAddCommande4.Foreground = Brushes.Black;
            btnAddCommande4.Height = 50;
            btnAddCommande4.Width = 300;
            Grid.SetRow(btnAddCommande4, 4);
            Grid.SetColumn(btnAddCommande4, 0);
            Grid.SetColumnSpan(btnAddCommande4, 6);
            btnAddCommande4.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddCommande4.Content = "Générer liste client fidelio level 3";
            btnAddCommande4.Background = Brushes.Green;
            btnAddCommande4.Click += new RoutedEventHandler(JsonFidelio4);
            DynamicGridStats.Children.Add(btnAddCommande4);

            //Btn ajouter
            Button btnAddCommande5 = new Button();
            btnAddCommande5.Content = "";
            btnAddCommande5.Foreground = Brushes.Black;
            btnAddCommande5.Height = 50;
            btnAddCommande5.Width = 300;
            Grid.SetRow(btnAddCommande5, 5);
            Grid.SetColumn(btnAddCommande5, 0);
            Grid.SetColumnSpan(btnAddCommande5, 6);
            btnAddCommande5.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddCommande5.Content = "Export Table Assemblage en XML";
            btnAddCommande5.Background = Brushes.Green;
            btnAddCommande5.Click += new RoutedEventHandler(XmlExportTable);
            DynamicGridStats.Children.Add(btnAddCommande5);

        }
        #endregion
        #region Stock

        public void GeneStock()
        {
            /* ==== Creation partie matériel ====*/
            // création grid dynamic
            DynamicGridStock.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGridStock.Height = 400;
            DynamicGridStock.Margin = new Thickness(0, 0, 0, 0);
            DynamicGridStock.VerticalAlignment = VerticalAlignment.Center;
            DynamicGridStock.Width = 780;


            // Create Columns
            Grid.SetRow(DynamicGridStock, 6);
            Grid.SetColumn(DynamicGridStock, 0);
            Grid.SetColumnSpan(DynamicGridStock, 7);
            ColumnDefinition gridColStock1 = new ColumnDefinition();
            DynamicGridStock.ColumnDefinitions.Add(gridColStock1);

            // Create Rows
            RowDefinition gridRowStock1 = new RowDefinition();
            gridRowStock1.Height = new GridLength(30);
            RowDefinition gridRowStock2 = new RowDefinition();
            gridRowStock2.Height = new GridLength(100);
            RowDefinition gridRowStock3 = new RowDefinition();
            gridRowStock3.Height = new GridLength(30);
            RowDefinition gridRowStock4 = new RowDefinition();
            gridRowStock4.Height = new GridLength(100);
            RowDefinition gridRowStock5 = new RowDefinition();
            gridRowStock5.Height = new GridLength(30);
            RowDefinition gridRowStock6 = new RowDefinition();
            gridRowStock6.Height = new GridLength(100);
            DynamicGridStock.RowDefinitions.Add(gridRowStock1);
            DynamicGridStock.RowDefinitions.Add(gridRowStock2);
            DynamicGridStock.RowDefinitions.Add(gridRowStock3);
            DynamicGridStock.RowDefinitions.Add(gridRowStock4);
            DynamicGridStock.RowDefinitions.Add(gridRowStock5);
            DynamicGridStock.RowDefinitions.Add(gridRowStock6);
            DynamicGridStock.Margin = new Thickness(0, 0, 0, 0);

            // titre 0
            TextBlock txtBlock0 = new TextBlock();
            txtBlock0.Text = "Inventaire des stocks";
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
            DynamicGridStock.Children.Add(txtBlock0);

            //Clear

            myGridStock.Items.Clear();
            myGridStock.Width = 700;
            myGridStock.Height = 400;

            RefreshItemStock();

            //on define le reste
            myGridStock.Foreground = new SolidColorBrush(Colors.Black);
            myGridStock.GridLinesVisibility = DataGridGridLinesVisibility.None;
            myGridStock.Margin = new Thickness(0, -11, 0, 0);
            myGridStock.BorderThickness = new Thickness(0, 0, 0, 0);
            myGridStock.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            myGridStock.IsReadOnly = true;
            Grid.SetRow(myGridStock, 1);
            Grid.SetRowSpan(myGridStock, 5);
            Grid.SetColumn(myGridStock, 0);
            Grid.SetColumnSpan(myGridStock, 6);
            DynamicGridStock.Children.Add(myGridStock);

            //Btn ajouter
            Button btnAddStock = new Button();
            btnAddStock.Content = "";
            btnAddStock.Background = Brushes.Green;
            btnAddStock.Height = 15;
            btnAddStock.Width = 15;
            Grid.SetRow(btnAddStock, 0);
            Grid.SetColumn(btnAddStock, 0);
            Grid.SetColumnSpan(btnAddStock, 6);
            btnAddStock.BorderThickness = new Thickness(0, 0, 0, 0);
            btnAddStock.Margin = new Thickness(175, -12, 0, 0);
            btnAddStock.ToolTip = "Ajouter un item";
            btnAddStock.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2014/04/02/10/41/button-304224_640.png")));
            btnAddStock.Click += new RoutedEventHandler(OpenAddStock);
            DynamicGridStock.Children.Add(btnAddStock);

            //Btn modifier
            Button btnModifStock = new Button();
            btnModifStock.Content = "";
            btnModifStock.Background = Brushes.Green;
            btnModifStock.Height = 15;
            btnModifStock.Width = 15;
            Grid.SetRow(btnModifStock, 0);
            Grid.SetColumn(btnModifStock, 0);
            Grid.SetColumnSpan(btnModifStock, 6);
            btnModifStock.BorderThickness = new Thickness(0, 0, 0, 0);
            btnModifStock.Margin = new Thickness(225, -12, 0, 0);
            btnModifStock.ToolTip = "Modifier un item";
            btnModifStock.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2016/03/29/06/22/edit-1287617_1280.png")));
            btnModifStock.Click += new RoutedEventHandler(ModifStock);
            DynamicGridStock.Children.Add(btnModifStock);

            //Btn del
            Button btnSupprStock = new Button();
            btnSupprStock.Content = "";
            btnSupprStock.Background = Brushes.Red;
            btnSupprStock.Height = 15;
            btnSupprStock.Width = 15;
            Grid.SetRow(btnSupprStock, 0);
            Grid.SetColumn(btnSupprStock, 0);
            Grid.SetColumnSpan(btnSupprStock, 6);
            btnSupprStock.BorderThickness = new Thickness(0, 0, 0, 0);
            btnSupprStock.ToolTip = "Supprimer un item";
            btnSupprStock.Background = new ImageBrush(new BitmapImage(new Uri(@"https://cdn.pixabay.com/photo/2013/07/12/17/00/remove-151678_960_720.png")));
            btnSupprStock.Margin = new Thickness(275, -12, 0, 0);
            btnSupprStock.Click += new RoutedEventHandler(BtnSuprStock);
            DynamicGridStock.Children.Add(btnSupprStock);

        }
        #endregion Stock
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
            Grid.SetColumnSpan(DynamicGridDemo, 7);
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
            Uri test = new Uri("http://pierre-petillion.fr/musique/demo.mp4");
            meVideo.Source = test;
            //MessageBox.Show(meVideo.Source.PathAndQuery);
            meVideo.Height = 600;
            meVideo.Width = 600;
            Grid.SetRow(meVideo, 1);
            Grid.SetRowSpan(meVideo, 8);
            Grid.SetColumn(meVideo, 0);
            Grid.SetColumnSpan(meVideo, 2);
            meVideo.Opacity = 100;
            meVideo.Visibility = Visibility.Visible;
            meVideo.LoadedBehavior = MediaState.Manual;
            //meVideo.Stretch = Stretch.Uniform;
            //meVideo.StretchDirection = StretchDirection.UpOnly;


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

            meVideo.Play();
            btnPause.Click += new RoutedEventHandler(ButtonPauseVideo);
            btnPlay.Click += new RoutedEventHandler(ButtonPlayVideo);
            meVideo.Pause();
            DynamicGridDemo.Children.Add(meVideo);
            DynamicGridDemo.Children.Add(btnPause);
            DynamicGridDemo.Children.Add(btnPlay);
        }

        #endregion Demo
        #endregion Generation
        
        #region main
            public MainWindow()
        {
            //generation des 6 sous menu
            GeneMateriel();
            GeneClient();
            GeneCommande();
            GeneFournisseur();
            GeneStat();
            GeneDemo();
            GeneStock();
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

        private void ButtonSupAssemblage(object sender, RoutedEventArgs e)
        {
            if (myGridAssemblage.SelectedItems.Count != 0)
            {
                foreach (Object o in myGridAssemblage.SelectedItems)
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SET foreign_key_checks = 0;DELETE FROM velomax.assemblage WHERE nom ='" + ((Assemblage)o).Nom + "' AND grandeur ='" + ((Assemblage)o).Grandeur + "';UPDATE velomax.bicyclette SET nom = '', grandeur = '' WHERE nom = '" + ((Assemblage)o).Nom + "' AND grandeur = '" + ((Assemblage)o).Grandeur + "'; SET foreign_key_checks = 1;";
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vous devez avoir au moin 1 ligne selectionnées");
            }
            RefreshAll();
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

        private void ButtonSupBicy(object sender, RoutedEventArgs e)
        {
            if (myGridBicy.SelectedItems.Count != 0)
            {
                foreach (Object o in myGridBicy.SelectedItems)
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SET foreign_key_checks = 0;DELETE FROM velomax.bicyclette WHERE idbicy =" + ((Bicyclette)o).Idbicy + ";UPDATE velomax.itemstock SET idbicy =null where idbicy =" + ((Bicyclette)o).Idbicy + "; SET foreign_key_checks = 1;";
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vous devez avoir au moin 1 ligne selectionnées");
            }
            RefreshAll();
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

        private void ButtonSupPiece(object sender, RoutedEventArgs e)
        {
            if (myGridPiece.SelectedItems.Count != 0)
            {
                foreach (Object o in myGridPiece.SelectedItems)
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SET foreign_key_checks = 0;DELETE FROM velomax.piecedetache WHERE numpiece ='" + ((PieceDetache)o).Numpiece + "';UPDATE velomax.itemstock SET numpiece = null where numpiece = '" + ((PieceDetache)o).Numpiece + "'; SET foreign_key_checks = 1; ";;
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vous devez avoir au moin 1 ligne selectionnées");
            }
            RefreshAll();
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
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! vous en avez actuellement selectionné " + myGridClientParti.SelectedItems.Count);
            }

        }

        private void ButtonSupClientParti(object sender, RoutedEventArgs e)
        {
            if (myGridClientParti.SelectedItems.Count != 0)
            {
                foreach (Object o in myGridClientParti.SelectedItems)
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SET foreign_key_checks = 0;DELETE FROM velomax.particulier WHERE idclient =" + ((clientele)o).Idclient + ";DELETE FROM velomax.clientele WHERE idclient =" + ((clientele)o).Idclient + "; SET foreign_key_checks = 1;";
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vous devez avoir au moin 1 ligne selectionnées");
            }
            RefreshAll();
        }

        private void OpenAddClientEntreprise(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddClientEntre(connection, this);
            WindowAddClient.Show();
        }

        private void ModifClientEntre(object sender, RoutedEventArgs e)
        {
            if (myGridClientEntre.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridClientEntre.SelectedItems)
                {
                    modifClientEntre w = new modifClientEntre(connection, ((Entreprise)o), this);
                    w.Show();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! vous en avez actuellement selectionné " + myGridClientEntre.SelectedItems.Count);
            }

        }

        private void ButtonSupClientEntre(object sender, RoutedEventArgs e)
        {
            if (myGridClientEntre.SelectedItems.Count != 0)
            {
                foreach (Object o in myGridClientEntre.SelectedItems)
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SET foreign_key_checks = 0;DELETE FROM velomax.entreprise WHERE idclient =" + ((clientele)o).Idclient + ";DELETE FROM velomax.clientele WHERE idclient =" + ((clientele)o).Idclient + "; SET foreign_key_checks = 1;";
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vous devez avoir au moin 1 ligne selectionnées");
            }
            RefreshAll();
        }
        #endregion Evenement Client

        #region Evenement Commandes
        private void CommandesBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            CommandesBtn.Background = new SolidColorBrush(Colors.White);
            MainGrid.Children.Add(DynamicGridCommands);
        }

        private void OpenAddCommandes(object sender, RoutedEventArgs e)
        {
            var WindowAddClient = new AddCommande(connection, this);
            WindowAddClient.Show();
        }


        #endregion Evenement Commandes

        #region Evenement Statistique
        private void StatistiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            StatistiqueBtn.Background = new SolidColorBrush(Colors.White);
            MainGrid.Children.Add(DynamicGridStats);
        }

        private void XmlExportTable(object sender, RoutedEventArgs e)
        {

            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM velomax.assemblage;";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            List<Assemblage> myListAssemblageExport = new List<Assemblage>();
            while (reader.Read())// parcours ligne par ligne
            {
                myListAssemblageExport.Add(new Assemblage(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), reader.GetValue(11).ToString(), reader.GetValue(12).ToString(), reader.GetValue(13).ToString()));

            }
            connection.Close();

            // Code pour sérialiser l'objet piece en XML dans un fichier "exportstocksfaibles.xml"
            XmlSerializer xs = new XmlSerializer(typeof(List<Assemblage>));  // l'outil de sérialisation
            StreamWriter wr = new StreamWriter("exportTableAssemblage.xml");  // accès en écriture à un fichier (texte)
            xs.Serialize(wr, myListAssemblageExport); // action de sérialiser en XML l'objet piece 
                                        // et d'écrire le résultat dans le fichier manipulé par wr
            wr.Close();
            MessageBox.Show("sérialisation dans fichier exportTableAssemblage.xml terminée avec succès dans le repertoire : " + System.AppDomain.CurrentDomain.BaseDirectory);
        }

        static void AfficherPrettyJson(string nomFichier)
        {
            MessageBox.Show(nomFichier);
            StreamReader reader = new StreamReader(nomFichier);
            JsonTextReader jreader = new JsonTextReader(reader);
            while (jreader.Read())
            {
                if (jreader.Value != null)
                {
                    if (jreader.TokenType.ToString() == "PropertyName")
                    {
                        Console.Write(jreader.Value + " : ");
                    }
                    else
                    {
                        Console.WriteLine(jreader.Value);
                    }
                }
                else
                {
                    // Console.WriteLine("Token:{0} ", jreader.TokenType.ToString());
                    if (jreader.TokenType.ToString() == "StartObject") Console.WriteLine("Nouvel objet\n--------------");
                    if (jreader.TokenType.ToString() == "EndObject") Console.WriteLine("-------------\n");
                    if (jreader.TokenType.ToString() == "StartArray") Console.WriteLine("Liste\n");
                }
            }
            jreader.Close();
            reader.Close();
        }

        private void genereJson(List<Particulier> Fideliolvl1,string fileToWrite)
        {
            //instanciation des flux d'écriture(writer)
            StreamWriter fileWriter = new StreamWriter(fileToWrite);
            JsonTextWriter jsonWriter = new JsonTextWriter(fileWriter);

            // sérialisation des objets vers le flux d'écriture fichier
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, Fideliolvl1);

            //fermture des flux (writer)
            jsonWriter.Close();
            fileWriter.Close();

            //AfficherPrettyJson(fileToWrite);
            MessageBox.Show("Le fichier Json à été généré avec succès dans le repertoire : " + System.AppDomain.CurrentDomain.BaseDirectory);
        }

        private void JsonFidelio(object sender, RoutedEventArgs e)
        {
            //fichier destinataire de la sérialisation
            string fileToWrite = "./Fidelio.json";

            //instanciation des objets <Chat>
            List<Particulier> Fideliolvl1 = new List<Particulier>();

            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select idclient,idparticulier,nomclient, prenomclient,idfidelio,rueclient,codepostaleclient,provinceclient,villeclient from velomax.clientele natural join velomax.particulier natural join fidelio where idfidelio = (SELECT idfidelio from velomax.fidelio where descfidelio = 'Fidélio');";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Fideliolvl1.Add(new Particulier(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(4)), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString()));
            }
            connection.Close();
            genereJson(Fideliolvl1, fileToWrite);
        }

        private void JsonFidelio2(object sender, RoutedEventArgs e)
        {
            //fichier destinataire de la sérialisation
            string fileToWrite = "./FidelioOr.json";

            //instanciation des objets <Chat>
            List<Particulier> Fideliolvl1 = new List<Particulier>();

            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select idclient,idparticulier,nomclient, prenomclient,idfidelio,rueclient,codepostaleclient,provinceclient,villeclient from velomax.clientele natural join velomax.particulier natural join fidelio where idfidelio = (SELECT idfidelio from velomax.fidelio where descfidelio = 'Fidélio Or');";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Fideliolvl1.Add(new Particulier(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(4)), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString()));
            }
            connection.Close();
            genereJson(Fideliolvl1, fileToWrite);
        }

        private void JsonFidelio3(object sender, RoutedEventArgs e)
        {
            //fichier destinataire de la sérialisation
            string fileToWrite = "./FidelioPlatine.json";

            //instanciation des objets <Chat>
            List<Particulier> Fideliolvl1 = new List<Particulier>();

            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select idclient,idparticulier,nomclient, prenomclient,idfidelio,rueclient,codepostaleclient,provinceclient,villeclient from velomax.clientele natural join velomax.particulier natural join fidelio where idfidelio = (SELECT idfidelio from velomax.fidelio where descfidelio = 'Fidélio Platine');";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Fideliolvl1.Add(new Particulier(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(4)), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString()));
            }
            connection.Close();
            genereJson(Fideliolvl1, fileToWrite);
        }

        private void JsonFidelio4(object sender, RoutedEventArgs e)
        {
            //fichier destinataire de la sérialisation
            string fileToWrite = "FidelioMax.json";

            //instanciation des objets <Chat>
            List<Particulier> Fideliolvl1 = new List<Particulier>();

            // on recupere les datas
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select idclient,idparticulier,nomclient, prenomclient,idfidelio,rueclient,codepostaleclient,provinceclient,villeclient from velomax.clientele natural join velomax.particulier natural join fidelio where idfidelio = (CALL fidelio('Fidélio Max');";
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())// parcours ligne par ligne
            {
                Fideliolvl1.Add(new Particulier(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(4)), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString()));
            }
            connection.Close();
            genereJson(Fideliolvl1, fileToWrite);
        }
            #endregion Evenement Commandes

        #region Evenement Fournisseur
        private void FournisseurBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            FournisseurBtn.Background = new SolidColorBrush(Colors.White);
            MainGrid.Children.Add(DynamicGridFournisseur);
        }

        private void OpenAddFournisseur(object sender, RoutedEventArgs e)
        {
            var w = new AddFournisseur(connection, this);
            w.Show();
        }

        private void OpenModifFournisseur(object sender, RoutedEventArgs e)
        {
            if (myGridFournisseur.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridFournisseur.SelectedItems)
                {
                    modifFournisseur w = new modifFournisseur(connection, ((Fournisseur)o), this);
                    w.Show();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! vous en avez actuellement selectionné " + myGridFournisseur.SelectedItems.Count);
            }

        }

        private void DelFournisseur(object sender, RoutedEventArgs e)
        {
            if (myGridFournisseur.SelectedItems.Count != 0)
            {
                foreach (Object o in myGridFournisseur.SelectedItems)
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SET foreign_key_checks = 0;DELETE FROM velomax.fournisseur WHERE siret =" + ((Fournisseur)o).Siret + ";UPDATE velomax.piecedetache SET siret = null WHERE siret = " + ((Fournisseur)o).Siret + "; SET foreign_key_checks = 1;";
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect! vous en avez actuellement selectionné " + myGridFournisseur.SelectedItems.Count);
            }
            RefreshFournisseur();
        }

        #endregion Evenement Fournisseur

        #region Evenement Stock
        private void StockBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            StockBtn.Background = new SolidColorBrush(Colors.White);
            MainGrid.Children.Add(DynamicGridStock);
        }
        
        private void OpenAddStock(object sender, RoutedEventArgs e)
        {
            var w = new AddStock(connection, this);
            w.Show();
        }

        private void ModifStock(object sender, RoutedEventArgs e)
        {
            if (myGridStock.SelectedItems.Count == 1)
            {
                foreach (Object o in myGridStock.SelectedItems)
                {
                    modifStock w = new modifStock(connection, ((ItemStock)o), this);
                    w.Show();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect ! vous en avez actuellement selectionné " + myGridFournisseur.SelectedItems.Count);
            }
        }

        private void BtnSuprStock(object sender, RoutedEventArgs e)
        {
            if (myGridStock.SelectedItems.Count != 0)
            {
                foreach (Object o in myGridStock.SelectedItems)
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SET foreign_key_checks = 0;DELETE FROM velomax.itemstock WHERE iditemstock =" + ((ItemStock)o).Iditemstock + ";UPDATE velomax.itemcmd SET iditemstock = -1 WHERE iditemstock = " + ((ItemStock)o).Iditemstock + "; SET foreign_key_checks = 1;";
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Le nombre de ligne selectionné est incorrect! vous en avez actuellement selectionné " + myGridStock.SelectedItems.Count);
            }
            RefreshItemStock();
            RefreshCommandes();
        }
        #endregion Evenement Stock

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