// <copyright file="Book.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Domain
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Class for Book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the value of Id.
        /// </summary>
        [BsonId]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the value of Name.
        /// </summary>
        [BsonElement("bookName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of Price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the value of Genere.
        /// </summary>
        public string Genere { get; set; }
    }
}
