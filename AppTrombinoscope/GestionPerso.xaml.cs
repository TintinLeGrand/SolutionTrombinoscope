using BddpersonnelContext;
using DllbddPersonnels;
using System.Windows;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour GestionPerso.xaml
    /// </summary>
    public partial class GestionPerso : Window
    {

        bddpersonnels bddPersonnels;

        public GestionPerso()
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
                    serviceList.ItemsSource = bddPersonnels.GetAllService().ToArray();

                    var fonctions = bddPersonnels.GetAllFonction();
                    fonctionList.ItemsSource = bddPersonnels.GetAllFonction().ToArray();
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



        private void enregistrerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Personnel personnel = new Personnel();
                personnel.Id = 10;
                //personnel.Nom = inputAddPerso.Text;
                bddPersonnels.NewPersonnel(personnel);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Problème d'enregistrement");
            }
        }

        private void annulerButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void changerPhoto_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }
    }
}
