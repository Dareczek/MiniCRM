using System.Windows;

namespace MiniCRM
{
    public partial class Login
    {
        public string Llogin;
        public string Ppassword;
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Llogin = TextBox1.Text;
            Ppassword = TextBox2.Text;
            Close();
        }
    }
}
