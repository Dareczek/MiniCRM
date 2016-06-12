using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DataBase;

namespace MiniCRM
{
    public partial class ClientsORderss 
    {
        private readonly CRMEntities _crmEntities;
        public ClientsORderss()
        {
            InitializeComponent();
            _crmEntities = ((MainWindow)Application.Current.MainWindow).CrmEntities;
            ClientNameColumn.ItemsSource = _crmEntities.Clients.Local;
            ProductNameColumn.ItemsSource = _crmEntities.Products.Local;
            CurrencyComboBox.ItemsSource = Enum.GetValues(typeof(Currency));
            CurrencyComboBox.SelectedIndex = 0;
            ProductNameColumn.ItemsSource = _crmEntities.Products.Local;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var clientOrderViewSource = ((CollectionViewSource)(FindResource("ClientOrderViewSource")));
                _crmEntities.ClientOrders.Load();
                clientOrderViewSource.Source = _crmEntities.ClientOrders.Local;
            }
        }
        private void SomeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            var currency = CurrencyComboBox.SelectedIndex;
            var couter = new CountIncomes(currency);
            var result = couter.Count(_crmEntities);
            LabelResult.Content = Math.Round(result, 2).ToString();
            switch (currency + 1)
            {
                case 1:
                    LabelResult.Content += " PLN";
                    break;
                case 2:
                    LabelResult.Content += " €";
                    break;
                case 3:
                    LabelResult.Content += " $";
                    break;
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalOptions.Instance.ChangeGlobalOptions();
        }

        private void ClientOrderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _crmEntities.SaveChanges();
        }
    }
}
