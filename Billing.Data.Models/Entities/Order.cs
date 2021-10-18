using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.Data.Models.Entities
{
    [Table("Orders")]
    public record Order
    { 
        public string Description { get; set; }

        [Key]
        public long Id { get; init; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
