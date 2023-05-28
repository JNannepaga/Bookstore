// <copyright file=Book.cs company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.GraphqlBookstore.Types
{
    using Bookstore.Services.Models;
    using GraphQL.Types;

    /// <summary>
    /// Class for Book.
    /// </summary>
    public class Book : ObjectGraphType<BookDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
            Field(x => x.Id, nullable: true, type: typeof(GuidGraphType)).Description("Id");
            Field(x => x.Name).Description("Title of Book");
            Field(x => x.Price, type: typeof(DecimalGraphType)).Description("Cost/ Price");
            Field(x => x.Genere).Description("Genere of the Book");
        }
    }
}
