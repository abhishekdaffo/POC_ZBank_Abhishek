using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ZBank.Pages.PageModels
{
    public class TransferDataModel
    {
            [Display(Name = "Amount to Transfer")]
            [DataType(DataType.Currency)]
            public decimal Amount { get; set; }

            [Required]
            [Display(Name = "Available Balance")]
            [DataType(DataType.Currency)]
            public decimal AccountBalance { get; set; }

            [Required]
            [Display(Name = "Enter Bank name of Payee")]
            public string ToBankName { get; set; }
            [Required]
            [Display(Name = "Enter Bank Account Number of Payee")]
            public string ToBankAccountNo { get; set; }
            [Required]
            [Display(Name = "Enter Payee Name")]
            public string PayeeName { get; set; }
            [Required]
            [Display(Name = "Enter Payee Phone")]
            [DataType(DataType.PhoneNumber)]
            public string PayeePhone { get; set; }
    }
}
