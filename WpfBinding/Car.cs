using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfBinding
{
    public class Car:INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;  OnPropertyChanged(); }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged(); }
        }

        private string vendor;

        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; OnPropertyChanged(); }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; OnPropertyChanged(); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
