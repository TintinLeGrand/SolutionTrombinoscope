using System.Windows;
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


    }
}