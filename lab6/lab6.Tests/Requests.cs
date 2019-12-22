using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using RestSharp;

namespace lab6.Tests
{
    public class Requests
    {
        ProductsForTests productsForTests = new ProductsForTests();
        private RestClient client = new RestClient("http://52.136.215.164:9000/api/");

        public Product GetProductById(int idProduct)
        {
            RestRequest request = new RestRequest("products", Method.GET);
            IRestResponse<List<Product>> response = client.Execute<List<Product>>(request);

            string idProductString = idProduct.ToString();

            foreach (var product in response.Data)
            {
                if (idProductString == product.id)
                {
                    return product;
                }
            }

            throw new Exception("This product is not");
        }

        public void CreateProduct(Product product)
        {
            var request = new RestRequest("addproduct", Method.POST);
            request.AddJsonBody(product);
            client.Execute(request);
        }

        public void UpdateProduct(Product product)
        {
            var request = new RestRequest("editproduct", Method.POST);
            request.AddJsonBody(product);
            client.Execute(request);
        }

        public void DeleteProduct(int id)
        {
            var request = new RestRequest("deleteproduct?id=" + id, Method.DELETE);
            client.Execute(request);
        }
    }
}
