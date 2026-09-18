namespace Cmf.CandidateTest.Data.Seeding;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
