using System;

namespace CustomerHub.Domain.User
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}