// <copyright file="BookstoreQuery.cs" company="Malips-Tech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.GraphqlBookstore.Queries
{
    using Bookstore.GraphqlBookstore.Types;
    using Bookstore.Services;
    using Bookstore.Services.Core;
    using GraphQL.Types;

    /// <summary>
    /// Class for BookstoreQuery.
    /// </summary>
    public class BookstoreQuery : ObjectGraphType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookstoreQuery"/> class.
        /// </summary>
        /// <param name="booksService">booksService.</param>
        public BookstoreQuery(IBooksService booksService)
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<Book>>>>(
                "books",
                arguments: new QueryArguments(),
                resolve: context => booksService.GetBooks());
        }
    }
}
