﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System.Collections.Specialized;

//CategoryTest();

//ProductTest();

ProductManager productManager = new ProductManager(new EfProductDal());
var result = productManager.GetProductDetails();
if (result.Success == true)
{
    foreach (var product in result.Data)
    {
        Console.WriteLine(product.ProductName + "/" +product.CategoryName);
    }
}
else
{
    Console.WriteLine(result.Message);
}



static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    var products = from p in productManager.GetAll().Data
                   join h in categoryManager.GetAll()
                   on p.CategoryId equals h.CategoryId
                   select new ProductDTO
                   {
                       CategoryName = h.CategoryName,
                       ProductId = p.ProductId,
                       ProductName = p.ProductName
                   };

    foreach (var item in products)
    {
        Console.WriteLine("{0}---{1}", item.ProductName, item.CategoryName);
    }
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}

public class ProductDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
}

