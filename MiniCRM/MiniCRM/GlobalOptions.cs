using System;
using System.Collections.Generic;
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
        private User _activeUser;       // 2. po udanym zalogowaniu oznaczymy kto używa programu (to będzie potrzebne do loga)

        public List<User> Users;        // 1. trzeba będzie jeszcze dorobić okienko logowania i zobaczyć,
        public string ConnectionString; // czy dane z okienka zgadzają się z jednym z elementów tej listy
        public string EmailAdress;
        public static GlobalOptions Instance => _globalOptions ?? (_globalOptions = new GlobalOptions());
        private GlobalOptions()
        {
            Users = new List<User>();
            try
            {
                var user = new User();
                var xml = XDocument.Load(FileName);
                if (xml.Root == null) return;
                var element = xml.Root.Element("users");
                if (element != null)
                {
                    var iEnumerable = element.Elements("user");
                    foreach (var xElement in iEnumerable)
                    {
                        element = xElement.Element("login");
                        if (element != null) user.Login = element.Value;
                        element = xElement.Element("password");
                        if (element != null) user.Password = element.Value;
                        Users.Add(user);
                    }
                }
                element = xml.Root.Element("connectionString");
                if (element != null) ConnectionString = element.Value;
                element = xml.Root.Element("email");
                if (element != null) EmailAdress = element.Value;

                // w tym miejscu trzeba będzie wywołać logowanie
                _activeUser.Login = user.Login; // to jest przejściowe
                _activeUser.Password = user.Password;
            }
            catch (Exception)
            {
                FirstLaunch();
                //throw;
            }
        }

        private void FirstLaunch()
        {
            var optionsWindow = new OkienkoOpcje();
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
                    new XElement("connectionString", optionsWindow.ConectionString),
                    new XElement("email", optionsWindow.EmailAddress)
                )
            );
            xml.Save(FileName);

            _activeUser.Login = optionsWindow.Login;
            _activeUser.Password = optionsWindow.Password;
            Users.Add(_activeUser);

            ConnectionString = optionsWindow.ConectionString;
            EmailAdress = optionsWindow.EmailAddress;
        }

        public void ChangeGlobalOptions()
        {
            var optionsWindow = new OkienkoOpcje(_activeUser.Login, _activeUser.Password, ConnectionString, EmailAdress);
            optionsWindow.ShowDialog();

            if (optionsWindow.Login != _activeUser.Login || optionsWindow.Password != _activeUser.Password)
                // wywalić z listy i zmienić w pliku xml
                _activeUser.Login = optionsWindow.Login;
            _activeUser.Password = optionsWindow.Password;
            Users.Add(_activeUser);
            ConnectionString = optionsWindow.ConectionString;
            EmailAdress = optionsWindow.EmailAddress;
        }
    }
}
