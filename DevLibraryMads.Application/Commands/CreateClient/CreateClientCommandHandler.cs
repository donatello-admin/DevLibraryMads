using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand,int>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.FullName, request.BirdthDate, request.Email);

            await _clientRepository.AddAsync(client);
            await _clientRepository.SaveChangesAsync();

            return client.Id;
        }
    }
}
