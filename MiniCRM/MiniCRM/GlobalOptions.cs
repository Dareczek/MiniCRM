using System;
using System.Xml.Linq;

namespace MiniCRM
{
    public struct User
    {
        public string Login;
        public string Password;
    }

    public sealed class GlobalOptions
    {
        private static GlobalOptions _globalOptions;
        private const string FileName = "Options.xml";


        public User ActiveUser;    
        public string ConnectionString; 
        public static GlobalOptions Instance => _globalOptions ?? (_globalOptions = new GlobalOptions());
        private GlobalOptions()
        {

            try
            {

                var xml = XDocument.Load(FileName);
                if (xml.Root == null) return;
                var element = xml.Root.Element("users");
                if (element != null)
                {
                    var iEnumerable = element.Elements("user");
                    foreach (var xElement in iEnumerable)
                    {
                        element = xElement.Element("login");
                        if (element != null) ActiveUser.Login = element.Value;
                        element = xElement.Element("password");
                        if (element != null) ActiveUser.Password = element.Value;

                    }
                }
                element = xml.Root.Element("connectionString");
                if (element != null) ConnectionString = element.Value;

            }
            catch (Exception)
            {
                FirstLaunch();
            }
        }

        private void FirstLaunch()
        {
            var optionsWindow = new WindowOption();
            optionsWindow.ShowDialog();
            var xml = new XDocument(
                new XComment("Czy to działa?"),
                new XElement("options",
                        new XElement("users",
                            new XElement("user",
                                new XElement("login", optionsWindow.Login),
                                new XElement("password", optionsWindow.Password)
                            )
                        ),
                    new XElement("connectionString", optionsWindow.ConectionString)

                )
            );
            xml.Save(FileName);

            ConnectionString = optionsWindow.ConectionString;

        }

        public void ChangeGlobalOptions()
        {
            var optionsWindow = new WindowOption(ActiveUser.Login, ActiveUser.Password, ConnectionString);
            optionsWindow.ShowDialog();

            if (optionsWindow.Login != ActiveUser.Login || optionsWindow.Password != ActiveUser.Password)
            {
                ActiveUser.Login = optionsWindow.Login;
                ActiveUser.Password = optionsWindow.Password;
                ConnectionString = optionsWindow.ConectionString;

                var xml = new XDocument(
                    new XComment("Czy to działa?"),
                    new XElement("options",
                        new XElement("users",
                            new XElement("user",
                                new XElement("login", ActiveUser.Login),
                                new XElement("password", ActiveUser.Password)
                                )
                            ),
                        new XElement("connectionString", ConnectionString)
                        )
                    );
                xml.Save(FileName);
            }
        }
    }
}
