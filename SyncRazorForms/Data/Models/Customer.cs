using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyncRazorForms.Models;

[Table(("Customers"))]
public class Customer
{
    [Key]
    [Column("customer_id")]
    public int Id { get; set; }
    
    [Column("first_name")]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Column("second_name")]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Column("age")]
    public int Age { get; set; }

    [Column("country")]
    [MaxLength(100)]
    public string Country { get; set; }
}