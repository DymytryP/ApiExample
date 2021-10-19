using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.Data.Models.Entities
{
    [Table("Orders")]
    public record Order
    {
        public decimal Amount { get; set; }

        public long BillingUserId { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; init; }

        public string OrderNumber { get; init; }
    }
}
