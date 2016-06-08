using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class Settings
    {
        [Key]
        public string Login  { get; set; }
        public string Password { get; set; }
    }
}
