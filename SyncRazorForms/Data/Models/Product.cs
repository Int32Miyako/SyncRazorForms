using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Models;

[Table("Products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("product_id")]
    public int Id { get; init; }

    [Column("name")]
    [MaxLength(16)]
    public string? Name { get; init; }

    [Column("description")]
    [MaxLength(100)]
    public string? Description { get; init; }

    [Column("cost")] 
    public double Cost { get; init; }

    [Column("amount")]
    public int Amount { get; init; }
    
}