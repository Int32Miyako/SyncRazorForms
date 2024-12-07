namespace SyncRazorForms.Models;

public class Product
{
    public long Id { get; set; } 
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Cost { get; set; }
    public long Amount { get; set; }
}