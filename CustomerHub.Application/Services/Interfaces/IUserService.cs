using CustomerHub.Application.Dto;
using System;
using System.Collections.Generic;

namespace CustomerHub.Application.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> Get();

        void Add(UserDto userDto);

        void Update(UserDto userDto);

        void Remove(Guid userId);
    }
}