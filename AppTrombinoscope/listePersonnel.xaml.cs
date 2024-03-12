using BddpersonnelContext;
using DllbddPersonnels;
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
using System.Windows.Shapes;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour listePersonnel.xaml
    /// </summary>
    public partial class listePersonnel : Window
    {
        bddpersonnels bddPersonnels;

        public listePersonnel(bddpersonnels bddPersonnels)
        {
            InitializeComponent();
            this.bddPersonnels = bddPersonnels;
            List<Personnel> liste = bddPersonnels.GetAllPersonnel();
            listepersonnelDataGrid.ItemsSource = liste ;
        }
    }

}
