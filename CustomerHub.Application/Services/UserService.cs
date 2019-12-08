using AutoMapper;
using CustomerHub.Application.Dto;
using CustomerHub.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System;
using CustomerHub.Domain.User;
using CustomerHub.Application.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CustomerHub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly CustomerHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(CustomerHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Get(CancellationToken cancellationToken)
        {
            var data = await _dbContext.Users.ToListAsync(cancellationToken);
            return _mapper.Map<List<UserDto>>(data);
        }

        public async Task<UserDto> Add(UserDto userDto, CancellationToken cancellationToken)
        {
            _dbContext.Users.Add(_mapper.Map<User>(userDto));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return userDto;
        }

        public async Task<UserDto> Update(UserDto userDto, CancellationToken cancellationToken)
        {
            _dbContext.Users.Update(_mapper.Map<User>(userDto));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return userDto;
        }

        public async Task<UserDto> Remove(Guid userId, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserDto>(user);
        }
    }
}