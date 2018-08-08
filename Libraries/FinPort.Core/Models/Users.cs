using System;
using System.Collections.Generic;

namespace FinPort.Core.Models
{
    public partial class Users : BaseEntity
    {
        public Users()
        {
            UserExchangeTaxes = new HashSet<UserExchangeTaxes>();
            UserOperationHistories = new HashSet<UserOperationHistories>();
            Wallet = new Wallets()
            {
                Amount = 0,
                CurrencyId = 1
            };
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public Wallets Wallet { get; set; }
        public ICollection<UserExchangeTaxes> UserExchangeTaxes { get; set; }
        public ICollection<UserOperationHistories> UserOperationHistories { get; set; }
    }
}
