using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DataBase;

namespace MiniCRM
{
    internal enum Currency
    {
        Złoty,
        Euro,
        Dolar    
    }
    public partial class OurOrders
    {
        private readonly CRMEntities _crmEntities;
        public OurOrders()
        {
            InitializeComponent();
            _crmEntities = ((MainWindow)Application.Current.MainWindow).CrmEntities;
            CurrencyComboBox.ItemsSource = Enum.GetValues(typeof(Currency));
            CurrencyComboBox.SelectedIndex = 0;
            ProductNameColumn.ItemsSource = _crmEntities.Products.Local;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var orderikViewSource = ((CollectionViewSource)(FindResource("OrderikViewSource")));
                _crmEntities.Orderiks.Load();
                orderikViewSource.Source = _crmEntities.Orderiks.Local;
            }
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            var currency = CurrencyComboBox.SelectedIndex;
            var couter = new CountOutgoings((double)VatNumericUpDown.Value, currency);
            var result = couter.Count(_crmEntities);
            LabelResult.Content = Math.Round(result,2).ToString();
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
        private void SomeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalOptions.Instance.ChangeGlobalOptions();
        }

        private void OrderikDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _crmEntities.SaveChanges();
        }
    }
}
