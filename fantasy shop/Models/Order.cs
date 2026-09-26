namespace fantasy_shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
     public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

   
    

}
