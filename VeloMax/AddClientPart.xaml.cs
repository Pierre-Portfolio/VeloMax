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
    /// Logique d'interaction pour AddClientPart.xaml
    /// </summary>
    public partial class AddClientPart : Window
    {
        public MySqlConnection connection;
        public MainWindow mw;

        public AddClientPart(MySqlConnection connection, MainWindow mw)
        {
            InitializeComponent();
            this.connection = connection;
            this.mw = mw;
        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            /*
            if (BoxNom.Text != "" && BoxNom.Text.Length != 0)
            {
                if (BoxGrandeur.Text != "" && BoxGrandeur.Text.Length != 0)
                {
                    if (BoxPrix.Text != "" && BoxPrix.Text.Length != 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Erreur le champ prix est vide !");
                    }
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
            */
        }
    }
}
