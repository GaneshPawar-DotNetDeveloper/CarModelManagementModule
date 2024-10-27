namespace CarModelManagement.Models
{
    public class CommissionRate
    {
        public string Brand { get; set; }
        public decimal FixedCommission { get; set; }
        public string Class { get; set; }
        public decimal PercentageRate { get; set; }
    }
}
