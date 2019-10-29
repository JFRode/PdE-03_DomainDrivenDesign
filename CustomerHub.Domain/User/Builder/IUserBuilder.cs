namespace CustomerHub.Domain.User.Builder
{
    public interface IUserBuilder
    {
        void SetName(string name);

        void SetEmail(string email);

        void SetPassword(string password);

        User GetUser();
    }
}