using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using DataBase;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for Zamowienia.xaml
    /// </summary>
    public interface INamesClients
    {
        // interface members
        string showTransaction(CRMEntities crmEntities);
    }
    public partial class Clientss : INamesClients
    {
        private string[] Name = { "Klient Detaliczny","Firma" };
        private CRMEntities _crmEntities;
        public Clientss()
        {
            InitializeComponent();
            _crmEntities = ((MainWindow)Application.Current.MainWindow).CrmEntities;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                var zdarzenieViewSource = ((CollectionViewSource)(FindResource("clientViewSource")));
                _crmEntities.Clients.Load();
                zdarzenieViewSource.Source = _crmEntities.Clients.Local;
            }
        }

        public string showTransaction(CRMEntities crmEntities)
        {
            foreach (var counter in crmEntities.Clients)
            {
                var nazwa = from p in crmEntities.Clients
                    where (counter.ClientId == p.ClientId)
                    select p.Nip;
                if (counter.Nip != "")
                    return counter.Nip;
            }
            return null;
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}