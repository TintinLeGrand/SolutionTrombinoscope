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

        private void buttonAddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fonction fonction = new Fonction();
                fonction.Intitule = inputAddFct.Text;
                bddPersonnels.NewFonction(fonction);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Problème d'enregistrement");
            }
        }
    }
}
