using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation;
using ZBank.Pages.PageModels;

namespace ZBank.Pages.User
{
    [Authorize]
    public class TransferHistoryModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BankingService _bankingService;

        public TransferHistoryModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            BankingService bankingService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _bankingService = bankingService;
        }

        [BindProperty]
        public List<HistoryDisplayModel> Transactions { get; set; }
        public void OnGet()
        {
            if (this.User != null)
            {
                var userId = _userManager.GetUserId(User);
                if (userId != null)
                {
                    var allTransactions = _bankingService.GetAllTransactionsOfUser(new Guid(userId));
                    Transactions = allTransactions.Select(x => new HistoryDisplayModel()
                    {
                        TransactionId = x.TransactionReference,
                        Amount = x.Amount.ToString("0.00"),
                        BankAccountNo = x.ToBankAccountNo,
                        Status = x.Completed ? "Sucess" : "Failed",
                        ToPayee = x.PayeeName,
                        Type = x.Amount>0 ? "Debit" : "Credit",
                        Date = x.CreatedOn.ToString("dd MMMM yyyy HH:mm:ss")
                    }).ToList();
                }
            }
        }
    }    
}
