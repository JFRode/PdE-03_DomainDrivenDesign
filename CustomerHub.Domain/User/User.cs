using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerHub.Domain.User
{
    public class User : IUser
    {
        public Guid Id { get; set; }

        [MaxLength(255)]
        [MinLength(5)]
        public string Name { get; set; }

        [MaxLength(255)]
        [MinLength(5)]
        public string Email { get; set; }

        [MaxLength(20)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}