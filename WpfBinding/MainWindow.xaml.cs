using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Car> cars;

        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged(); }
        }


        public MainWindow()
        {
            InitializeComponent();
            Car = new Car
            {
                Id = 1,
                Model = "La Ferrari",
                Vendor = "Ferrari",
                Year = 2020
            };


            Cars = new ObservableCollection<Car>
            {
                new Car
                {
                    Id=1,
                     Model="E-200",
                     Vendor="Mercedes",
                      Year=2010
                },
                new Car
                {
                    Id=2,
                    Model="GL-500",
                    Vendor="Mercedes",
                    Year=2014
                },
                new Car
                {
                    Id=3,
                    Model="Optima K5",
                    Vendor="Kia",
                    Year=2019
                }
            };

            this.DataContext = this;
        }
        public void OnPropertyChanged([CallerMemberName]string name=null)
        {
            PropertyChangedEventHandler handler=PropertyChanged;    
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["PrimaryColor"] = this.Resources["SecondaryColor"];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Car.Model = "No Model";
            Car.Year = 100;
            //Car = new Car
            //{
            //    Id = 2,
            //    Model = "Malibu",
            //    Vendor = "Chevrolet",
            //    Year = 2021
            //};
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Cars = null;
            //Cars.Add(new Car
            //{
            //    Id=5,
            //     Model="Sonata",
            //     Vendor="Hyundai",
            //      Year=2021
            //});
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var car=myListBox.SelectedItem as Car;
            InfoWindow window = new InfoWindow();
            window.InfoCar = car;
            window.ShowDialog();
        }
    }
}
