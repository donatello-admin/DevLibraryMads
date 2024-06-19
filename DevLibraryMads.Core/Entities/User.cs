namespace DevLibraryMads.Core.Entities
{
    public class User : EntityBase
    {
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
