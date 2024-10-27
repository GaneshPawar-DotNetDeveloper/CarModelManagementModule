using System;
using System.ComponentModel.DataAnnotations;

namespace CarModels.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        [MaxLength(50)]
        public string ModelName { get; set; }

        [Required]
        [MaxLength(10)]
        public string ModelCode { get; set; }

        public string Description { get; set; }
        public string Features { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfManufacturing { get; set; }

        public bool Active { get; set; }
        public int SortOrder { get; set; }

        public byte[] ModelImage { get; set; }
    }
}
