using DevLibraryMads.Core.Enums;

namespace DevLibraryMads.Core.DTOs
{
    public class OrderDTO
    {
        public OrderDTO(string numPedVda, string fullName, string birdthDate, string email, string title, string description, string author, DateTime createdAt, DateTime returnedAt, StatusOrderEnum statusOrdem,decimal? valueFined, StatusPaymentsEnum statusPaymentsEnum)
        {
            NumPedVda = numPedVda;
            StatusOrder = statusOrdem;
            ValueFined = valueFined;
            FullName = fullName;
            BirdthDate = birdthDate;
            Email = email;
            Title = title;
            Description = description;
            Author = author;
            CreatedAt = createdAt;
            ReturnedAt = returnedAt;
            StatusPayment = statusPaymentsEnum;
        }

        public string NumPedVda { get; set; }
        public StatusOrderEnum StatusOrder { get; set; }
        public decimal? ValueFined { get; set; }
        public string FullName { get; set; }
        public string BirdthDate { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ReturnedAt { get; set; }
        public StatusPaymentsEnum StatusPayment { get; set; }
    }
}
