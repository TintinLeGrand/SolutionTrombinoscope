using System;
using System.Windows;
using DllbddPersonnels;

namespace AppTrombinoscope
{
    public partial class MainWindow : Window
    {
        private bddpersonnels bddPersonnels;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            this.bddPersonnels = new bddpersonnels(Properties.Settings.Default.Username, Properties.Settings.Default.Password, Properties.Settings.Default.AdresseIP, Properties.Settings.Default.Port);
            if (bddPersonnels != null)
            {
                var services = bddPersonnels.GetallService();
                listeServices.ItemsSource = services;

                var fonctions = bddPersonnels.GetallFonction();
                listeFonctions.ItemsSource = fonctions;

                var membres = bddPersonnels.GetallPersonnel();
                listeMembres.ItemsSource = membres;
            }
            else
            {
                MessageBox.Show("Il n'y a aucune connexion à la base de données.");
            }
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.bddPersonnels = new bddpersonnels(Properties.Settings.Default.Username, Properties.Settings.Default.Password, Properties.Settings.Default.AdresseIP, Properties.Settings.Default.Port);
        }
    }
}
