// <copyright file="IBookRepository.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Repository.Entities
{
    using Bookstore.Domain;
    using Bookstore.Repository.Core;

    /// <summary>
    /// Interface for IBookRepository.
    /// </summary>
    public interface IBookRepository : IRepository<Book>, IRepositoryAsync<Book>
    {
    }
}
