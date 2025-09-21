namespace Jcvalera.Core.Common.Entities
{
    public class BuyProduct
    {
        public int IdBuyProduct { get; set; }
        
        public int IdBuy { get; set; }
        
        public int IdProduct { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }

    }
}
