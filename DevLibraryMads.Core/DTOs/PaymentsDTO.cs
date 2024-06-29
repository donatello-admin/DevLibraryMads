namespace DevLibraryMads.Core.DTOs
{
    public class PaymentsDTO
    {
        public PaymentsDTO(int idOrder, string cardNumber, string dtExpired, string fullName, decimal? account)
        {
            IdOrder = idOrder;
            CardNumber = cardNumber;
            DtExpired = dtExpired;
            FullName = fullName;
            Account = account;
        }

        public int IdOrder { get; set; }
        public string CardNumber { get; set; }
        public string DtExpired { get; set; }
        public string FullName { get; set; }
        public decimal? Account { get; set; }
    }
}
