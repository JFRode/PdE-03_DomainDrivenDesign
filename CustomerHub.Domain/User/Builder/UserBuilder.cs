namespace CustomerHub.Domain.User.Builder
{
    public class UserBuilder : IUserBuilder
    {
        private User _user = new User();

        public User GetUser()
        {
            return _user;
        }

        public void SetEmail(string email)
        {
            _user.Email = email;
        }

        public void SetName(string name)
        {
            _user.Name = name;
        }

        public void SetPassword(string password)
        {
            _user.Password = password;
        }
    }
}