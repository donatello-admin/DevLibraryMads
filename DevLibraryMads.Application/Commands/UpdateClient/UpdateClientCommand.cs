using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<int>
    {
        public UpdateClientCommand(int id,string fullname,string birdthdate,string email)
        {
            Id = id;
            FullName = fullname;
            BirdthDate = birdthdate;
            Email = email;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string BirdthDate { get; set; }
        public string Email { get; set; }
    }
}
