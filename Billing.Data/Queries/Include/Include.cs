using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Billing.Data.Queries.Include
{
    /// <summary>
    /// <para>Represents the include lambda expression(s) for LINQ T-SQL query.</para>
    /// <para>
    /// Created for the purpose of implementing repository pattern, but without cluttering repository
    /// with different methods implementations for different data queries.
    /// </para>
    /// </summary>
    public sealed class Include<T>
    {
        private readonly List<Expression<Func<T, object>>> _includes;

        public Include()
        {
            _includes = new List<Expression<Func<T, object>>>();
        }

        /// <summary>
        /// Provides empty include.
        /// </summary>
        public static Include<T> Empty => new Include<T>();

        /// <summary>
        /// Creates include from provided expression.
        /// </summary>
        /// <param name="include">Include expression.</param>
        /// <returns>Include reference.</returns>
        public static Include<T> Create(Expression<Func<T, object>> include)
        {
            return Empty.Add(include);
        }

        /// <summary>
        /// Add additional include.
        /// </summary>
        /// <param name="include">Include expression.</param>
        /// <returns>Include reference.</returns>
        public Include<T> Add(Expression<Func<T, object>> include)
        {
            _includes.Add(include);

            return this;
        }

        /// <summary>
        /// Gets contained includes.
        /// </summary>
        /// <returns>Reference to all contained includes.</returns>
        public List<Expression<Func<T, object>>> GetIncludes()
        {
            return _includes;
        }
    }
}
