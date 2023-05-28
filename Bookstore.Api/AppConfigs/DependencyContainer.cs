// <copyright file="DependencyContainer.cs" company="MalipsTech">
// Copyright (c) {MalipsTech}. All rights reserved.
// </copyright>

namespace Bookstore.AppConfigs
{
    using AutoMapper;
    using Bookstore.GraphqlBookstore.Queries;
    using Bookstore.GraphqlBookstore.Resolvers;
    using Bookstore.GraphqlBookstore.Schemas;
    using Bookstore.GraphqlBookstore.Types;
    using Bookstore.Repository.Entities;
    using Bookstore.Repository.Mongo.Config;
    using Bookstore.Repository.Mongo.Entities;
    using Bookstore.Services;
    using Bookstore.Services.Core;
    using Bookstore.Services.Mappers;
    using GraphQL;
    using GraphQL.Types;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Class for DependencyContainer.
    /// </summary>
    public static class DependencyContainer
    {
        /// <summary>
        /// InitializeConfig.
        /// </summary>
        /// <param name="services">services.</param>
        /// <param name="configuration">configuration.</param>
        public static void InitializeConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.AddProfile(new BookProfile()));

            services.AddSingleton(typeof(IMapper), new Mapper(config));

            // services.Configure<FinInfraDbSettings>(configuration.GetSection(AppConstants.FIN_INFRA_DATABASE));
        }

        /// <summary>
        /// InitializeGraphQlServices.
        /// </summary>
        /// <param name="services">services.</param>
        /// <param name="configuration">configuration.</param>
        public static void InitializeGraphQlServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Book>();
            services.AddSingleton<BookstoreQuery>();
            services.AddSingleton<ISchema, BookstoreSchema>();

            services.AddSingleton<IBookResolver, BookResolver>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
        }

        /// <summary>
        /// InitializeServices.
        /// </summary>
        /// <param name="services">services.</param>
        /// <param name="configuration">configuration.</param>
        public static void InitializeServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBooksService, BooksService>();
        }

        /// <summary>
        /// InitializeRepositories.
        /// </summary>
        /// <param name="services">services.</param>
        /// <param name="configuration">configuration.</param>
        public static void InitializeRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Book>();
            services.AddTransient<IBookRepository, BookRepository>(); 
            services.Configure<BookStoreDbSettings>(configuration.GetSection(BookStoreDbSettings.ConfigName));
        }
    }
}
