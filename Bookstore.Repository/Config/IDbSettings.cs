// <copyright file="IDbSettings.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Repository.Config
{
    /// <summary>
    /// Interface for DbSettings.
    /// </summary>
    public interface IDbSettings
    {
        /// <summary>
        /// Gets the value of ConfigName.
        /// </summary>
        static string ConfigName { get; }

        /// <summary>
        /// Gets the value of DatabaseType.
        /// </summary>
        DatabaseType DatabaseType { get; }

        /// <summary>
        /// Gets or sets the value of ConnectionURI.
        /// </summary>
        string ConnectionURI { get; set; }

        /// <summary>
        /// Gets or sets the value of DatabaseName.
        /// </summary>
        string DatabaseName { get; set; }
    }
}