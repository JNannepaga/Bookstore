// <copyright file="IMongoRepository.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Repository.Mongo.Core
{
    using Bookstore.Repository.Core;

    /// <summary>
    /// Interface for IMongoRepository.
    /// </summary>
    /// <typeparam name="TDomain">TDomain.</typeparam>
    public interface IMongoRepository<TDomain>
        : IRepository<TDomain>, IRepositoryAsync<TDomain>
        where TDomain : class
    {
    }
}
