using DataModel;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        //public Model Model = new Model();
        public MainWindow()
        {
            InitializeComponent();

            string lolC = GlobalOptions.Instance.ConnectionString;
            string lolL = GlobalOptions.Instance._activeUser.Login;
            string lolP = GlobalOptions.Instance._activeUser.Password;
            // DataBase.Instance.DeleteDataBase();
          //  DataBase.Instance.CreateDataBase();
          //  DataBase.Instance.InsertDataBase();
           // DataBase.Instance.DropDataBase();
           // DataBase.Instance.DeleteDataBase();
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
           
        }
    }
}
