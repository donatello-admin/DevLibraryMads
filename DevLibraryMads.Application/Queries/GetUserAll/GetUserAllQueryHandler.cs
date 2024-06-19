using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetUserAll
{
    public class GetUserAllQueryHandler : IRequestHandler<GetUserAllQuery, List<UserDTOs>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserAllQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDTOs>> Handle(GetUserAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var userViewModel = users
                .Select(u => new UserDTOs(u.UserName,u.Password,u.Role))
                .ToList();

            return userViewModel;
        }
    }
}
