using Domain.Entities;
using Infrastructure.CQRS.Queries;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Resource;
using Infrastructure.CQRS.Command;
using Infrastructure.CQRS.DataAccess;

namespace ZBankTest
{
    /// <summary>
    /// Class to test CustomerCommandRepository
    /// </summary>
    public class CustomerCommandRepositoryTest
    {
        [Test]
        public void Insert_Customer_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;

            var customerId = Guid.NewGuid();
            using (var context = new ApplicationDbContext(options))
            {
                var _cqr = new CustomerCommandRepository(context);
                var customer = new Customer
                {
                    Id = customerId,
                    Email = "test@test.com",
                    FirstName = "testFname",
                    LastName = "testLname",
                    FriendlyId = "frId",
                    MemberSince = DateTime.Now,
                    PhoneNumber = "12341234"
                };
                _cqr.Insert(customer);
            }

            using (var context = new ApplicationDbContext(options))
            {
                var _cqr = new CustomerQueriesRepository(context);
                var customer = _cqr.GetById(customerId);
                Assert.That(customerId, Is.EqualTo(customer.Id));
            }
        }

        [Test]
        public void Update_Customer_Data()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ZBank")
            .Options;

            var customerId = Guid.NewGuid();
            using (var context = new ApplicationDbContext(options))
            {
                var _cqr = new CustomerCommandRepository(context);
                var customer = new Customer
                {
                    Id = customerId,
                    Email = "test@test.com",
                    FirstName = "testFname",
                    LastName = "testLname",
                    FriendlyId = "frId",
                    MemberSince = DateTime.Now,
                    PhoneNumber = "12341234"
                };
                context.Customers.Add(customer);
                context.SaveChanges();

                customer.FirstName= "UpdatedFName";
                _cqr.Update(customer);
            }

            using (var context = new ApplicationDbContext(options))
            {
                var _cqr = new CustomerQueriesRepository(context);
                var customer = _cqr.GetById(customerId);
                Assert.That(customer.FirstName, Is.EqualTo("UpdatedFName"));
            }
        }
    }
}
