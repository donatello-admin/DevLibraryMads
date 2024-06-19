using MediatR;

namespace DevLibraryMads.Application.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string BirdthDate { get; set; }
        public string Email { get; set; }
    }
}
