using BddpersonnelContext;
using DllbddPersonnels;
using System.Windows;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour GestionFonction.xaml
    /// </summary>
    public partial class GestionFonction : Window
    {
        bddpersonnels bddPersonnels;
        public GestionFonction(bddpersonnels bddPersonnels)
        {
            InitializeComponent();
            this.bddPersonnels = bddPersonnels;
            LoadData();
        }

        private void LoadData()
        {
            if (bddPersonnels != null)
            {
                try
                {
                    var fonctions = bddPersonnels.GetAllFonction();
                    listeFctGest.ItemsSource = bddPersonnels.GetAllFonction().ToArray();
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

        private void ButtonAddFct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fonction fonction = new Fonction();
                fonction.Intitule = inputAddFct.Text;
                bddPersonnels.NewFonction(fonction);
                inputAddFct.Text = "";
                LoadData();
            }
            catch
            {
                MessageBox.Show("Problème d'enregistrement");
            }
        }

        private void buttonModifFonction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fonction service = (Fonction)listeFctGest.SelectedItem;
                bddPersonnels.ModifyFonction(service, inputModifFonction.Text);
                inputModifFonction.Text = "";
                buttonModifFonction.IsEnabled = false;
                inputModifFonction.IsEnabled = false;
                LoadData();
            }
            catch
            {
                MessageBox.Show("Problème d'enregistrement");
            }
        }

        private void modif_Click(object sender, RoutedEventArgs e)
        {
            buttonModifFonction.IsEnabled = true;
            inputModifFonction.IsEnabled = true;
            Fonction fonction = (Fonction)listeFctGest.SelectedItem;
            inputModifFonction.Text = fonction.Intitule;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fonction fonction = (Fonction)listeFctGest.SelectedItem;
                bddPersonnels.DeleteFonction(fonction);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Il y a des employés de cette fonction. Elle ne peut pas être supprimé.");
            }
        }
    }
}
