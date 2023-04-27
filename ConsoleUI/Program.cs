using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System.Collections.Specialized;

ProductManager productManager = new ProductManager(new EfProductDal());
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

var products = from p in productManager.GetAll()
               join h in categoryManager.GetAll()
               on p.CategoryId equals h.CategoryId
               select new ProductDTO { CategoryName = h.CategoryName, ProductId = p.ProductId, ProductName = p.ProductName };

foreach (var item in products)
{
    Console.WriteLine("{0}---{1}",item.ProductName,item.CategoryName);
}
public class ProductDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
}

