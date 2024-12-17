using SyncRazorForms.Models;

namespace SyncRazorForms.Data.Ado
{
    public interface IAdoDataContext
    {
        public ProductModel? SelectProduct(int id);
        public IList<ProductModel?> SelectProducts();
        public int InsertProduct(ProductModel productModel);
        public int UpdateProduct(ProductModel newProductModel);
        public int DeleteProduct(int id);
    

        public CustomerModel? SelectCustomer(int id);
        public IList<CustomerModel?> SelectCustomers();
        public int InsertCustomer(CustomerModel customerModel);
        public int UpdateCustomer(CustomerModel customerModel);
        public int DeleteCustomer(int id);

    
        public OrderModel? SelectOrder(int id);
        public IList<OrderModel?> SelectOrders();
        public int InsertOrder(OrderModel orderModel);
        public int UpdateOrder(OrderModel newOrderModel);
        public int DeleteOrder(int id);
    }
    
}