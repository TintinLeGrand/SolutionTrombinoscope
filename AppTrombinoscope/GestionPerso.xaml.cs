using BddpersonnelContext;
using DllbddPersonnels;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AppTrombinoscope
{
    /// <summary>
    /// Logique d'interaction pour GestionPerso.xaml
    /// </summary>
    public partial class GestionPerso : Window
    {

        bddpersonnels bddPersonnels;

        public GestionPerso(bddpersonnels bddPersonnels)
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
                personnel.Prenom = prenomTextBox.Text;
                personnel.Nom = nomTextBox.Text;
                personnel.Service = (Service)serviceList.SelectedItem;
                personnel.Fonction = (Fonction)fonctionList.SelectedItem;
                personnel.Telephone = telephoneTextBox.Text;
                personnel.Photo = ImageEnByteArray(photo.Source);

                bddPersonnels.NewPersonnel(personnel);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Problème d'enregistrement");
            }
        }

        private void annulerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changerPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers d'image (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|Tous les fichiers (*.*)|*.*";

            if(openFileDialog.ShowDialog() == true)
            {
                photo.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private byte[] ImageEnByteArray(ImageSource source)
        {
            BitmapSource bitmap = (BitmapSource)source;

            using(MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
    }
}
