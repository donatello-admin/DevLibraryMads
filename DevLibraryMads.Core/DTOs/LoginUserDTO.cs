namespace DevLibraryMads.Core.DTOs
{
    public class LoginUserDTO
    {
        public LoginUserDTO(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }

        public string UserName { get; private set; }
        public string Token { get; private set; }
    }
}
