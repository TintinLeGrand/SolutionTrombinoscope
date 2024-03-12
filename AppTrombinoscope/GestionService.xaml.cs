using System.Windows;
using BddpersonnelContext;
using DllbddPersonnels;

namespace AppTrombinoscope
{
    public partial class GestionService : Window
    {
        bddpersonnels bddPersonnels;

        public GestionService(bddpersonnels bddPersonnels)
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
                    var services = bddPersonnels.GetAllService();
                    listeServicesGest.ItemsSource = bddPersonnels.GetAllService().ToArray();
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


        private void buttonAddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = new Service();
                service.Intitule = inputAddService.Text;
                bddPersonnels.NewService(service);
                inputAddService.Text = "";
                LoadData();
            }
            catch
            {
                MessageBox.Show("Problème d'enregistrement");
            }
        }
    }
}