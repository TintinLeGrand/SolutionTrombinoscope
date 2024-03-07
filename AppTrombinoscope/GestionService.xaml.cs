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
        }

        private void buttonAddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = new Service();
                service.Id = 10;
                service.Intitule = inputAddService.Text;
                bddPersonnels.NewService(service);
            }
            catch
            {
                MessageBox.Show("Problème d'enregistrement");
            }
        }
    }
}