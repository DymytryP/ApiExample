namespace Billing.Infrastructure.Contracts
{
    public interface IMapper<TInput, TOutput>
    {
        /// <summary>
        /// Maps input model to output model.
        /// </summary>
        /// <param name="input">Input model.</param>
        /// <returns>Output model.</returns>
        TOutput Map(TInput input);
    }
}
