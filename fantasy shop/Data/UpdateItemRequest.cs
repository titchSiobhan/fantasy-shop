namespace fantasy_shop.Data
{
   
        public class UpdateItemRequest
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
        }
    
}
