using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using DevLibraryMads.Core.Services;
using MediatR;

namespace DevLibraryMads.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserDTOs>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<LoginUserDTOs> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Utlizar o mesmo algoritmo para criar o hash dessa semana
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //Buscar no meu banco um User que tenha meu e-mail e minha senha em formato hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.UserName, passwordHash);

            // se não existir, erro no login
            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user.UserName, user.Role);

            // se existir gero o token usando os dados do usuario
            return new LoginUserDTOs(user.UserName, token);
        }
    }
}
