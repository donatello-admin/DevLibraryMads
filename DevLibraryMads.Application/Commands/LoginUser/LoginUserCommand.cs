using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserDTOs>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
