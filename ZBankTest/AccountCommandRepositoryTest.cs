using Domain.Entities;
using Infrastructure.CQRS.Command;
using Infrastructure.CQRS.Queries;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.CQRS.DataAccess;

namespace ZBankTest
{
    /// <summary>
    /// Class to test AccountCommandRepository
    /// </summary>
    public class AccountCommandRepositoryTest
    {
        [Test]
        public void Insert_Account_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();

            AddCustomerData(customerId);

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountCommandRepository(context);

                var account = new Account
                {
                    Id = accountId,
                    AccountBalance = 5000,
                    AccountNumber = 123412341234,
                    IsLocked = false,
                    LastLoggedIn = DateTime.Now,
                    LastTransaction = DateTime.Now,
                    UserId = customerId
                };
                _aqr.Insert(account);
            }

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountQueriesRepository(context);
                var account = _aqr.GetById(accountId);
                Assert.That(accountId, Is.EqualTo(account.Id));
            }
        }

        [Test]
        public void Update_Account_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();

            AddCustomerData(customerId);

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountCommandRepository(context);               

                var account = new Account
                {
                    Id = accountId,
                    AccountBalance = 5000,
                    AccountNumber = 123412341234,
                    IsLocked = false,
                    LastLoggedIn = DateTime.Now,
                    LastTransaction = DateTime.Now,
                    UserId = customerId
                };
                context.Accounts.Add(account);
                context.SaveChanges();

                account.AccountBalance += 100;
                _aqr.Update(account);
            }

            using (var context = new ApplicationDbContext(options))
            {
                var _aqr = new AccountQueriesRepository(context);
                var account = _aqr.GetById(accountId);
                Assert.That(account.AccountBalance, Is.EqualTo(5100));
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
