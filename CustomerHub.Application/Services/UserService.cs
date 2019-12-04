using AutoMapper;
using CustomerHub.Application.Dto;
using CustomerHub.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System;
using CustomerHub.Domain.User;

namespace CustomerHub.Application.Services
{
    public class UserService
    {
        private readonly CustomerHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(CustomerHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> Get()
        {
            return _mapper.Map<List<UserDto>>(_dbContext.Users.ToList());
        }

        public void Add(UserDto userDto)
        {
            _dbContext.Users.Add(_mapper.Map<User>(userDto));
            _dbContext.SaveChanges();
        }

        public void Update(UserDto userDto)
        {
            _dbContext.Users.Update(_mapper.Map<User>(userDto));
            _dbContext.SaveChanges();
        }

        public void Remove(Guid userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}