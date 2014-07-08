using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstSolution.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using FirstSolution.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace FirstSolution.Tests
{
    [TestFixture]
    public class GenerateSchema_Fixture
    {

        //Первая строка тестового метода создает новый экземпляр класса конфигурации NHibernate. 
        //Этот класс служит для настройки NHibernate. На второй строке мы говорим NHibernate настроить себя. 
        //NHibernate будет брать информацию из вне для настройки так как в тестовом методе мы никакой информации не указали. 
        //Так NHibernate будет искать файл hibernate.cfg.xml в output директории. Это и есть чего мы хотели добиться когда создавали наш файл настроек.

        //На третьей строчке мы говорим NHibernate что можно найти mapping информацию в сборке, 
        //которая также содержит класс Product. На данный момент NHibernate сможет найти только один файл (Product.hbm.xml)  как встроенный ресурс.

        //Четвертая строка кода использует NHibernate класс-помощник SchemaExport  для того чтобы автоматически 
        //сгенерировать для нас схему в БД. SchemaExport создаст таблицу table в БД и каждый раз когда вы будете обращаться, 
        //она будет удалять таблицу и все её данные и заново пересоздавать всё.
        [Test]
        public void Can_generate_schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
    }

    [TestFixture]
    public class ProductRepository_Fixture
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        private readonly Product[] _products = new[]
                 {
                     new Product {Name = "Melon", Category = "Fruits"},
                     new Product {Name = "Pear", Category = "Fruits"},
                     new Product {Name = "Milk", Category = "Beverages"},
                     new Product {Name = "Coca Cola", Category = "Beverages"},
                     new Product {Name = "Pepsi Cola", Category = "Beverages"},
                 };

        
        private void CreateInitialData()
        {

            using (ISession session = _sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach (var product in _products)
                    session.Save(product);
                transaction.Commit();
            }
        }

        //На четвертой строке метода TestFixtureSetUp мы создали фабрику сессий (session factory).
        //Это очень тяжелый процесс с точки зрения производительности и он должен быть вызван всего лишь раз. 
        //Это причина по которой я добавил его в этот метод, потому что метод выполняется один раз за весь процесс тестирования.
        [TestFixtureSetUp]
        public void Setup_Fixture()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Product).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        //Для того чтобы сделать наши тесты независимыми от внешних факторов мы пересоздали схему нашей БД 
        //перед вызовом каждого тестового метода. Для этого мы добавим следующий код
        [SetUp]
        public void SetupContext()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            CreateInitialData();
        }

        [Test]
        public void Can_add_new_product()
        {
            var product = new Product { Name = "Apple", Category = "Fruits" };
            IProductRepository repository = new ProductRepository();
            repository.Add(product);

            // use session to try to load the product
            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                // Test that the product was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(product, fromDb);
                Assert.AreEqual(product.Name, fromDb.Name);
                Assert.AreEqual(product.Category, fromDb.Category);
            }
        }

        [Test]
        public void Can_update_existing_product()
        {
            var product = _products[0];
            product.Name = "Yellow Pear";
            IProductRepository repository = new ProductRepository();
            repository.Update(product);

            // use session to try to load the product
            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                Assert.AreEqual(product.Name, fromDb.Name);
            }
        }

        [Test]
        public void Can_remove_existing_product()
        {
            var product = _products[0];
            IProductRepository repository = new ProductRepository();
            repository.Remove(product);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                Assert.IsNull(fromDb);
            }
        }

        [Test]
        public void Can_get_existing_product_by_id()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetById(_products[1].Id);
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(_products[1], fromDb);
            Assert.AreEqual(_products[1].Name, fromDb.Name);
        }

        [Test]
        public void Can_get_existing_product_by_name()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetByName(_products[1].Name);

            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(_products[1], fromDb);
            Assert.AreEqual(_products[1].Id, fromDb.Id);
        }

        [Test]
        public void Can_get_existing_products_by_category()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetByCategory("Fruits");

            Assert.AreEqual(2, fromDb.Count);
            Assert.IsTrue(IsInCollection(_products[0], fromDb));
            Assert.IsTrue(IsInCollection(_products[1], fromDb));
        }

        private bool IsInCollection(Product product, ICollection<Product> fromDb)
        {
            foreach (var item in fromDb)
                if (product.Id == item.Id)
                    return true;
            return false;
        }
    }
}