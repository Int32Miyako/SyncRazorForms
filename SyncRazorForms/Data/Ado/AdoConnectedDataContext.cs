using System.Data;
using Microsoft.AspNetCore.Connections;
using MySqlConnector;
using SyncRazorForms.Models;
using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Data.Ado;

public class AdoConnectedDataContext : IDataContext
{

    private readonly DataSet _dataSet = new DataSet();
    private readonly string _connectionString;

    public AdoConnectedDataContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    private DataTable? Products => _dataSet.Tables["Products"];
    private DataTable? Customers => _dataSet.Tables["Customers"];
    private DataTable? Orders => _dataSet.Tables["Orders"];




    public Product? SelectProduct(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var command = new MySqlCommand(
            "SELECT * FROM ProductShop_DB.Products" +
            " WHERE product_id = @id", connection);
        command.Parameters.AddWithValue("@id", id);


        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            return new Product
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Description = reader.GetString("Description"),
                Cost = reader.GetDouble("Cost"),
                Amount = reader.GetInt32("Amount")
            };
        }

        return null;
    }

    public List<Product> SelectProducts()
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();
        var command = new MySqlCommand(
            "SELECT * FROM ProductShop_DB.Products", connection);

        using var reader = command.ExecuteReader();
        var products = new List<Product>();
        while (reader.Read())
        {
            products.Add(new()
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Description = reader.GetString("Description"),
                Cost = reader.GetDouble("Cost"),
                Amount = reader.GetInt32("Amount")
            });
 
        }

        return products;
    }

    public int InsertProduct(Product product)
    {
        throw new NotImplementedException();
    }


    public int UpdateProduct(Product newProduct)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var command = new MySqlCommand(
            "UPDATE ProductShop_DB.Products " +
            "SET name = @Name, " +
            "description = @Description, " +
            "cost = @Cost, " +
            "amount = @Amount " +
            "WHERE product_id = @Id", connection);

        command.Parameters.AddWithValue("@Name", newProduct.Name);
        command.Parameters.AddWithValue("@Description", newProduct.Description);
        command.Parameters.AddWithValue("@Cost", newProduct.Cost);
        command.Parameters.AddWithValue("@Amount", newProduct.Amount);
        command.Parameters.AddWithValue("@Id", newProduct.Id);

        var productsAdapter = new MySqlDataAdapter();
        productsAdapter.UpdateCommand =
            new MySqlCommand(command.CommandText, connection);

        return newProduct.Id;
    }

    
    public int DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Customer? SelectCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Customer?> SelectCustomers()
    {
        throw new NotImplementedException();
    }

    public int InsertCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public int UpdateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public int DeleteCustomer(int id)
    {
        
        throw new NotImplementedException();
    }

    public Order? SelectOrder(int id)
    {
        throw new NotImplementedException();
    }

    public IList<Order?> SelectOrders()
    {
        throw new NotImplementedException();
    }

    public int InsertOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public int UpdateOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public int DeleteOrder(int id)
    {
        throw new NotImplementedException();
    }
}