using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace tp1
{
   public class ListeContacts : ObservableCollection<Personne>
    {
        public ListeContacts()
        {
            //on lit le fichier pour mettre les contacts deja enregistrés dans le programme
            StreamReader sr = new StreamReader("Données.txt");
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var elements = line.Split(';');

                Add(new Personne()
                {
                    Nom = elements[0],
                    Prenom = elements[1],
                    Adresse1 = elements[2],
                    Adresse2 = elements[3],
                    Ville = elements[4],
                    Province = elements[5],
                    Pays = elements[6],
                    Telephone = elements[7],
                    Email = elements[8],
                    CPostal = elements[9]
                });
            }
        }
    }
}
