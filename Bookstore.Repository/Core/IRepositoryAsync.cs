// <copyright file="IRepositoryAsync.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Repository.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Repository.
    /// </summary>
    /// <typeparam name="TDomain">TDomain.</typeparam>
    public interface IRepositoryAsync<TDomain>
        where TDomain : class
    {
        /// <summary>
        /// FindAsync.
        /// </summary>
        /// <returns></returns>
        Task<TDomain> FindAsync();

        /// <summary>
        /// FindAsync.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TDomain>> FindAsync(Expression<Func<TDomain, bool>> predicate);

        /// <summary>
        /// AddAsync.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task AddAsync(TDomain record);

        /// <summary>
        /// AddAsync.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        Task AddAsync(IEnumerable<TDomain> records);

        /// <summary>
        /// UpdateAsync.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task<TDomain> UpdateAsync(TDomain record);

        /// <summary>
        /// UpdateAsync.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        Task UpdateAsync(IEnumerable<TDomain> records);

        /// <summary>
        /// DeleteAsync.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// DeleteAsync.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task DeleteAsync(TDomain record);

        /// <summary>
        /// DeleteAsync.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<TDomain, bool>> predicate);

        /// <summary>
        /// DeleteAllAsync.
        /// </summary>
        /// <returns></returns>
        Task DeleteAllAsync();
    }
}
