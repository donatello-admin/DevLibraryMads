using DevLibraryMads.Core.Enums;

namespace DevLibraryMads.Core.Entities
{
    public class Order : EntityBase
    {
        public Order(string numPedVda, int id_Client, int id_Book,decimal? valueFined)
        {
            NumPedVda = numPedVda;
            StatusOrder = StatusOrderEnum.Borrowed;
            ValueFined = valueFined;
            Id_Client = id_Client;
            Id_Book = id_Book;
        }

        public string NumPedVda { get; private set; }
        public StatusOrderEnum StatusOrder { get; private set; }
        public decimal? ValueFined { get; set; }
        public int Id_Client { get; private set; }
        public Client Client { get; private set; }
        public int Id_Book { get; private set; }
        public Book Book { get; private set; }
        public DateTime ReturnedAt { get; set; }

        public decimal IsFined(DateTime createdAt, DateTime returnedAt)
        {
            TimeSpan diferencaDias = returnedAt - createdAt;
            int diasDeDiferenca = diferencaDias.Days;
            decimal valueFined = 0;

            if (diasDeDiferenca > 5)
            {
                var dayFine = Convert.ToDouble(diasDeDiferenca);
                dayFine *= 0.5;

                valueFined = Convert.ToDecimal(dayFine);

                return valueFined;
            }

            return valueFined;
        }
    }
}
