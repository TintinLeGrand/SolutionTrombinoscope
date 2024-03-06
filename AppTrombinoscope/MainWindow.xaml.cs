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

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ParamBDD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnexionBdd paramBDD = new ConnexionBdd();
                paramBDD.adresseipTextBox.Text = Properties.Settings.Default.AdresseIP;
                paramBDD.portecouteTextBox.Text = Properties.Settings.Default.Port;
                paramBDD.nomdutilisateurTextBox.Text = Properties.Settings.Default.Username;
                paramBDD.motdepasseTextBox.Password = Properties.Settings.Default.Password;
                if (paramBDD.ShowDialog() == true)
                {
                    Properties.Settings.Default.AdresseIP = paramBDD.adresseipTextBox.Text;
                    Properties.Settings.Default.Port = paramBDD.portecouteTextBox.Text;
                    Properties.Settings.Default.Username = paramBDD.nomdutilisateurTextBox.Text;
                    Properties.Settings.Default.Password = paramBDD.motdepasseTextBox.Password;
                    Properties.Settings.Default.Save();
                }
                Console.WriteLine("L'ouverture des paramètres a fonctionné !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur lors de l'ouverture des parametres !");
            }
        }
    }
}
