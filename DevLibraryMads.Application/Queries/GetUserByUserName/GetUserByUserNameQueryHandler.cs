using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetUserByUserName
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var validUser = await _userRepository.GetByUserNameAsync(request.UserName);

            if (validUser.Equals(request.UserName))
                return true;
            else
                return false;

        }
    }
}
