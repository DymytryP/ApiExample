using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IDataTarget<T>
    {
        /// <summary>
        /// Receives data.
        /// </summary>
        /// <param name="data">Data to receive.</param>
        void Receive(T data);

        /// <summary>
        /// Receives data asynchronously.
        /// </summary>
        /// <param name="data">Data to receive.</param>
        Task ReceiveAsync(T data);
    }
}
