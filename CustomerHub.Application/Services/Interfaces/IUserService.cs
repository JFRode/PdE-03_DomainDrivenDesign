using CustomerHub.Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerHub.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> Get(CancellationToken cancellationToken);

        Task<UserDto> GetByEmailAndPassword(string email, string password, CancellationToken cancellationToken);

        Task<UserDto> Add(UserDto userDto, CancellationToken cancellationToken);

        Task<UserDto> Update(UserDto userDto, CancellationToken cancellationToken);

        Task<UserDto> Remove(Guid userId, CancellationToken cancellationToken);
    }
}