using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace tp1
{
   public class Personne:INotifyPropertyChanged
    {
        string nom, prenom, adresse1, adresse2, ville, province, pays, telephone, email, cPostal;

        public string Nom { get => nom; set
            {
                if (this.nom != value)
                {
                    this.nom = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Prenom { get => prenom; set
            {
                if (this.prenom != value)
                {
                    this.prenom = value;
                    OnPropertyChanged();
                }
            }

        }
        public string Adresse1 { get => adresse1; set
            {
                if (this.adresse1 != value)
                {
                    this.adresse1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Adresse2 { get => adresse2; set
            {
                if (this.adresse2 != value)
                {
                    this.adresse2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Ville { get => ville; set
            {
                if (this.ville != value)
                {
                    this.ville = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Province { get => province; set
            {
                if (this.province != value)
                {
                    this.province = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Pays { get => pays; set
            {
                if (this.pays != value)
                {
                    this.pays = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Telephone { get => telephone; set
            {
                if (this.telephone != value)
                {
                    this.telephone = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email { get => email; set
            {
                if (this.email != value)
                {
                    this.email = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CPostal { get => cPostal; set
            {
                if (this.cPostal != value)
                {
                    this.cPostal = value;
                    OnPropertyChanged();
                }
            }
        }
        //retourne ce qu'il y a ecrit dans la list box qui affiche les contacts
        public string Description
        {
            get { return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", nom, prenom, adresse1, adresse2, ville, province, pays, telephone, email, cPostal); }
        }
        
        //ceci verifie si des informations ont été modifiées
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
