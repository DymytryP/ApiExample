using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IDataDistributor<T>
    {
        Task PushAsync(T data);
    }
}
