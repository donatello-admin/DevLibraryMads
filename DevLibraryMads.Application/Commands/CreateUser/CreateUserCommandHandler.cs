using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using DevLibraryMads.Core.Services;
using MediatR;

namespace DevLibraryMads.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {      
         
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.UserName, passwordHash,request.Role);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user.Id;
        }
    }
}
