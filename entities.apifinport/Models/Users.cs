using entities.apifinport.Entities;
using System;
using System.Collections.Generic;

namespace entities.apifinport.Models
{
    public partial class Users : BaseEntity
    {
        public Users()
        {
            UserExchangeTaxes = new HashSet<UserExchangeTaxes>();
            UserOperationHistories = new HashSet<UserOperationHistories>();
            Wallets = new HashSet<Wallets>();
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public ICollection<UserExchangeTaxes> UserExchangeTaxes { get; set; }
        public ICollection<UserOperationHistories> UserOperationHistories { get; set; }
        public ICollection<Wallets> Wallets { get; set; }
    }
}
