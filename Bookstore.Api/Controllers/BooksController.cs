// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bookstore.Controllers
{
    using System;
    using Bookstore.Services.Core;
    using Bookstore.Services.Models;
    using DnsClient.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class for BooksController.
    /// <seealso cref="ControllerBase"/>
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService _booksService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// <see cref="BooksController"/>.
        /// </summary>
        /// <param name="booksService">booksService.</param>
        public BooksController(ILogger<BooksController> logger, IBooksService booksService)
        {
            _logger = logger;
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
                _logger.LogInformation("Trying to add the book");
                _booksService.AddBook(book);
                _logger.LogInformation("Book added successfully");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to add the book {0}", ex.Message);
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
            _logger.LogInformation("Trying to get the books");
            var books = _booksService.GetBooks();
            _logger.LogInformation("Fetched the books successfully");
            return Ok(books);
        }
    }
}
