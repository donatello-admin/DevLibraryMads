using DevLibraryMads.Core.Repositories;
using DevLibraryMads.Core.Services;
using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            user.Update(request.UserName, passwordHash, request.Role);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            return request.Id;
        }
    }
}
