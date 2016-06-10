using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DataModel;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for Zamowienia.xaml
    /// </summary>
    public partial class Zamowienia
    {
       // private Model _model;
        public Zamowienia()
        {
            InitializeComponent();
           // _model = ((MainWindow)Application.Current.MainWindow).Model;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Do not load your data at design time.
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                //Load your data here and assign the result to the CollectionViewSource.
                //System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
                //myCollectionViewSource.Source = your data
                var zdarzenieViewSource = ((CollectionViewSource)(FindResource("orderViewSource")));
               // _model.Orders.Load();
               // zdarzenieViewSource.Source = _model.Orders.Local;
            }
        }
    }
}
