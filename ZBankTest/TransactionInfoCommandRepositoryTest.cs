using Domain.Entities;
using Infrastructure.CQRS.Command;
using Infrastructure.CQRS.Queries;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.CQRS.DataAccess;

namespace ZBankTest
{
    /// <summary>
    /// Class for testing TransactionInfoCommandRepository
    /// </summary>
    public class TransactionInfoCommandRepositoryTest
    {
        [Test]
        public void Insert_TransactionInfo_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var transactionInfoId = Guid.NewGuid();

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);

            using (var context = new ApplicationDbContext(options))
            {
                var _tqr = new TransactionInfoCommandRepository(context);

                var transactionInfo = new TransactionInfo
                {
                    Id = transactionInfoId,
                    AccountId = accountId,
                    Amount = 50,
                    Completed = true,
                    CreatedOn = DateTime.Now,
                    PayeeName = "test Payee Name",
                    PayeePhone = "1234567",
                    ToBankAccountNo = "123456789",
                    ToBankName = "Test Bank",
                    TransactionReference = "RFT12345"
                };
                _tqr.Insert(transactionInfo);
            }

            using (var context = new ApplicationDbContext(options))
            {
                var _tqr = new TransactionInfoQueriesRepository(context);
                var transactionInfo = _tqr.GetById(transactionInfoId);
                Assert.That(transactionInfo.Id, Is.EqualTo(transactionInfoId));
            }
        }


        [Test]
        public void Update_TransactionInfo_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;
            var customerId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var transactionInfoId = Guid.NewGuid();

            AddCustomerData(customerId);
            AddAcccountData(customerId, accountId);

            using (var context = new ApplicationDbContext(options))
            {
                var _tqr = new TransactionInfoCommandRepository(context);

                var transactionInfo = new TransactionInfo
                {
                    Id = transactionInfoId,
                    AccountId = accountId,
                    Amount = 50,
                    Completed = true,
                    CreatedOn = DateTime.Now,
                    PayeeName = "test Payee Name",
                    PayeePhone = "1234567",
                    ToBankAccountNo = "123456789",
                    ToBankName = "Test Bank",
                    TransactionReference = "RFT12345"
                };
                context.TransactionInfos.Add(transactionInfo);
                context.SaveChanges();

                transactionInfo.Completed = false;
                _tqr.Update(transactionInfo);
            }

            using (var context = new ApplicationDbContext(options))
            {
                var _tqr = new TransactionInfoQueriesRepository(context);
                var transactionInfo = _tqr.GetById(transactionInfoId);
                Assert.False(transactionInfo.Completed);
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

        private void AddTransactionInfoData(Guid accountId, Guid transactionInfoId, string transactionReference = "TRREF123456")
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.TransactionInfos.Add(new TransactionInfo
                {
                    Id = transactionInfoId,
                    AccountId = accountId,
                    Amount = 50,
                    Completed = true,
                    CreatedOn = DateTime.Now,
                    PayeeName = "test Payee Name",
                    PayeePhone = "1234567",
                    ToBankAccountNo = "123456789",
                    ToBankName = "Test Bank",
                    TransactionReference = transactionReference
                });
                context.SaveChanges();
            }
        }
    }
}
