using System.Data.Entity;
using System.Windows;
using System.Windows.Data;
using DataModel;
using ModelDataBase;

namespace MiniCRM
{
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
                //Load your data here and assign the result to the CollectionViewSource.
                //System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
                //myCollectionViewSource.Source = your data
                var zdarzenieViewSource = ((CollectionViewSource)(FindResource("orderViewSource")));
                _crmEntities.Orderiks.Load();
                zdarzenieViewSource.Source = _crmEntities.Orderiks.Local;
            }
        }

        private void orderDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
