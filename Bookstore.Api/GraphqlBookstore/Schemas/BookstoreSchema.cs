// <copyright file=BookstoreSchema.cs company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.GraphqlBookstore.Schemas
{
    using System;
    using Bookstore.GraphqlBookstore.Queries;
    using GraphQL.Types;
    using GraphQL.Utilities;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Class for BookstoreSchema.
    /// <seealso cref="Schema"/>
    /// </summary>
    public class BookstoreSchema : Schema, ISchema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookstoreSchema"/> class.
        /// </summary>
        /// <param name="serviceProvider">serviceProvider.</param>
        public BookstoreSchema(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<BookstoreQuery>();
        }
    }
}
