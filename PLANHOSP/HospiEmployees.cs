using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PLANHOSP
{
    public partial class HospiEmployees: INotifyPropertyChanged
    {
        private String nom;
        private String prenom;
        private DateTime dateDeNaissance;
        private DateTime dateDentree;
        private int age;
        private String posteOccupe;

        public string Nom { get => nom; set { if (value != nom) { nom = value; NotifyPropertyChanged(); } } }
        public string Prenom { get => prenom; set { if (value != prenom) { prenom = value; NotifyPropertyChanged(); } } }
        public DateTime DateDeNaissance { get => dateDeNaissance; set { if (value != dateDeNaissance) { dateDeNaissance = value; NotifyPropertyChanged(); } } }
        public int Age { get => age; set { if (value != age) { age = value; NotifyPropertyChanged(); } } }
        public string PosteOccupe { get => posteOccupe; set { if (value != posteOccupe) { posteOccupe = value; NotifyPropertyChanged(); } } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }


    }
}
