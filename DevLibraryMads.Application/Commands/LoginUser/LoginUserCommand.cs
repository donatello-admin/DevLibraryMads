using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
