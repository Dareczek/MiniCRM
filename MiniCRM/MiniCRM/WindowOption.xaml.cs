using System.Windows;

namespace MiniCRM
{
    public partial class WindowOption
    {
        public string ConectionString;
        public string Login;
        public string Password;
        public WindowOption()
        {
            InitializeComponent();
        }
        public WindowOption(string s1, string s2, string s3)
        {
            InitializeComponent();
            TextBox1.Text = s1;
            TextBox2.Text = s2;
            TextBox3.Text = s3;
            
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Login = TextBox1.Text;
            Password = TextBox2.Text;
            ConectionString = TextBox3.Text;
            
            if (Login == "" || Password == "" || ConectionString == "")
                MessageBox.Show("Człowieku! Co Ty wyprawiesz!? Opanuj się i wprowadź ten tekst!!!", "Uwaga");
            else
                Close();
        }

        private void Create_OnClickButton(object sender, RoutedEventArgs e)
        {
            DataBase.Instance.CreateDataBase();
        }

        private void Drop_OnClickButton(object sender, RoutedEventArgs e)
        {
            DataBase.Instance.DropDataBase();
        }
    }
}
