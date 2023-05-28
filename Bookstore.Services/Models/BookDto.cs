// <copyright file="BookDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bookstore.Services.Models
{
    using System;

    /// <summary>
    /// Class for BookDto.
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Gets or sets get Id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets get Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets get Price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets get Genere.
        /// </summary>
        public string Genere { get; set; }
    }
}
