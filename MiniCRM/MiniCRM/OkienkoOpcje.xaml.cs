using System.Windows;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OkienkoOpcje
    {
        public string ConectionString;
        public string EmailAddress;
        public string Login;
        public string Password;
        public OkienkoOpcje()
        {
            InitializeComponent();
        }
        public OkienkoOpcje(string s1, string s2, string s3, string s4)
        {
            InitializeComponent();
            TextBox1.Text = s1;
            TextBox2.Text = s2;
            TextBox3.Text = s3;
            TextBox4.Text = s4;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Login = TextBox1.Text;
            Password = TextBox2.Text;
            ConectionString = TextBox3.Text;
            EmailAddress = TextBox4.Text;
            if (Login == "" || Password == "" || ConectionString == "" || EmailAddress == "")
                MessageBox.Show("Człowieku! Co Ty wyprawiesz!? Opanuj się i wprowadź ten tekst!!!", "Uwaga");
            else
                Close();
        }
    }
}
