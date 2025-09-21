namespace Jcvalera.Core.Common.Entities
{
    public class Buy
    {
        public int IdBuy { get; set; }

        public int IdCustomers { get; set; }

        public int IdUser { get; set; }

        public DateTime DateBuy { get; set; }

        public decimal Total { get; set; }

    }
}
