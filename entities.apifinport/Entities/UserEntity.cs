
using System.ComponentModel.DataAnnotations;

namespace entities.apifinport.Entities
{
    public class UserEntity
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
