
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using entities.apifinport.Entities;

namespace entities.apifinport.Models
{
    public class User : BaseEntity
    {
        [Key]
        public override int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<UserOperationHistory> UserOperationHistories { get; set; }
    }
}