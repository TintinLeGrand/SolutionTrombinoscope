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
                if(inputAddFct.Text == "")
                {
                    throw new System.Exception();
                }
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
    }
}
