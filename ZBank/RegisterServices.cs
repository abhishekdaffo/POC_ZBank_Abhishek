using Application.Abstractions.CommandsInterface;
using Application.Abstractions.QueriesInterface;
using Domain.DbLoggerObjects;
using Presentation;
using Presentation.Providers;
using MediatR;
using Infrastructure.CQRS.DataAccess;
using Application.Providers;

namespace ZBank
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection builder)
        {
            
            builder.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            builder.AddScoped<IAccountCommandRepository, AccountCommandRepository>();
            builder.AddScoped<ITransactionInfoCommandRepository, TransactionInfoCommandRepository>();
            builder.AddScoped<ICustomerQueriesRepository, CustomerQueriesRepository>();
            builder.AddScoped<IAccountQueriesRepository, AccountQueriesRepository>();
            builder.AddScoped<ITransactionInfoQueriesRepository, TransactionInfoQueriesRepository>();
            builder.AddScoped<IPaymentProvider, PaypalProvider>();
            builder.AddScoped<IMessagePovider, SmsProvider>();
            builder.AddScoped<IMessagePovider, EmailProvider>();
            builder.AddScoped<BankingService>();

            return builder;
        }
    }
}
