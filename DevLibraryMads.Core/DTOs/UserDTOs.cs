namespace DevLibraryMads.Core.DTOs
{
    public class UserDTOs
    {
        public UserDTOs(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
