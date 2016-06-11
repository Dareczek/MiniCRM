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


        public User _activeUser;       // 1. trzeba będzie jeszcze dorobić okienko logowania i zobaczyć,
        public string ConnectionString; // czy dane z okienka zgadzają się z jednym z elementów tej listy
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
                        if (element != null) _activeUser.Login = element.Value;
                        element = xElement.Element("password");
                        if (element != null) _activeUser.Password = element.Value;
                       
                    }
                }
                element = xml.Root.Element("connectionString");
                if (element != null) ConnectionString = element.Value;
                element = xml.Root.Element("email");
               
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
                    new XElement("connectionString", optionsWindow.ConectionString)
                    
                )
            );
            xml.Save(FileName);

            

            ConnectionString = optionsWindow.ConectionString;
           
        }

        public void ChangeGlobalOptions()
        {
            var optionsWindow = new OkienkoOpcje(_activeUser.Login, _activeUser.Password, ConnectionString);
            optionsWindow.ShowDialog();

            if (optionsWindow.Login != _activeUser.Login || optionsWindow.Password != _activeUser.Password)
                // wywalić z listy i zmienić w pliku xml
                _activeUser.Login = optionsWindow.Login;
            _activeUser.Password = optionsWindow.Password;
         
            ConnectionString = optionsWindow.ConectionString;
          
        }
    }
}
