using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
using DataBase;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for Productt.xaml
    /// </summary>
    public partial class Productt : UserControl
    {
        private CRMEntities _crmEntities;
        public Productt()
        {
            InitializeComponent();
            _crmEntities = ((MainWindow)Application.Current.MainWindow).CrmEntities;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var zdarzenieViewSource = ((CollectionViewSource)(FindResource("productViewSource")));
                _crmEntities.Products.Load();
                zdarzenieViewSource.Source = _crmEntities.Products.Local;
            }
        }
    }
}
