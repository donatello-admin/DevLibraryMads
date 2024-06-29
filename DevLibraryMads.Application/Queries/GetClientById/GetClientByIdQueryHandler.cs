using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDTO>
    {

        private readonly IClientRepository _clientRepository;

        public GetClientByIdQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientDTO> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            var clientDTOs = new ClientDTO(client.FullName, client.BirdthDate, client.Email);

            return clientDTOs;
        }
    }
}
