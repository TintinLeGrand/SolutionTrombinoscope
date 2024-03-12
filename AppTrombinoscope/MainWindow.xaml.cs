using System;
using System.Windows;
using BddpersonnelContext;
using DllbddPersonnels;

namespace AppTrombinoscope
{
    public partial class MainWindow : Window
    {
        private bddpersonnels bddPersonnels;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            if (bddPersonnels != null)
            {
                try
                {
                    var services = bddPersonnels.GetAllService();
                    listeServices.ItemsSource = bddPersonnels.GetAllService().ToArray();

                    var fonctions = bddPersonnels.GetAllFonction();
                    listeFonctions.ItemsSource = bddPersonnels.GetAllFonction().ToArray();

                    var membres = bddPersonnels.GetAllPersonnel();
                    listeMembres.ItemsSource = bddPersonnels.GetAllPersonnel().ToArray();
                }
                catch
                {
                    MessageBox.Show("Erreur lors de la récupération des données");
                }
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
                bddPersonnels = new bddpersonnels(Properties.Settings.Default.UsernameADM, Properties.Settings.Default.PasswordADM, Properties.Settings.Default.AdresseIP, Properties.Settings.Default.Port);
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

        private void ConnBDD_Click(object sender, RoutedEventArgs e)
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

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GestionService fenetre = new GestionService(this.bddPersonnels);
                fenetre.Show();
            }
            catch
            {
                MessageBox.Show("Problème");
            }

        }

        private void Fonctions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GestionFonction fenetre = new GestionFonction(this.bddPersonnels);
                fenetre.Show();
            }
            catch
            {
                MessageBox.Show("Problème");
            }

        }

        private void Personnel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GestionPerso fenetre = new GestionPerso(this.bddPersonnels);
                fenetre.Show();
            }
            catch
            {
                MessageBox.Show("Problème");
            }

        }

        private void Connexion()
        {
            this.bddPersonnels = new bddpersonnels(Properties.Settings.Default.Username, Properties.Settings.Default.Password, Properties.Settings.Default.AdresseIP, Properties.Settings.Default.Port);
            LoadData();
        }

        private void Gestionnaire_Click(object sender, RoutedEventArgs e)
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
