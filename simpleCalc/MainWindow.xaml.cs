using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace simpleCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Product> products => Product.GetProducts().ToObservableCollection();
        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<Product> basket;
        public ObservableCollection<BasketView> BasketView => basket
            .GroupBy(x => new { x.Code, x.Name, x.Price })
            .Select(x => new BasketView { Code = x.Key.Code, Name = x.Key.Name, Price = x.Key.Price, Count = x.Count(), Total = x.Sum(s => s.Price) })
            .ToObservableCollection();



        public decimal Total => basket.Sum(x => x.Price);

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Products = products;
            basket = new ObservableCollection<Product>();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void addToBasket(object sender, RoutedEventArgs e)
        {
            var item = (Product)shopBox.SelectedItem;

            basket.Add(item);




            OnPropertyChanged(nameof(Total));
            OnPropertyChanged(nameof(BasketView));
        }

        private void removeFromBasket(object sender, RoutedEventArgs e)
        {
            var item = (BasketView)basketBox.SelectedItem;

            if (item != null)
            {

                var product = basket
                    .Where(x => x.Code == item.Code)
                    .First();

                basket.Remove(product);



                OnPropertyChanged(nameof(Total));
                OnPropertyChanged(nameof(BasketView));
            }
        }

        private void clearBasket(object sender, RoutedEventArgs e)
        {
            basket.Clear();

            OnPropertyChanged(nameof(Total));
            OnPropertyChanged(nameof(BasketView));
        }

        private void searchFromShop(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                Products = products
                    .Where(x => x.Name.ToLower()
                    .Contains(searchBox.Text.ToLower()))
                    .ToObservableCollection();
            }
            else
            {
                Products = products;
            }

            OnPropertyChanged(nameof(Products));
        }

        private void selectProductType(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
