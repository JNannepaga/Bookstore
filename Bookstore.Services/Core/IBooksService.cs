// <copyright file="IBooksService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bookstore.Services.Core
{
    using System;
    using System.Collections.Generic;
    using Bookstore.Services.Models;

    /// <summary>
    /// Interface for BooksService.
    /// </summary>
    public interface IBooksService
    {
        /// <summary>
        /// Get GetBooks.
        /// </summary>
        /// <returns></returns>
        public IList<BookDto> GetBooks();

        /// <summary>
        /// GetBookById.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookDto GetBookById(Guid id);

        /// <summary>
        /// GetBookByName.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BookDto GetBookByName(string name);

        /// <summary>
        /// AddBook.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public BookDto AddBook(BookDto book);
    }
}
