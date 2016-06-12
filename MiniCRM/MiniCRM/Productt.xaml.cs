using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DataBase;

namespace MiniCRM
{
   
    public partial class Productt
    {
        private readonly CRMEntities _crmEntities;
        public Productt()
        {
            InitializeComponent();
            _crmEntities = ((MainWindow)Application.Current.MainWindow).CrmEntities;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var productViewSource = ((CollectionViewSource)(FindResource("ProductViewSource")));
                _crmEntities.Products.Load();
                productViewSource.Source = _crmEntities.Products.Local;
            }
        }

        private void SomeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalOptions.Instance.ChangeGlobalOptions();
        }

        private void ProductDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _crmEntities.SaveChanges();
        }
    }
}
