// <copyright file="BookRepository.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Repository.Mongo.Entities
{
    using Bookstore.Domain;
    using Bookstore.Repository.Entities;
    using Bookstore.Repository.Mongo.Config;
    using Bookstore.Repository.Mongo.Core;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Class for BookRepository.
    /// </summary>
    public class BookRepository : MongoRepositoryBase<Book>, IBookRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="dbSettings">dbSettings.</param>
        public BookRepository(IOptions<BookStoreDbSettings> dbSettings)
            : base(dbSettings.Value)
        {
        }
    }
}
