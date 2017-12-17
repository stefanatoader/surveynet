using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
