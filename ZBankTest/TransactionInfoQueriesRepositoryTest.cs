using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.CQRS.DataAccess;

namespace ZBankTest
{
    /// <summary>
    /// Class for testing TransactionInfoQueriesRepository
    /// </summary>
    public class TransactionInfoQueriesRepositoryTest
    {
        [Test]
        public void GetAll_TransactionInfo_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var transactionInfoId = Guid.NewGuid();

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);
            AddTransactionInfoData(accountId, transactionInfoId);

            using (var context = new ApplicationDbContext(options))
            {
                var _tqr = new TransactionInfoQueriesRepository(context);
                var transactionInfo = _tqr.GetAll();
                Assert.IsTrue(transactionInfo.Any());
            }
        }

        [Test]
        public void GetById_TransactionInfo_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var transactionInfoId = Guid.NewGuid();

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);
            AddTransactionInfoData(accountId, transactionInfoId);

            using (var context = new ApplicationDbContext(options))
            {
                var _tqr = new TransactionInfoQueriesRepository(context);
                var transactionInfo = _tqr.GetById(transactionInfoId);
                Assert.That(transactionInfo.Id, Is.EqualTo(transactionInfoId));
            }
        }

        [Test]
        public void GetByReferenceId_TransactionInfo_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var transactionInfoId = Guid.NewGuid();
            var transactionReference = "TRREF12345609";

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);
            AddTransactionInfoData(accountId, transactionInfoId, transactionReference);

            using (var context = new ApplicationDbContext(options))
            {
                var _tqr = new TransactionInfoQueriesRepository(context);
                var transactionInfo = _tqr.GetByReferenceId(transactionReference);
                Assert.That(transactionInfo.Id, Is.EqualTo(transactionInfoId));
            }
        }

        [Test]
        public void GetAllForAccount_TransactionInfo_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var transactionInfoId = Guid.NewGuid();

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);
            AddTransactionInfoData(accountId, transactionInfoId);

            using (var context = new ApplicationDbContext(options))
            {
                var _tqr = new TransactionInfoQueriesRepository(context);
                var transactionInfo = _tqr.GetAllForAccount(accountId);
                Assert.IsTrue(transactionInfo.Any());
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

        private void AddTransactionInfoData(Guid accountId, Guid transactionInfoId, string transactionReference= "TRREF123456")
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.TransactionInfos.Add(new TransactionInfo
                {
                    Id= transactionInfoId,
                    AccountId= accountId,
                    Amount = 50,
                    Completed = true,
                    CreatedOn= DateTime.Now,
                    PayeeName="test Payee Name",
                    PayeePhone="1234567",
                    ToBankAccountNo="123456789",
                    ToBankName="Test Bank",
                    TransactionReference= transactionReference
                });
                context.SaveChanges();
            }
        }
    }
}
