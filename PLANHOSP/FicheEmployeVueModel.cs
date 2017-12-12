using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLANHOSP
{
    class FicheEmployeVueModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string str = "")
        {
            if (PropertyChanged!=null) // Vérifier qu'il ya au moins quelqu'un abonné à l'évent property changed
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }

        private ObservableCollection<HospiEmployees> fichesEmploye;

        public ObservableCollection<HospiEmployees> FichesEmploye { get => fichesEmploye;
            set { 
                if (value!=fichesEmploye)
                {
                    fichesEmploye = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private HospiEmployees ficheEmployeSelectionnee;

        public HospiEmployees FicheEmployeSelectionnee
        {
            get => ficheEmployeSelectionnee;
            set
            {
                if (value != ficheEmployeSelectionnee)
                {
                    ficheEmployeSelectionnee = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public FicheEmployeVueModel()
        {
            FichesEmploye = new ObservableCollection<HospiEmployees>();
            FicheEmployeSelectionnee = new HospiEmployees()
            {
                Nom = "Massamba",
                Prenom = "Lorraine",
                Age = 23,
                PosteOccupe = "Directrice",
                DateDeNaissance = DateTime.Now

            };
            FichesEmploye.Add(FicheEmployeSelectionnee);
        }
        
        public ICommand AjoutFicheEmploye {
            get {
                if (ajoutFicheEmploye == null)
                {
                    ajoutFicheEmploye = new RelayCommand<Object>((obj) => FichesEmploye.Add(new HospiEmployees ()));
                }
                return ajoutFicheEmploye;
            }
        }

        public ICommand RetraitFicheClient {
            get
            {
                if (retraitFicheEmploye == null)
                {
                    retraitFicheEmploye = new RelayCommand<HospiEmployees>((employe) => FichesEmploye.Remove(employe));
                }
                return retraitFicheEmploye;
            }
        }

        public ICommand EditionFicheEmploye {
            get {
                if (editionFicheEmploye == null)
                {
                    editionFicheEmploye = new RelayCommand<HospiEmployees>((employe) => ficheEmployeSelectionnee = employe);
                }
                return editionFicheEmploye;
            }
        }

        private ICommand ajoutFicheEmploye;

        private ICommand retraitFicheEmploye;

        private ICommand editionFicheEmploye;
        
    }
}
