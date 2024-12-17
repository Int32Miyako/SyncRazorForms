using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyncRazorForms.Models;


[Table("Orders")]
public class Order
{
    [Key]
    [Column("order_id")]
    public int Id { get; set; }
    
    [Column("customer_id")]
    public int CustomerId { get; set; }
    
    [Column("product_id")]
    public int ProductId { get; set; }
    
    [Column("amount")]
    public int Amount { get; set; }
}