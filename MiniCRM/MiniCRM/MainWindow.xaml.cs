﻿using System;
using System.Windows;
using DataBase;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow
    {
        public CRMEntities CrmEntities;
        public MainWindow()
        {

            var login = new Login();
            login.ShowDialog();
            if (login._login == GlobalOptions.Instance._activeUser.Login && login._password == GlobalOptions.Instance._activeUser.Password)
                InitializeComponent();
            else
            {
                MessageBox.Show("Zły login lub hasło!", "Uwaga");
                return;
            }

            try
            {
                CrmEntities = new CRMEntities();
            }
            catch (Exception)
            {
                MessageBox.Show("Chyba nie masz internetu.", "Uwaga");
                return;
            }

            string lolC = GlobalOptions.Instance.ConnectionString;
            string lolL = GlobalOptions.Instance._activeUser.Login;
            string lolP = GlobalOptions.Instance._activeUser.Password;
            
            // DataBase.Instance.DeleteDataBase();
            // DataBase.Instance.CreateDataBase();
            // DataBase.Instance.InsertDataBase();
            // DataBase.Instance.DropDataBase();
            // DataBase.Instance.DeleteDataBase();
        }

        //private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    CrmEntities.SaveChanges();
        //}

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            CrmEntities.SaveChanges();
            CrmEntities.Dispose();
        }
    }
}
