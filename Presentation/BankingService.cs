using Application.Providers;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.CQRS.Command;
using Infrastructure.CQRS.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Presentation
{
    public delegate void UserCreated();

    /// <summary>
    /// Service for all banking methods
    /// </summary>
    public class BankingService
    {
        private readonly ILogger<BankingService> _logger;
        private readonly IEnumerable<IMessagePovider> _messageProviders;
        private readonly IPaymentProvider _paymentProvider;
        private readonly IMediator _mediator;

        public event UserCreated UserCreationComplete;
        public BankingService(
            ILogger<BankingService> logger, IPaymentProvider paymentProvider, IEnumerable<IMessagePovider> messageProviders,
            IMediator mediator)
        {
            _logger = logger;
            _paymentProvider = paymentProvider;
            _messageProviders = messageProviders;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates User Profile in our customer table and Account
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        public void CreateCutomerProfile(Guid userId, string email, string firstName, string lastName, string phoneNumber)
        {
            try
            {
                var numberOfCustomerRegisteredToday = _mediator.Send(new GetCustomersCreatedTodayQuery());
                var customer = new Customer()
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    MemberSince = DateTime.Now,
                    PhoneNumber = phoneNumber,
                    FriendlyId = $"C{DateTime.Now.ToString("MMddyyyy")}{numberOfCustomerRegisteredToday.Result}"
                };
                _mediator.Send(new CreateCutomerProfileCommand(customer));

                CreateCustomerAccount(customer);

                //Trigger Event
                UserCreationComplete?.Invoke();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gets the balance of customer
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetCustomerBalance(Guid userId)
        {
            try
            {
                var customer = _mediator.Send(new GetCustomerBalanceQuery(userId));
                return customer.Result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return 0;
            }
        }

        /// <summary>
        /// This method is used to transfer payment
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="toBankName"></param>
        /// <param name="toBankAccountNo"></param>
        /// <param name="payeeName"></param>
        /// <param name="payeePhone"></param>
        /// <returns></returns>
        /// <exception cref="PaymentFailedException"></exception>
        public string TransferAmount(Guid userId, decimal amount, string toBankName, string toBankAccountNo, string payeeName, string payeePhone)
        {
            try
            {
                var accountQ = _mediator.Send(new GetAccountByUserIdQuery(userId));
                if (accountQ != null && accountQ.Result!=null)
                {
                    var account = accountQ.Result;
                    if (_paymentProvider.ProcessPayment())
                    {
                        var transactionInfo = new TransactionInfo()
                        {
                            Id = Guid.NewGuid(),
                            Amount = amount,
                            AccountId = account.Id,
                            Completed = true,
                            CreatedOn = DateTime.Now,
                            PayeeName = payeeName,
                            PayeePhone = payeePhone,
                            ToBankAccountNo = toBankAccountNo,
                            ToBankName = toBankName,
                            TransactionReference = Guid.NewGuid().ToString().Substring(0, 18) // Dummy reference
                        };

                        _mediator.Send(new CreateTransactionInfoCommand(transactionInfo));

                        account.AccountBalance -= amount;

                        _mediator.Send(new UpdateAccountCommand(account));

                        foreach (var messageProvider in _messageProviders)
                        {
                            messageProvider.NotifyUserTransfer(userId, amount);
                        }
                        return transactionInfo.TransactionReference;
                    }
                    else
                        throw new PaymentFailedException();
                }
                return string.Empty;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return string.Empty;
            }
        }
        
        /// <summary>
        /// Gets list of all transactions of this user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<TransactionInfo> GetAllTransactionsOfUser(Guid userId)
        {
            try
            {
                var account = _mediator.Send(new GetAccountByUserIdQuery(userId));
                if (account != null && account.Result!=null)
                {
                    var transactionInfoList = _mediator.Send(new GetAllTransactionsOfUserQuery(account.Result.Id));
                    return transactionInfoList.Result.OrderByDescending(x => x.CreatedOn).ToList();
                }
                return null;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// Gets the transaction information based on transactionId
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public TransactionInfo GetTransactionInfo(string transactionId)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(transactionId))
                {
                    var transactionInfo = _mediator.Send(new GetTransactionInfoQuery(transactionId));
                    return transactionInfo.Result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// Creates Customer Account
        /// </summary>
        /// <param name="customer"></param>
        public void CreateCustomerAccount(Customer customer)
        {
            var account = new Account()
            {
                Id = Guid.NewGuid(),
                UserId = customer.Id,
                AccountBalance = 5000, //Setting this as default for this
                LastLoggedIn = DateTime.Now,
                AccountNumber = DateTime.Now.Ticks,
                IsLocked = false
            };
            _mediator.Send(new CreateCustomerAccountCommand(account));
        }
    }
}
