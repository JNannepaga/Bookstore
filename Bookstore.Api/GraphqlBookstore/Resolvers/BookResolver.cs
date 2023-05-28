// <copyright file="BookResolver.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.GraphqlBookstore.Resolvers
{
    using Bookstore.Services;
    using Bookstore.Services.Core;

    /// <summary>
    /// Class for BookResolver.
    /// <seealso cref="IBookResolver"/>.
    /// </summary>
    public class BookResolver : IBookResolver
    {
        private readonly IBooksService _booksService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookResolver"/> class.
        /// </summary>
        /// <param name="booksService">BooksService.</param>
        public BookResolver(IBooksService booksService)
        {
            _booksService = booksService;
        }
    }
}
