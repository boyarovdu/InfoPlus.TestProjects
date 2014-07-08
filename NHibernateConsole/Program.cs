using FirstSolution.Domain;
using FirstSolution.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole
{
    class Program
    {
        private static ISessionFactory _sessionFactory;
        private static NHibernate.Cfg.Configuration _configuration;

        static Program()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Product).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();

            new SchemaExport(_configuration).Execute(false, true, false);
            CreateInitialData();
        }

        private static void CreateInitialData()
        {
            Product[] products = new[]
                 {
                     new Product {Name = "Melon", Category = "Fruits"},
                     new Product {Name = "Pear", Category = "Fruits"},
                     new Product {Name = "Milk", Category = "Beverages"},
                     new Product {Name = "Coca Cola", Category = "Beverages"},
                     new Product {Name = "Pepsi Cola", Category = "Beverages"},
                 };

            using (ISession session = _sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach (var product in products)
                    session.Save(product);
                transaction.Commit();
            }
        }

        static void Main(string[] args)
        {
            var product = new Product { Name = "Apple", Category = "Fruits" };
            IProductRepository repository = new ProductRepository();
            repository.Add(product);

            // use session to try to load the product
            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                // Test that the product was successfully inserted
                Console.WriteLine(fromDb.Name);
            }

        }
    }
}
