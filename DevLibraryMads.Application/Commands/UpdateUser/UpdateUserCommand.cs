using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public UpdateUserCommand(int id,string username,string password,string role)
        {
            Id = id;
            UserName = username;
            Password = password;
            Role = role;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
