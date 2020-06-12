using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tp1
{
    /// <summary>
    /// Logique d'interaction pour Enregistrement.xaml
    /// </summary>
    public partial class Enregistrement : Window
    {
        string nompersonne = null;
        //Initialisation de la liste de contacts
        public ListeContacts listeC = new ListeContacts();

        public Enregistrement(string value)
        {
            InitializeComponent();
            nompersonne = value;
            this.DataContext = listeC;
        }

        //Le clique sur nouveau ouvre la fenetre ajout
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Window = new Ajout(ref listeC);
            Window.Show();
        }

        private void Button_Sauvegarde(object sender, RoutedEventArgs e)
        {
            StreamWriter ecrire = new StreamWriter("Données.txt");
            string line = string.Empty;

            foreach (Personne item in listeC)
            {
                //line est la ligne sauvegardée dans le fichier selon le format demandé
                line = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", item.Nom, item.Prenom, item.Adresse1, item.Adresse2, item.Ville, item.Province, item.Pays, item.Telephone, item.Email, item.CPostal);
                ecrire.WriteLine(line);
            }
            ecrire.Flush();
            MessageBox.Show("Sauvegardement effectué");
        }

        private void Button_Quitter(object sender, RoutedEventArgs e)
        {
            //on verifie si l'usager veut vraiment quitter le programme et s'il veut sauvegarder au cas ou il quitte
            MessageBoxResult messageBoite = MessageBox.Show("Voulez vous vraiment quitter?", "Fin de session", MessageBoxButton.YesNo);
            if (messageBoite == MessageBoxResult.Yes)
            {
                MessageBoxResult messageBoite2= MessageBox.Show("Voulez vous sauvegarder avant de quitter?", "Fin de session", MessageBoxButton.YesNo);
                if (messageBoite2 == MessageBoxResult.Yes)
                {
                    Button_Sauvegarde(sender, e);
                }
                else
                {
                    MessageBox.Show("Vous quittez sans sauvegarder, au revoir!");
                }
                Close();
            }
            else if (messageBoite == MessageBoxResult.No)
            {
                MessageBox.Show("Merci de ne pas nous quitter");
            }
        }

        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {
            //suppression d'un contact
            var ligne = (Personne)listeboxPersonnes.SelectedItem;
            listeC.Remove(listeC.First(s => s.Nom == ligne.Nom));
            MessageBox.Show("Contact supprimé avec succès");
        }

        private void Button_Recherche(object sender, RoutedEventArgs e)
        {
            int i = 0;

            foreach(Personne item in listeC)
            {
                //si le nom de l'item est égal à celui que l'utilisateur a marqué (et on met la premiere
                //      lettre en majuscule) on modifie la valeur de i et on selectionne l'item
                if(item.Nom==recherchebox.Text.ElementAt(0).ToString().ToUpper() + recherchebox.Text.Substring(1))
                {
                    listeboxPersonnes.SelectedItem = item;
                    i++;
                }
            }

            //si i=0 donc s'il n'a pas été modifié, cela veut dire que la personne n'a pas été trouvé
            if (i == 0)
            {
                MessageBox.Show("Le contact n'a pas été trouvé");
            }
        }
    }
}
