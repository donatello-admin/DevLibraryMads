using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientDTO>
    {
        public GetClientByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
