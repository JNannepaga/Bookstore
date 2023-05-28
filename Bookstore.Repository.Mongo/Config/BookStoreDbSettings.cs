// <copyright file="BookStoreDbSettings.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Repository.Mongo.Config
{
    using Bookstore.Repository.Config;

    /// <summary>
    /// BookStoreDbSettings.
    /// <seealso cref="IDbSettings"/>
    /// </summary>
    public class BookStoreDbSettings : IDbSettings
    {
        /// <summary>
        /// Gets ConfigName.
        /// </summary>
        public static string ConfigName => "BookstoreDbConnection";

        /// <summary>
        /// Gets or sets DatabaseName.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets ConnectionURI.
        /// </summary>
        public string ConnectionURI { get; set; }

        /// <inheritdoc/>
        public DatabaseType DatabaseType => DatabaseType.MONGO;
    }
}
