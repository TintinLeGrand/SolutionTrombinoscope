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
            Properties.Settings.Default.AdresseIP = "127.0.0.1";
            Properties.Settings.Default.Port = "3306";
            Properties.Settings.Default.Username = "GestionnaireBDD";
            Properties.Settings.Default.Password = "Password1234@but";

        }

        private void LoadData()
        {
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

        private void estGestionnaire (String user, String password)
        {
            if(user == "admin" && password == "Password1234!")
            {
                listepersonnelButton.IsEnabled = true;
                gestionButton.IsEnabled = true;
            }
            else {
                listepersonnelButton.IsEnabled = false;
                gestionButton.IsEnabled = false;
                MessageBox.Show("Les identifiants sont incorrectes.");
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
            try
            {
                Connexion();
            }
            catch
            {
                MessageBox.Show("Des paramètres sont incorrectes");
            }

        }

        private void Connexion()
        {
            this.bddPersonnels = new bddpersonnels(Properties.Settings.Default.Username, Properties.Settings.Default.Password, Properties.Settings.Default.AdresseIP, Properties.Settings.Default.Port);
            LoadData();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Connexion();
            }
            catch
            {
                MessageBox.Show("Vous n'êtes pas connecté à la BDD.");
                return;
            }
            connexionGestionnaire gestionnaireBDD = new connexionGestionnaire();
                if (gestionnaireBDD.ShowDialog() == true)
                {

                estGestionnaire(gestionnaireBDD.nomdutilisateurTextBox.Text, gestionnaireBDD.motdepasseTextBox.Password);
            }
                Console.WriteLine("L'ouverture des paramètres a fonctionné !");
        }
    }
}
