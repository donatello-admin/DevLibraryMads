using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetUserByUserName
{
    public class GetUserByUserNameQuery : IRequest<bool>
    {
        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; private set; }
    }
}
