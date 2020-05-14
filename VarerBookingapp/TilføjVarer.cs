using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VarerBookingapp
{
    public class TilføjVarer : INotifyPropertyChanged
    {
        private string navn;
        private int antalAfVarer;

        public string Navn
        {
            get { return navn; }
            set
            {
                navn = value;
                OnPropertyChanged();
            }
        }

        public int AntalAfVarer
        {
            get { return antalAfVarer; }
            set
            {
                antalAfVarer = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public TilføjVarer(string navn, int antalAfVarer)
        {
            this.Navn = navn;
            this.AntalAfVarer = antalAfVarer;
        }

        public TilføjVarer()
        {
        }
    }
}