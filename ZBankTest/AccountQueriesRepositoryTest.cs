using Domain.Entities;
using Infrastructure.CQRS.Queries;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.CQRS.DataAccess;

namespace ZBankTest
{
    /// <summary>
    /// Class to test AccountQueriesRepository
    /// </summary>
    public class AccountQueriesRepositoryTest
    {
        [Test]
        public void GetAll_Accounts_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountQueriesRepository(context);
                var accounts = _aqr.GetAll();

                Assert.IsTrue(accounts.Any());
            }
        }

        [Test]
        public void GetById_Accounts_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountQueriesRepository(context);
                var account = _aqr.GetById(accountId);
                Assert.That(account.Id, Is.EqualTo(accountId));
            }
        }

        [Test]
        public void GetAccountBalance_Accounts_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountQueriesRepository(context);
                var accountBalance = _aqr.GetAccountBalance(customerId);
                Assert.That(accountBalance, Is.EqualTo(5000.00M));
            }
        }

        [Test]
        public void GetByUserId_Accounts_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountQueriesRepository(context);
                var account = _aqr.GetByUserId(customerId);
                Assert.That(account.Id, Is.EqualTo(accountId));
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


        private void AddAcccountData(Guid customerId, Guid accountId)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Accounts.Add(new Account
                {
                    Id = accountId,
                    AccountBalance = 5000,
                    AccountNumber = 123412341234,
                    IsLocked = false,
                    LastLoggedIn = DateTime.Now,
                    LastTransaction = DateTime.Now,
                    UserId = customerId
                });
                context.SaveChanges();
            }
        }
    }
}
