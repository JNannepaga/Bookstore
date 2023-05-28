// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bookstore.Controllers
{
    using System;
    using Bookstore.Services.Core;
    using Bookstore.Services.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class for BooksController.
    /// <seealso cref="ControllerBase"/>
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// <see cref="BooksController"/>.
        /// </summary>
        /// <param name="booksService">booksService.</param>
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        /// <summary>
        /// AddBook.
        /// </summary>
        /// <param name="book">book.</param>
        /// <returns>Added Book.</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddBook(BookDto book)
        {
            try
            {
                return Ok(_booksService.AddBook(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// GetBooks.
        /// </summary>
        /// <returns>All Books.</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetBooks()
        {
            return Ok(_booksService.GetBooks());
        }
    }
}
