using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Users
    {
        public Users()
        {
            UserExchangeTaxes = new HashSet<UserExchangeTaxes>();
            UserOperationHistories = new HashSet<UserOperationHistories>();
        }

        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public Wallets User { get; set; }
        public ICollection<UserExchangeTaxes> UserExchangeTaxes { get; set; }
        public ICollection<UserOperationHistories> UserOperationHistories { get; set; }
    }
}
