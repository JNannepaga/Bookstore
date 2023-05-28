// <copyright file="BookProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bookstore.Services.Mappers
{
    using AutoMapper;
    using Bookstore.Domain;
    using Bookstore.Services.Models;

    /// <summary>
    /// Class for BookProfile.
    /// </summary>
    public class BookProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookProfile"/> class.
        /// </summary>
        public BookProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
