﻿using System.Data;
using Npgsql;
using SyncRazorForms.Controllers;
using SyncRazorForms.Models;
using SyncRazorForms.Models.ProductTypes;

namespace SyncRazorForms.Data.Ado;

public class AdoConnectedDataContext : IDataContext
{
    private readonly DataSet _dataSet = new ();
    private readonly string _connectionString;

    public AdoConnectedDataContext(string connectionString)
    {
        _connectionString = connectionString;
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

    public Product? SelectProduct(int id)
    {
        var productRow = Products?.Select($"product_id = {id}").FirstOrDefault();
        if (productRow != null)
        {
            return new Product
            {
                Id = (int)productRow["product_id"],
                Name = (string)productRow["name"],
                Description = (string)productRow["description"],
                Cost = (double)productRow["cost"], // Ensure proper casting
                Amount = (int)productRow["amount"]
            };
        }

        return null;
    }

    public IList<Product?> SelectProducts()
    {
        var products = new List<Product>();
        if (Products != null)
        {
            foreach (DataRow row in Products.Rows)
            {
                products.Add(new Product
                {
                    Id = (int)row["product_id"],
                    Name = (string)row["name"],
                    Description = (string)row["description"],
                    Cost = (double)row["cost"], // Ensure proper casting
                    Amount = (int)row["amount"]
                });
            }
        }

        return products;
    }
    public int InsertProduct(Product product)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        // Запрос с RETURNING для получения сгенерированного product_id
        string query = "INSERT INTO \"Products\" (name, description, cost, amount) " +
                       "VALUES (@Name, @Description, @Cost, @Amount) " +
                       "RETURNING \"product_id\";";
    
        using var command = new NpgsqlCommand(query, connection);

        // Добавление параметров для запроса
        command.Parameters.AddWithValue("@Name", product.Name);
        command.Parameters.AddWithValue("@Description", product.Description);
        command.Parameters.AddWithValue("@Cost", product.Cost);
        command.Parameters.AddWithValue("@Amount", product.Amount);

        // Получение сгенерированного идентификатора
        var generatedProductId = (int)command.ExecuteScalar();  // Получаем значение первого столбца первой строки результата

        // Обновление DataSet
        var newRow = Products?.NewRow();
        if (newRow != null)
        {
            newRow["product_id"] = generatedProductId;  // Используем сгенерированный product_id
            newRow["name"] = product.Name;
            newRow["description"] = product.Description;
            newRow["cost"] = product.Cost;
            newRow["amount"] = product.Amount;
            Products?.Rows.Add(newRow);
        }

        // Возвращаем сгенерированный product_id
        return generatedProductId;
    }


    public int UpdateProduct(Product newProduct)
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

        command.Parameters.AddWithValue("@Name", newProduct.Name);
        command.Parameters.AddWithValue("@Description", newProduct.Description);
        command.Parameters.AddWithValue("@Cost", newProduct.Cost);
        command.Parameters.AddWithValue("@Amount", newProduct.Amount);
        command.Parameters.AddWithValue("@Id", newProduct.Id);

        command.ExecuteNonQuery();

        // Update DataSet
        var productRow = Products?.Select($"product_id = {newProduct.Id}").FirstOrDefault();
        if (productRow != null)
        {
            productRow["name"] = newProduct.Name;
            productRow["description"] = newProduct.Description;
            productRow["cost"] = newProduct.Cost;
            productRow["amount"] = newProduct.Amount;
        }

        return newProduct.Id;
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
    public Customer? SelectCustomer(int id) => throw new NotImplementedException();
    public IList<Customer?> SelectCustomers() => throw new NotImplementedException();
    public int InsertCustomer(Customer customer) => throw new NotImplementedException();
    public int UpdateCustomer(Customer customer) => throw new NotImplementedException();
    public int DeleteCustomer(int id) => throw new NotImplementedException();
    public Order? SelectOrder(int id) => throw new NotImplementedException();
    public IList<Order?> SelectOrders() => throw new NotImplementedException();
    public int InsertOrder(Order order) => throw new NotImplementedException();
    public int UpdateOrder(Order order) => throw new NotImplementedException();
    public int DeleteOrder(int id) => throw new NotImplementedException();
}
