using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;

namespace GourmetShop.DataAccessTests
{
    // INTEGRATION TESTING
    [TestClass]
    public sealed class DataAccessTest
    {
        private string connectionString = "data source=localhost\\SQLEXPRESS01;initial catalog=GourmetShop;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

        [TestMethod]
        public void GetProducts()
        {
            ProductRepository pr = new ProductRepository(connectionString);

            IEnumerable<Product> products = pr.GetAll();

            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void GetSuppliers()
        {
            SupplierRepository sr = new SupplierRepository(connectionString);

            IEnumerable<Supplier> suppliers = sr.GetAll();

            Assert.IsTrue(suppliers.Any());
        }

        [TestMethod]
        public void GetProductById()
        {
            ProductRepository pr = new ProductRepository(connectionString);

            Product product = new Product()
            {
                Id = 1,
                ProductName = "Chai",
                SupplierId = 1,
                UnitPrice= 18.00m,
                Package="10 boxes x 20 bags",
                IsDiscontinued=false
            };

            Product retrieved = pr.GetById(product.Id);

            Assert.AreEqual(product, retrieved);
        }
        
        [TestMethod]
        public void GetSupplierById()
        {
            SupplierRepository sr = new SupplierRepository(connectionString);

            Supplier supplier = new Supplier()
            {
                Id = 31,
                CompanyName = "Tattoo Shop",
                ContactName = "Johnny Truant",
                ContactTitle = null,
                City = "New York",
                Country = "USA",
                Phone = "(02) 686-4892",
                Fax = "(02) 686-4792"
            };

            Supplier retrieved = sr.GetById(supplier.Id);

            // Null reference exception
            Assert.AreEqual(supplier, retrieved);
        }

        [TestMethod]
        public void AddSupplier()
        {
            SupplierRepository sr = new SupplierRepository(connectionString);

            Supplier supplier = new Supplier()
            {
                Id = -1,
                CompanyName = "Lysette's Antique Shop",
                ContactName= "Lysette Danielkovski",
                City="5 Dogwood Drive",
                Phone="351.456.7526"
            };

            // Assert whether both objects are equal
            sr.Add(supplier);

            IEnumerable<Supplier> suppliers = sr.GetAll();
            Supplier added = suppliers.FirstOrDefault(s =>
                s.CompanyName == supplier.CompanyName &&
                s.ContactName == supplier.ContactName &&
                s.City == supplier.City &&
                s.Phone == supplier.Phone
            );

            Assert.IsNotNull(added);

            Assert.AreEqual(supplier.CompanyName, added.CompanyName);
        }

        [TestMethod]
        public void AddProduct()
        {
            // Pass in the product to add
            // Get the product's ID as the return value
            // Get the product by name, check and see if it exists in the database
            ProductRepository pr = new ProductRepository(connectionString);

            Product product = new Product()
            {
                Id = -1,
                ProductName = "To Ashes and Blood",
                UnitPrice= (decimal?)85.74,
                Package="League of Legends: Arcane",
                IsDiscontinued=false,
                SupplierId=1
            };

            // Assert whether both objects are equal
            pr.Add(product);

            IEnumerable<Product> products = pr.GetAll();
            Product added = products.FirstOrDefault(p =>
                p.ProductName == product.ProductName &&
                p.UnitPrice == (decimal?)product.UnitPrice &&
                p.Package == product.Package &&
                p.IsDiscontinued == product.IsDiscontinued &&
                p.SupplierId == product.SupplierId
            );

            Assert.IsNotNull(added);

            Assert.AreEqual(product.ProductName, added.ProductName);
        }

        [TestMethod]
        public void UpdateProduct()
        {
            ProductRepository pr = new ProductRepository(connectionString);

            Product product = new Product()
            {
                Id = 83,
                ProductName = "The Whalestoe Letters",
                SupplierId = 20,
                UnitPrice = 19.78m,
                Package = "This maze we call life",
                IsDiscontinued = true
            };

            pr.Update(product);

            Product actual = pr.GetById(83);

            Assert.AreEqual(product, actual);
        }

        [TestMethod]
        public void UpdateSupplier()
        {
            SupplierRepository sr = new SupplierRepository(connectionString);

            Supplier supplier = new Supplier()
            {
                Id = 34,
                CompanyName = "Moonlight Daydream",
                ContactName = "Matthias Conqvist",
                ContactTitle = null,
                City = "Paris",
                Country = "Fance",
                Phone = null,
                Fax = null
            };

            sr.Update(supplier);

            Supplier actual = sr.GetById(34);
            Assert.AreEqual(supplier, actual);
        }

        [TestMethod]
        public void DeleteProduct()
        {
            // Get the row, returns nothing, assert is false
            ProductRepository pr = new ProductRepository(connectionString);
            pr.Delete(89);

            Product product = pr.GetById(89);

            // NOTE: The reason why this works is because in the database, it uses identity
            Assert.AreEqual(0, (int)product.GetType().GetProperty("Id").GetValue(product));
        }

        [TestMethod]
        public void DeleteSupplier()
        {
            // Get the row, returns nothing, assert is false
            SupplierRepository sr = new SupplierRepository(connectionString);
            sr.Delete(34);

            Supplier supplier = sr.GetById(34);

            // NOTE: The reason why this works is because in the database, it uses identity
            Assert.AreEqual(0, (int)supplier.GetType().GetProperty("Id").GetValue(supplier));
        }
    }
}
