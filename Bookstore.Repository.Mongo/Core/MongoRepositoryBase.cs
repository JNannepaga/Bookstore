// <copyright file="MongoRepositoryBase.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Repository.Mongo.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Bookstore.Repository.Mongo.Config;
    using MongoDB.Driver;

    /// <summary>
    /// Class MongoRepositoryBase.
    /// </summary>
    /// <typeparam name="TDomain">TDomain.</typeparam>
    public class MongoRepositoryBase<TDomain> : IMongoRepository<TDomain>
        where TDomain : class
    {
        private readonly BookStoreDbSettings _dbSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRepositoryBase{TDomain}"/> class.
        /// </summary>
        /// <param name="dbSettings"></param>
        public MongoRepositoryBase(BookStoreDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.ConnectionURI);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.DatabaseName);
            this.Collection = mongoDatabase.GetCollection<TDomain>(typeof(TDomain).Name);
        }

        /// <summary>
        /// Gets collection.
        /// </summary>
        protected IMongoCollection<TDomain> Collection { get; private set; }

        /// <inheritdoc/>
        public void Add(TDomain record)
        {
            Collection.InsertOne(record);
        }

        /// <inheritdoc/>
        public void Add(IEnumerable<TDomain> records)
        {
            Collection.InsertMany(records);
        }

        /// <inheritdoc/>
        public Task AddAsync(TDomain record)
        {
           return Collection.InsertOneAsync(record);
        }

        /// <inheritdoc/>
        public Task AddAsync(IEnumerable<TDomain> records)
        {
            return Collection.InsertManyAsync(records);
        }

        /// <inheritdoc/>
        public long Count()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Delete(TDomain record)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Delete(Expression<Func<TDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteAsync(TDomain record)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteAsync(Expression<Func<TDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public TDomain Find(Guid id)
        {
            return Collection.Find(FilterById(id)).SingleOrDefault();
        }

        /// <inheritdoc/>
        public IEnumerable<TDomain> Find(Expression<Func<TDomain, bool>> predicate)
        {
            var filter = Builders<TDomain>.Filter.Where(predicate);
            return Collection.Find(filter).ToList();
        }

        /// <inheritdoc/>
        public Task<TDomain> FindAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<TDomain>> FindAsync(Expression<Func<TDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public TDomain Update(TDomain record)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(IEnumerable<TDomain> records)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<TDomain> UpdateAsync(TDomain record)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task UpdateAsync(IEnumerable<TDomain> records)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FilterById.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static FilterDefinition<TDomain> FilterById(Guid id) =>
            Builders<TDomain>.Filter.Eq("Id", id);
    }
}
