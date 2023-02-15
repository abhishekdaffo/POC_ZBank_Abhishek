using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation;

namespace ZBank.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BankingService _bankingService;

        public IndexModel(ILogger<IndexModel> logger, BankingService bankingService, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _bankingService = bankingService;
            _userManager = userManager;
        }

        [BindProperty]
        public decimal AccountBalance { get; set; }

        public void OnGet()
        {
            if (this.User != null)
            {
                var userId = _userManager.GetUserId(User);
                if(userId != null)
                {
                    AccountBalance = _bankingService.GetCustomerBalance(new Guid(userId));
                }                
            }
        }
    }
}