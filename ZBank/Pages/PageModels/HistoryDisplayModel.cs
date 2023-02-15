namespace ZBank.Pages.PageModels
{
    public class HistoryDisplayModel
    {
        public string TransactionId { get; set; }
        public string Amount { get; set; }
        public string ToPayee { get; set; }
        public string BankAccountNo { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
}
