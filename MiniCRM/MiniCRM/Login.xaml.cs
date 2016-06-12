using System.Windows;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        public string _login;
        public string _password;

        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            _login = TextBox1.Text;
            _password = TextBox2.Text;
            Close();
        }
    }
}
