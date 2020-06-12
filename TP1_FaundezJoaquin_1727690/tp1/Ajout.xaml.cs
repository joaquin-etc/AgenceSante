using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour Ajout.xaml
    /// </summary>
    public partial class Ajout : Window
    {
        ListeContacts listePersonnes = null;
        
        public Ajout(ref ListeContacts listeC)
        {
            InitializeComponent();
            listePersonnes = listeC;
        }

        private void Button_Ajout(object sender, RoutedEventArgs e)
        {
            //on doit vérifier que le nom, prenom et telephone sont là pour ajouter le contact dans le document
            if (nom.Text != string.Empty && prenom.Text != string.Empty && telephone.Text != string.Empty)
            {
                //on vérifie si le contact existe déjà
                bool existeDeja = false;
                foreach (Personne item in listePersonnes)
                {
                    if ((item.Nom.ToLower() == nom.Text.ToLower()) && (item.Prenom.ToLower() == prenom.Text.ToLower()))
                    {
                        existeDeja = true;
                    }
                }
                //s'il n'existe pas, on met la premiere lettre en majuscule de certaines cases et on le met dans la liste
                if (existeDeja == false)
                {
                    if (adresse1.Text != string.Empty)
                        adresse1.Text = adresse1.Text.ElementAt(0).ToString().ToUpper() + adresse1.Text.Substring(1);
                    if (adresse2.Text != string.Empty)
                        adresse2.Text = adresse2.Text.ElementAt(0).ToString().ToUpper() + adresse2.Text.Substring(1);
                    if (ville.Text != string.Empty)
                        ville.Text = ville.Text.ElementAt(0).ToString().ToUpper() + ville.Text.Substring(1);
                    if (province.Text != string.Empty)
                        province.Text = province.Text.ElementAt(0).ToString().ToUpper() + province.Text.Substring(1);
                    if (pays.Text != string.Empty)
                        pays.Text = pays.Text.ElementAt(0).ToString().ToUpper() + pays.Text.Substring(1);
                    if (cpostal.Text != string.Empty)
                        cpostal.Text = cpostal.Text.ElementAt(0).ToString().ToUpper() + cpostal.Text.Substring(1);
                    //ajout de la personne dans la liste
                    listePersonnes.Add(new Personne()
                    {
                        Nom = nom.Text.ElementAt(0).ToString().ToUpper() + nom.Text.Substring(1),
                        Prenom = prenom.Text.ElementAt(0).ToString().ToUpper() + prenom.Text.Substring(1),
                        Adresse1 = adresse1.Text,
                        Adresse2 = adresse2.Text,
                        Ville = ville.Text,
                        Province = province.Text,
                        Pays = pays.Text,
                        Telephone = telephone.Text,
                        Email = email.Text,
                        CPostal = cpostal.Text
                    });
                    //confirmation de l'ajout de la personne dans la liste
                    MessageBox.Show("Personne ajoutée avec succès!");
                    this.Close();
                }
                //si le contact existe deja, un message est affiché et la fenetre ajout est fermée
                else
                {
                    MessageBox.Show("Le contact existe déja, vous ne pouvez le rajouter");
                    this.Close();
                }
            }
            //un message est montré si l'un des champs obligatoires est manquant
            else
                MessageBox.Show("Les champs du nom, prénom et téléphone sont obligatoires");
        }

        private void Button_Annuler(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoite = MessageBox.Show("Voulez vous vraiment annuler?", "Fermeture de la boîte d'enregistrement", MessageBoxButton.YesNo);
            if (messageBoite == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
