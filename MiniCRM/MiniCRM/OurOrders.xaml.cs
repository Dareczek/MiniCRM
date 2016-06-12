using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ModelDataBase;

namespace MiniCRM
{
    enum NoYes
    {
        No,
        Yes
    }

    enum Status
    {
        Złożone,
        Opłacone,
        Wysłane,
        Dostarczone
    }
    /// <summary>
    /// Interaction logic for Zamowienia.xaml
    /// </summary>
    public partial class OurOrders
    {
        private CRMEntities _crmEntities;
        public OurOrders()
        {
            InitializeComponent();
            _crmEntities = ((MainWindow)Application.Current.MainWindow).CrmEntities;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var zdarzenieViewSource = ((CollectionViewSource)(FindResource("OrderikViewSource")));
                _crmEntities.Orderiks.Load();
                zdarzenieViewSource.Source = _crmEntities.Orderiks.Local;
            }
        }
    }
}
