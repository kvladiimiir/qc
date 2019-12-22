using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace lab6.Tests
{
    [TestClass]
    public class ApiTestsProducts
    {
        [TestMethod]
        public void GetProductsTest_AssertProduct()
        {
            Requests requests = new Requests();
            ProductsForTests productsForTests = new ProductsForTests();

            Product newProduct = requests.GetProductById(32);

            AssertAllCategoriesInProduct(newProduct, productsForTests.productForGetProducts);
        }

        [TestMethod]
        public void CreateProductsTest_AssertProduct()
        {
            Requests requests = new Requests();
            ProductsForTests productsForTests = new ProductsForTests();

            //requests.CreateProduct(productsForTests.productForCreate);
            Product getNewProduct = requests.GetProductById(1835);

            AssertAllCategoriesInProduct(getNewProduct, productsForTests.productForCreate);
        }

        [TestMethod]
        public void UpdateProductsTest_AssertProduct()
        {
            Requests requests = new Requests();
            ProductsForTests productsForTests = new ProductsForTests();

            requests.UpdateProduct(productsForTests.productForUpdate);
            Product getNewProduct = requests.GetProductById(1836);

            AssertAllCategoriesInProduct(getNewProduct, productsForTests.productForUpdate);
        }

        [TestMethod]
        public void DeleteProductsTest_AssertProduct()
        {
            Requests requests = new Requests();
            ProductsForTests productsForTests = new ProductsForTests();

            requests.DeleteProduct(1837);

            Assert.ThrowsException<Exception>(() => requests.GetProductById(1837));
        }

        public void AssertAllCategoriesInProduct(Product firstProduct, Product secondProduct)
        {
            Assert.AreEqual(firstProduct.category_id, secondProduct.category_id);
            Assert.AreEqual(firstProduct.title, secondProduct.title);
            Assert.AreEqual(firstProduct.alias, secondProduct.alias);
            Assert.AreEqual(firstProduct.content, secondProduct.content);
            Assert.AreEqual(firstProduct.price, secondProduct.price);
            Assert.AreEqual(firstProduct.old_price, secondProduct.old_price);
            Assert.AreEqual(firstProduct.status, secondProduct.status);
            Assert.AreEqual(firstProduct.keywords, secondProduct.keywords);
            Assert.AreEqual(firstProduct.description, secondProduct.description);
            Assert.AreEqual(firstProduct.hit, secondProduct.hit);
        }
    }
}
