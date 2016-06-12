using System.Data.Entity;
using System.Windows;
using System.Windows.Data;
using DataBase;

namespace MiniCRM
{
    public partial class Clientss
    {
        private readonly CRMEntities _crmEntities;
        public Clientss()
        {
            InitializeComponent();
            _crmEntities = ((MainWindow)Application.Current.MainWindow).CrmEntities;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var collectionViewSource = ((CollectionViewSource)(FindResource("ClientViewSource")));
                _crmEntities.Clients.Load();
                collectionViewSource.Source = _crmEntities.Clients.Local;
            }
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalOptions.Instance.ChangeGlobalOptions();
        }

        private void ClientViewSource_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _crmEntities.SaveChanges();
        }
    }
}