using System;
using System.IO;
using System.Windows;
using DataBase;

namespace MiniCRM
{
    public interface ILog
    {
       
        void Log(Login log);
    }

    public partial class MainWindow : ILog
    {
        public CRMEntities CrmEntities;

        public MainWindow()
        {
            var login = new Login();
            login.ShowDialog();
            if (login.Llogin == GlobalOptions.Instance.ActiveUser.Login &&
                login.Ppassword == GlobalOptions.Instance.ActiveUser.Password)
                InitializeComponent();
            else
            {
                MessageBox.Show("Zły login lub hasło!", "Uwaga");
                Log(login);
                Application.Current.Shutdown();
            }

            try
            {
                CrmEntities = new CRMEntities();
            }
            catch (Exception)
            {
                MessageBox.Show("Chyba nie masz internetu.", "Uwaga");
                Application.Current.Shutdown();
            }
     
        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            CrmEntities.SaveChanges();
            CrmEntities.Dispose();
        }

        public void Log(Login log)
        {
            DateTime localDate = DateTime.Now;
            if (!File.Exists(".\\log.txt"))
            {
                //  System.IO.File.Create("D:\\log.txt");
                StreamWriter sw = File.CreateText(".\\log.txt");

                sw.WriteLine("Login: " + log.Llogin + " Haslo: " + log.Ppassword + " Data: " + localDate);
                sw.Close();
            }
            else
            {
                using (StreamWriter w = File.AppendText(".\\log.txt"))
                {
                    w.WriteLine("Login: " + log.Llogin + " Haslo: " + log.Ppassword + " Data: " + localDate);
                }
            }
        }
    }
}
