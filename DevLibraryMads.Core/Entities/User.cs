namespace DevLibraryMads.Core.Entities
{
    public class User : EntityBase
    {
        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public void Update(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

    }
}
