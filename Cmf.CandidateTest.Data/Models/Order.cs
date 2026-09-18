using System.ComponentModel.DataAnnotations;

namespace Cmf.CandidateTest.Data.Models;

public class Order
{
    [Required]
    public required int Id { get; set; }
    
    [Required]
    public required DateTime OrderDate { get; set; }
    
    [Required]
    public required int UserId { get; set; }
}
