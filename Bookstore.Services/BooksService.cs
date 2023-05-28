// <copyright file="BooksService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bookstore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Bookstore.Domain;
    using Bookstore.Repository.Entities;
    using Bookstore.Services.Core;
    using Bookstore.Services.Models;

    /// <summary>
    /// Class for BooksService.
    /// </summary>
    public class BooksService : IBooksService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksService"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="bookRepository"></param>
        public BooksService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        /// <inheritdoc/>
        public BookDto AddBook(BookDto book)
        {
            book.Id = Guid.NewGuid();
            var bookEntity = _mapper.Map<BookDto, Book>(book);
            _bookRepository.Add(bookEntity);
            return book;
        }

        /// <inheritdoc/>
        public BookDto GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public BookDto GetBookByName(string name)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IList<BookDto> GetBooks()
        {
            var books = _bookRepository.Find(_ => true).ToList();
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books).ToList<BookDto>();
        }
    }
}
