namespace SyncRazorForms.Models;

public class ProductModel
{
    public int Id { get; set; } 
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Cost { get; set; }
    public int Amount { get; set; }
}