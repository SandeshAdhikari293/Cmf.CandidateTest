namespace Cmf.CandidateTest.Data.Seeding;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
