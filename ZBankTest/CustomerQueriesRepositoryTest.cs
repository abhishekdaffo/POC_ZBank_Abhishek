using Infrastructure;
using Infrastructure.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.CQRS.DataAccess;

namespace ZBankTest
{

    /// <summary>
    /// Class to test CustomerQueriesRepository
    /// </summary>
    public class CustomerQueriesRepositoryTest
    {   
        [Test]
        public void GetAll_Customer_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            AddCustomerData(Guid.NewGuid());

            using (var context = new ApplicationDbContext(options))
            {
                var _cqr = new CustomerQueriesRepository(context);
                var customers = _cqr.GetAll();

                Assert.IsTrue(customers.Any());
            }
        }

        [Test]
        public void GetById_Customer_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();

            AddCustomerData(customerId);

            using (var context = new ApplicationDbContext(options))
            {
                var _cqr = new CustomerQueriesRepository(context);
                var customer = _cqr.GetById(customerId);
                Assert.That(customerId, Is.EqualTo(customer.Id));
            }
        }

        [Test]
        public void GetCustomersCreatedToday_Customer_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            AddCustomerData(customerId);

            using (var context = new ApplicationDbContext(options))
            {
                var _cqr = new CustomerQueriesRepository(context);
                var customerCount = _cqr.GetCustomersCreatedToday();
                Assert.Positive(customerCount);
            }
        }

        private void AddCustomerData(Guid customerId)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Customers.Add(new Customer
                {
                    Id = customerId,
                    Email = "test@test.com",
                    FirstName = "testFname",
                    LastName = "testLname",
                    FriendlyId = "frId",
                    MemberSince = DateTime.Now,
                    PhoneNumber = "12341234"
                });
                context.SaveChanges();
            }
        }
    }
}
