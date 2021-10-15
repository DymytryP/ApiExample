using Billing.Infrastructure.DisplayMessages.Models;
using Billing.Infrastructure.Models.Enums;

namespace Billing.Infrastructure.Contracts.Models
{
    public interface IRequestDataProcessingResult
    {
        public DisplayMessage DisplayMessage { get; set; }

        public OperationResult OperationResult { get; set; }
    }
}
