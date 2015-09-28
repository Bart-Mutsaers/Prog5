using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRepository.ViewModel
{
    public class CarVM : ViewModelBase
    {
        private Car _car;

        public String Merk
        {
            get { return _car.Merk; } 
            set
            {
                _car.Merk = value;
                RaisePropertyChanged();
            }
        }

        public String Model
        {
            get { return _car.Model; } 
            set
            {
                _car.Model = value;
                RaisePropertyChanged();
            }
        }

        public double Prijs
        {
            get { return _car.Prijs; }
            set
            {
                _car.Prijs = value;
                RaisePropertyChanged();
            }
        }

        public double Bijtelling
        {
            get { 
              // oude code
              //return _car.Prijs;
            return _car.Bijtelling;
          }
            set
            {
              // oude code
                //_car.Prijs = value;
                _car.Bijtelling = value;
                RaisePropertyChanged();
            }
        }

        public double LeaseKostenPerMaand
        {
            get {
                return this.Prijs / this.Bijtelling * 2;
            }
        }

        public double LeaseKostenPerJaar
        {
            get {
                return this.LeaseKostenPerMaand * 12;
            }
        }

        public bool Actief
        {
            get { return _car.Actief; }
            set
            {
                _car.Actief = value;
                RaisePropertyChanged();
            }
        }

        public CarVM()
        {

        }

        public CarVM(Car car)
        {
            this._car = car;
        }
    }
}
