namespace CarModelManagement.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int SalesmanId { get; set; }
        public string Brand { get; set; }
        public string Class { get; set; }
        public int NumberOfCarsSold { get; set; }
    }
}
