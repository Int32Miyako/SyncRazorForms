using System.Data;
using System.Reflection;
using Npgsql;
using SyncRazorForms.Controllers;
using SyncRazorForms.Models;
using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Data.Ado;

public class AdoConnectedAdoDataContext : IAdoDataContext
{
    private readonly DataSet _dataSet = new ();
    private readonly string _connectionString;

    public AdoConnectedAdoDataContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("RenderDB");
        InitializeDataSet();
    }

    private DataTable? Products => _dataSet.Tables["Products"];
    private DataTable? Customers => _dataSet.Tables["Customers"];
    private DataTable? Orders => _dataSet.Tables["Orders"];

    private void InitializeDataSet()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        // Load Products table
        var productsAdapter = new NpgsqlDataAdapter("SELECT * FROM \"Products\"", connection);
        productsAdapter.Fill(_dataSet, "Products");

        // Add code for Customers and Orders tables as needed
    }

    public ProductModel? SelectProduct(int id)
    {
        var productRow = Products?.Select($"product_id = {id}").FirstOrDefault();
        if (productRow != null)
        {
            return new ProductModel
            {
                Id = (int)productRow["product_id"],
                Name = (string)productRow["name"],
                Description = (string)productRow["description"],
                Price = (int)productRow["cost"], 
                Amount = (int)productRow["amount"]
            };
        }

        return null;
    }

    public IList<ProductModel?> SelectProducts()
    {
        var products = new List<ProductModel>();
        if (Products != null)
        {
            foreach (DataRow row in Products.Rows)
            {
                products.Add(new ProductModel
                {
                    Id = (int)row["product_id"],
                    Name = (string)row["name"],
                    Description = (string)row["description"],
                    Price = (int)row["cost"],
                    Amount = (int)row["amount"]
                });
            }
        }

        return products;
    }
    public int InsertProduct(ProductModel productModel)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        // Запрос с RETURNING для получения сгенерированного product_id
        string query = "INSERT INTO \"Products\" (name, description, cost, amount) " +
                       "VALUES (@Name, @Description, @Cost, @Amount) " +
                       "RETURNING \"product_id\";";
    
        using var command = new NpgsqlCommand(query, connection);

        // Добавление параметров для запроса
        command.Parameters.AddWithValue("@Name", productModel.Name);
        command.Parameters.AddWithValue("@Description", productModel.Description);
        command.Parameters.AddWithValue("@Cost", productModel.Price);
        command.Parameters.AddWithValue("@Amount", productModel.Amount);

        // Получение сгенерированного идентификатора
        var generatedProductId = (int)command.ExecuteScalar();  // Получаем значение первого столбца первой строки результата

        // Обновление DataSet
        var newRow = Products?.NewRow();
        if (newRow != null)
        {
            newRow["product_id"] = generatedProductId;  // Используем сгенерированный product_id
            newRow["name"] = productModel.Name;
            newRow["description"] = productModel.Description;
            newRow["cost"] = productModel.Price;
            newRow["amount"] = productModel.Amount;
            Products?.Rows.Add(newRow);
        }

        // Возвращаем сгенерированный product_id
        return generatedProductId;
    }


    public int UpdateProduct(ProductModel newProductModel)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        var command = new NpgsqlCommand(
            "UPDATE \"Products\" " +
            "SET name = @Name, " +
            "description = @Description, " +
            "cost = @Cost, " +
            "amount = @Amount " +
            "WHERE product_id = @Id", connection);

        command.Parameters.AddWithValue("@Name", newProductModel.Name);
        command.Parameters.AddWithValue("@Description", newProductModel.Description);
        command.Parameters.AddWithValue("@Cost", newProductModel.Price);
        command.Parameters.AddWithValue("@Amount", newProductModel.Amount);
        command.Parameters.AddWithValue("@Id", newProductModel.Id);

        command.ExecuteNonQuery();

        // Update DataSet
        var productRow = Products?.Select($"product_id = {newProductModel.Id}").FirstOrDefault();
        if (productRow != null)
        {
            productRow["name"] = newProductModel.Name;
            productRow["description"] = newProductModel.Description;
            productRow["cost"] = newProductModel.Price;
            productRow["amount"] = newProductModel.Amount;
        }

        return newProductModel.Id;
    }

    public int DeleteProduct(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        var command = new NpgsqlCommand("DELETE FROM \"Products\" WHERE product_id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);

        var affectedRows = command.ExecuteNonQuery();

        // Update DataSet
        var productRow = Products?.Select($"product_id = {id}").FirstOrDefault();
        productRow?.Delete();

        return affectedRows;
    }

    // Placeholders for other methods, not implemented
    public CustomerModel? SelectCustomer(int id) => throw new NotImplementedException();
    public IList<CustomerModel?> SelectCustomers() => throw new NotImplementedException();
    public int InsertCustomer(CustomerModel customerModel) => throw new NotImplementedException();
    public int UpdateCustomer(CustomerModel customerModel) => throw new NotImplementedException();
    public int DeleteCustomer(int id) => throw new NotImplementedException();
    public OrderModel? SelectOrder(int id) => throw new NotImplementedException();
    public IList<OrderModel?> SelectOrders() => throw new NotImplementedException();
    public int InsertOrder(OrderModel orderModel) => throw new NotImplementedException();
    public int UpdateOrder(OrderModel newOrderModel) => throw new NotImplementedException();
    public int DeleteOrder(int id) => throw new NotImplementedException();
}
