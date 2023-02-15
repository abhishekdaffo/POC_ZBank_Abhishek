using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation;
using ZBank.Pages.PageModels;

namespace ZBank.Pages.User
{
    [Authorize]
    public class TransferDetailModel : PageModel
    {
        private readonly BankingService _bankingService;

        public TransferDetailModel(BankingService bankingService)
        {
            _bankingService = bankingService;
        }
        [BindProperty]
        public TransactionDisplayModel Transaction { get; set; }

        public void OnGet(string transactionId)
        {
            var transactionInfo = _bankingService.GetTransactionInfo(transactionId);
            if(transactionInfo!=null)
            {
                Transaction = new TransactionDisplayModel()
                {
                    Amount = transactionInfo.Amount.ToString("0.00"),
                    BankAccountNo = transactionInfo.ToBankAccountNo,
                    BankName= transactionInfo.ToBankName,
                    ToPayee = transactionInfo.PayeeName,
                    ToPayeePhone = transactionInfo.PayeePhone,
                    TransactionId = transactionInfo.TransactionReference,
                    Type = transactionInfo.Amount > 0 ? "Debit" : "Credit",
                    Date = transactionInfo.CreatedOn.ToString("dd MMMM yyyy HH:mm:ss"),
                    Status = transactionInfo.Completed ? "Sucess" : "Failed"
                };
            }
        }
    }
}
