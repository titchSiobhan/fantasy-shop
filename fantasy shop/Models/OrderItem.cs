namespace fantasy_shop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = new User();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
