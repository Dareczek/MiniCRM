using System.Data.Entity;
using System.Windows;
using System.Windows.Data;
using ModelDataBase;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for Zamowienia.xaml
    /// </summary>
    public partial class SomeoneOrders
    {
        private CRMEntities _crmEntities;
        public SomeoneOrders()
        {
            InitializeComponent();
            _crmEntities = ((MainWindow)Application.Current.MainWindow).CrmEntities;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var zdarzenieViewSource = ((CollectionViewSource)(FindResource("clientOrderViewSource")));
                _crmEntities.ClientOrders.Load();
                zdarzenieViewSource.Source = _crmEntities.ClientOrders.Local;
            }
        }
    }
}
