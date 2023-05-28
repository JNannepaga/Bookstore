// <copyright file=BookstoreQueryDto.cs company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.GraphqlBookstore.Models
{
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Class for BookstoreQueryDto.
    /// </summary>
    public class BookstoreQueryDto
    {
        /// <summary>
        /// Gets or sets operationName.
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Gets or sets NamedQuery.
        /// </summary>
        public string NamedQuery { get; set; }

        /// <summary>
        /// Gets or sets Query.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets Variables.
        /// </summary>
        public JObject Variables { get; set; }
    }
}
