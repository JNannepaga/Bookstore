// <copyright file="IRepository.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Repository.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Interface for Repository.
    /// </summary>
    /// <typeparam name="TDomain">TDomain.</typeparam>
    public interface IRepository<TDomain>
        where TDomain : class
    {
        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>TDomain.</returns>
        TDomain Find(Guid id);

        /// <summary>
        /// Find.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TDomain> Find(Expression<Func<TDomain, bool>> predicate);

        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="record"></param>
        void Add(TDomain record);

        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="records"></param>
        void Add(IEnumerable<TDomain> records);

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        TDomain Update(TDomain record);

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="records"></param>
        void Update(IEnumerable<TDomain> records);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="record"></param>
        void Delete(TDomain record);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<TDomain, bool>> predicate);

        /// <summary>
        /// DeleteAll.
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// Count of Records.
        /// </summary>
        /// <returns></returns>
        long Count();
    }
}
