using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
