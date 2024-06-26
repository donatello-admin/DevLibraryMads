﻿using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetClientAll
{
    public class GetClientAllQueryHandler : IRequestHandler<GetClientAllQuery, List<ClientDTO>>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientAllQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientDTO>> Handle(GetClientAllQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAllAsync();

            var clientDTO = clients
                .Select(c => new ClientDTO(c.FullName, c.BirdthDate, c.Email))
                .ToList();

            return clientDTO;
        }
    }
}
