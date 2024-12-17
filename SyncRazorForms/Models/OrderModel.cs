using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyncRazorForms.Models;

[Table("Orders")]
public sealed class OrderModel
{
    public List<ProductModel>? Products { get; set; } = new();
    
    [Key]
    [Column("order_id")]
    public int Id { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }
    public CustomerModel? Customer { get; set; }
    

    [Column("amount")]
    public int Amount { get; set; }
}