namespace lab6.Tests
{
    public class ProductsForTests
    {
        public Product productForGetProducts = new Product
        {
            category_id = "7",
            title = "Часы 19",
            alias = "chasy-19",
            content = null,
            price = "125",
            old_price = "0",
            status = "1",
            keywords = null,
            description = null,
            hit = "1"
        };

        public Product productForCreate = new Product
        {
            category_id = "4",
            title = "Casio MRP-700-1VladimirTest",
            alias = "casio-mrp-700-1vladimirtest-0",
            content = null,
            price = "200",
            old_price = "0",
            status = "1",
            keywords = null,
            description = null,
            hit = "1"
        };

        public Product productForUpdate = new Product
        {
            id = "1836",
            category_id = "5",
            title = "Casio MRP-700-1VladimirTestUpdate-0",
            alias = "casio-mrp-700-1vladimirtestupdate-0",
            content = null,
            price = "200",
            old_price = "0",
            status = "1",
            keywords = null,
            description = null,
            hit = "1"
        };
    }
}