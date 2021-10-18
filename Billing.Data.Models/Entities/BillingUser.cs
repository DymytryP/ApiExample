using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.Data.Models.Entities
{
    [Table("Users")]
    public record BillingUser
    {
        public string Code { get; init; }

        [Key]
        public long Id { get; init; }

        public string Name { get; init; }
    }
}
