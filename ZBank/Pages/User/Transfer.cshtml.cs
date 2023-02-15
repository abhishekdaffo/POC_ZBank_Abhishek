using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation;
using System.ComponentModel.DataAnnotations;
using ZBank.Pages.PageModels;

namespace ZBank.Pages.User
{
    [Authorize]
    public class TransferModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BankingService _bankingService;

        public TransferModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            BankingService bankingService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _bankingService = bankingService;
        }

        [BindProperty]
        public TransferDataModel Input { get; set; }
        public void OnGet()
        {
            SetAccountBalance();
        }

        public IActionResult OnPost()
        {
            SetAccountBalance();
            if (Input.AccountBalance < Input.Amount)
                ModelState.AddModelError("TransferAmount", "Cannot Transfer amount greater than your Account balance");
            if (Input.Amount == 0.00M)
                ModelState.AddModelError("TransferAmount", "Transfer Amount cannot be Zero");
            if (ModelState.IsValid && this.User != null)
            {
                var userId = _userManager.GetUserId(User);
                if (userId != null)
                {
                    var transaction = _bankingService.TransferAmount(new Guid(userId), Input.Amount, Input.ToBankName, Input.ToBankAccountNo, Input.PayeeName, Input.PayeePhone);
                    return RedirectToPage("TransferDetail", new { transactionId = transaction });
                }
            }
            return Page();
        }

        private void SetAccountBalance()
        {
            if (this.User != null)
            {
                var userId = _userManager.GetUserId(User);
                if (userId != null)
                {
                    if (Input == null)
                        Input = new TransferDataModel();
                    Input.AccountBalance = _bankingService.GetCustomerBalance(new Guid(userId));
                }
            }
        }
    }

}
