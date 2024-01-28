namespace HisabKitab.Models.Dairy
{
    public class VitaPayments
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public string Fat { get; set; }
        public string SNF { get; set; }

        public DateTime Date { get; set; }
        public string Payment { get; set; }
    }
}
