namespace ZBank.Pages.PageModels
{
    public class TransactionDisplayModel
    {
        public string TransactionId { get; set; }
        public string Amount { get; set; }
        public string ToPayee { get; set; }
        public string ToPayeePhone { get; set; }
        public string BankAccountNo { get; set; }
        public string Type { get; set; }
        public string BankName { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
}
