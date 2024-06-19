using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateClient
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClientCommand, int>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClienteCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            client.Update(request.FullName, request.BirdthDate, request.Email);

            await _clientRepository.UpdateAsync(client);
            await _clientRepository.SaveChangesAsync();

            return client.Id;
        }
    }
}
