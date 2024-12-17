using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SyncRazorForms.Data.Models.ProductTypes;
using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Models;

[Table("Products")]
public class ProductModel
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

    [Column("price")]
    public int Price { get; init; }

    [Column("amount")]
    public int Amount { get; init; }

    public virtual List<OrderModel>? Orders { get; set; } = new();
    
    
    [Column("product_type")]
    public virtual ProductType ProductType { get; protected set; }
}