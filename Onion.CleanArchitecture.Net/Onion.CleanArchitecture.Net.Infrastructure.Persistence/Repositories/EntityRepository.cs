using EFCore.BulkExtensions;
using LinqToDB.DataProvider;
using Microsoft.EntityFrameworkCore;
using Onion.CleanArchitecture.Net.Application.Interfaces;
using Onion.CleanArchitecture.Net.Domain;
using Onion.CleanArchitecture.Net.Domain.Caching;
using Onion.CleanArchitecture.Net.Domain.Common;
using Onion.CleanArchitecture.Net.Domain.Events;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Contexts;
using Onion.CleanArchitecture.Net.Infrastructure.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Onion.CleanArchitecture.Net.Infrastructure.Persistence.Repositories
{
    public partial class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : AuditableBaseEntity
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;
        protected readonly IShortTermCacheManager _shortTermCacheManager;
        protected readonly IStaticCacheManager _staticCacheManager;
        protected readonly bool _usingDistributedCache = false;
        #endregion

        #region Ctor

        public EntityRepository(
            ApplicationDbContext dbContext,
            IShortTermCacheManager shortTermCacheManager,
            IStaticCacheManager staticCacheManager
            )
        {
            _dbContext = dbContext;
            _shortTermCacheManager = shortTermCacheManager;
            _staticCacheManager = staticCacheManager;
        }

        #endregion

        #region Utilities 

        /// <summary>
        /// Returns queryable source for specified mapping class for current connection,
        /// mapped to database table or view.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Queryable source</returns>
        public IQueryable<T> GetTable<T>() where T : AuditableBaseEntity
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Inserts record into table. Returns inserted entity with identity
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the inserted entity
        /// </returns>
        public async Task<TEntity> InsertEntityAsync<TEntity>(TEntity entity) where TEntity : AuditableBaseEntity
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Inserts record into table. Returns inserted entity with identity
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>Inserted entity</returns>
        public TEntity InsertEntity<TEntity>(TEntity entity) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Updates record in table, using values from entity parameter.
        /// Record to update identified by match on primary key value from obj value.
        /// </summary>
        /// <param name="entity">Entity with data to update</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates record in table, using values from entity parameter.
        /// Record to update identified by match on primary key value from obj value.
        /// </summary>
        /// <param name="entity">Entity with data to update</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        public void UpdateEntity<TEntity>(TEntity entity) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates records in table, using values from entity parameter.
        /// Records to update are identified by match on primary key value from obj value.
        /// </summary>
        /// <param name="entities">Entities with data to update</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task UpdateEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates records in table, using values from entity parameter.
        /// Records to update are identified by match on primary key value from obj value.
        /// </summary>
        /// <param name="entities">Entities with data to update</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        public void UpdateEntities<TEntity>(IEnumerable<TEntity> entities) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes record in table. Record to delete identified
        /// by match on primary key value from obj value.
        /// </summary>
        /// <param name="entity">Entity for delete operation</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteEntityAsync<TEntity>(TEntity entity) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes record in table. Record to delete identified
        /// by match on primary key value from obj value.
        /// </summary>
        /// <param name="entity">Entity for delete operation</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        public void DeleteEntity<TEntity>(TEntity entity) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Performs delete records in a table
        /// </summary>
        /// <param name="entities">Entities for delete operation</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task BulkDeleteEntitiesAsync<TEntity>(IList<TEntity> entities) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Performs delete records in a table
        /// </summary>
        /// <param name="entities">Entities for delete operation</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        public void BulkDeleteEntities<TEntity>(IList<TEntity> entities) where TEntity : AuditableBaseEntity
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Performs delete records in a table by a condition
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the number of deleted records
        /// </returns>
        public async Task<int> BulkDeleteEntitiesAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : AuditableBaseEntity
        {
            var entities = await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
            _dbContext.Set<TEntity>().RemoveRange(entities);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Performs delete records in a table by a condition
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>
        /// The number of deleted records
        /// </returns>
        public int BulkDeleteEntities<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : AuditableBaseEntity
        {
            var entities = _dbContext.Set<TEntity>().Where(predicate).ToList();
            _dbContext.Set<TEntity>().RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Performs bulk insert operation for entity collection.
        /// </summary>
        /// <param name="entities">Entities for insert operation</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task BulkInsertEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : AuditableBaseEntity
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await _dbContext.BulkInsertAsync(entities.ToList());
        }

        /// <summary>
        /// Performs bulk insert operation for entity collection.
        /// </summary>
        /// <param name="entities">Entities for insert operation</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        public void BulkInsertEntities<TEntity>(IEnumerable<TEntity> entities) where TEntity : AuditableBaseEntity
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            _dbContext.BulkInsert(entities.ToList());
        }

        /// <summary>
        /// Executes command asynchronously and returns number of affected records.
        /// </summary>
        /// <param name="sql">Command text</param>
        /// <param name="dataParameters">Command parameters</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the number of records affected by command execution.
        /// </returns>
        public async Task<int> ExecuteNonQueryAsync(string sql, params object[] dataParameters)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("SQL command text cannot be null or empty.", nameof(sql));

            // Use Database.ExecuteSqlRawAsync to execute the SQL query and return the affected row count
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, dataParameters);
        }

        /// <summary>
        /// Executes command using System.Data.CommandType.StoredProcedure command type and
        /// returns results as collection of values of specified type
        /// </summary>
        /// <typeparam name="T">Result record type</typeparam>
        /// <param name="procedureName">Procedure name</param>
        /// <param name="dataParameters">Command parameters</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the returns collection of query result records
        /// </returns>
        public async Task<IList<T>> QueryProcAsync<T>(string procedureName, params object[] dataParameters) where T : class
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentException("Procedure name cannot be null or empty.", nameof(procedureName));

            // Create the SQL command string for the stored procedure
            var sql = $"EXEC {procedureName}";

            // Add placeholders for parameters
            if (dataParameters.Length > 0)
            {
                var parameterPlaceholders = string.Join(", ", dataParameters.Select((p, index) => $"@p{index}"));
                sql = $"{sql} {parameterPlaceholders}";
            }

            // Execute the stored procedure and return the result as a list
            return await _dbContext.Set<T>().FromSqlRaw(sql, dataParameters).ToListAsync();
        }

        /// <summary>
        /// Executes SQL command and returns results as collection of values of specified type
        /// </summary>
        /// <typeparam name="T">Type of result items</typeparam>
        /// <param name="sql">SQL command text</param>
        /// <param name="dataParameters">Parameters to execute the SQL command</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the collection of values of specified type
        /// </returns>
        public async Task<IList<T>> QueryAsync<T>(string sql, params object[] dataParameters) where T : class
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("SQL command text cannot be null or empty.", nameof(sql));

            // Execute the SQL query using FromSqlRaw and return the result as a list
            return await _dbContext.Set<T>().FromSqlRaw(sql, dataParameters).ToListAsync();
        }

        /// <summary>
        /// Truncates database table
        /// </summary>
        /// <param name="resetIdentity">Performs reset identity column</param>
        /// <typeparam name="TEntity">Entity type</typeparam>
        public async Task TruncateAsync<TEntity>(bool resetIdentity = false) where TEntity : AuditableBaseEntity
        {
            var tableName = _dbContext.Model.FindEntityType(typeof(TEntity)).GetTableName();

            // SQL command to truncate the table
            var sql = resetIdentity ? $"TRUNCATE TABLE [{tableName}] RESTART IDENTITY" : $"TRUNCATE TABLE [{tableName}]";

            // Execute the SQL command
            await _dbContext.Database.ExecuteSqlRawAsync(sql);
        }

        /// <summary>
        /// Adds "deleted" filter to query which contains <see cref="ISoftDeletedEntity"/> entries, if its need
        /// </summary>
        /// <param name="query">Entity entries</param>
        /// <param name="includeDeleted">Whether to include deleted items</param>
        /// <returns>Entity entries</returns>
        protected virtual IQueryable<TEntity> AddDeletedFilter(IQueryable<TEntity> query, in bool includeDeleted)
        {
            if (includeDeleted)
                return query;

            if (typeof(TEntity).GetInterface(nameof(ISoftDeletedEntity)) == null)
                return query;

            return query.OfType<ISoftDeletedEntity>().Where(entry => !entry.Deleted).OfType<TEntity>();
        }

        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="getAllAsync">Function to select entries</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the entity entries
        /// </returns>
        protected virtual async Task<IList<TEntity>> GetEntitiesAsync(Func<Task<IList<TEntity>>> getAllAsync, Func<IStaticCacheManager, CacheKey> getCacheKey)
        {
            if (getCacheKey == null)
                return await getAllAsync();

            //caching
            var cacheKey = getCacheKey(_staticCacheManager)
                           ?? _staticCacheManager.PrepareKeyForDefaultCache(EntityCacheDefaults<TEntity>.AllCacheKey);
            return await _staticCacheManager.GetAsync(cacheKey, getAllAsync);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the entity entry
        /// </summary>
        /// <param name="id">Entity entry identifier</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref="Nop.Core.Domain.Common.ISoftDeletedEntity"/> entities)</param>
        /// <param name="useShortTermCache">Whether to use short term cache instead of static cache</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the entity entry
        /// </returns>
        public virtual async Task<TEntity> GetByIdAsync(int? id, Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true, bool useShortTermCache = false)
        {
            if (!id.HasValue || id == 0)
                return null;

            async Task<TEntity> getEntityAsync()
            {
                return await AddDeletedFilter(Table, includeDeleted).FirstOrDefaultAsync(entity => entity.Id == Convert.ToInt32(id));
            }

            if (getCacheKey == null)
                return await getEntityAsync();

            ICacheKeyService cacheKeyService = useShortTermCache ? _shortTermCacheManager : _staticCacheManager;

            //caching
            var cacheKey = getCacheKey(cacheKeyService)
                           ?? cacheKeyService.PrepareKeyForDefaultCache(EntityCacheDefaults<TEntity>.ByIdCacheKey, id);

            if (useShortTermCache)
                return await _shortTermCacheManager.GetAsync(getEntityAsync, cacheKey);

            return await _staticCacheManager.GetAsync(cacheKey, getEntityAsync);
        }

        /// <summary>
        /// Get the entity entry
        /// </summary>
        /// <param name="id">Entity entry identifier</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref="ISoftDeletedEntity"/> entities)</param>
        /// <returns>
        /// The entity entry
        /// </returns>
        public virtual TEntity GetById(int? id, Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true)
        {
            if (!id.HasValue || id == 0)
                return null;

            TEntity getEntity()
            {
                return AddDeletedFilter(Table, includeDeleted).FirstOrDefault(entity => entity.Id == Convert.ToInt32(id));
            }

            if (getCacheKey == null)
                return getEntity();

            //caching
            var cacheKey = getCacheKey(_staticCacheManager)
                           ?? _staticCacheManager.PrepareKeyForDefaultCache(EntityCacheDefaults<TEntity>.ByIdCacheKey, id);

            return _staticCacheManager.Get(cacheKey, getEntity);
        }

        /// <summary>
        /// Get entity entries by identifiers
        /// </summary>
        /// <param name="ids">Entity entry identifiers</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref="ISoftDeletedEntity"/> entities)</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the entity entries
        /// </returns>
        public virtual async Task<IList<TEntity>> GetByIdsAsync(IList<int> ids, Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true)
        {
            if (ids?.Any() != true)
                return new List<TEntity>();

            static IList<TEntity> sortByIdList(IList<int> listOfId, IDictionary<int, TEntity> entitiesById)
            {
                var sortedEntities = new List<TEntity>(listOfId.Count);

                foreach (var id in listOfId)
                    if (entitiesById.TryGetValue(id, out var entry))
                        sortedEntities.Add(entry);

                return sortedEntities;
            }

            async Task<IList<TEntity>> getByIdsAsync(IList<int> listOfId, bool sort = true)
            {
                var query = AddDeletedFilter(Table, includeDeleted)
                    .Where(entry => listOfId.Contains(entry.Id));

                return sort
                    ? sortByIdList(listOfId, await query.ToDictExtensionAsync(entry => entry.Id))
                    : await query.ToListAsync();
            }

            if (getCacheKey == null)
                return await getByIdsAsync(ids);

            //caching
            var cacheKey = getCacheKey(_staticCacheManager);
            if (cacheKey == null && _usingDistributedCache)
                cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(EntityCacheDefaults<TEntity>.ByIdsCacheKey, ids);
            if (cacheKey != null)
                return await _staticCacheManager.GetAsync(cacheKey, async () => await getByIdsAsync(ids));

            //if we are using an in-memory cache, we can optimize by caching each entity individually for maximum reusability.
            //with a distributed cache, the overhead would be too high.
            var cachedById = await ids
                .Distinct()
                .SelectAwait(async id => await _staticCacheManager.GetAsync(
                    _staticCacheManager.PrepareKeyForDefaultCache(EntityCacheDefaults<TEntity>.ByIdCacheKey, id),
                    default(TEntity)))
                .Where(entity => entity != default)
                .ToDictionaryAsync(entity => entity.Id, entity => entity);
            var missingIds = ids.Except(cachedById.Keys).ToList();
            var missingEntities = missingIds.Count > 0 ? await getByIdsAsync(missingIds, false) : new List<TEntity>();

            foreach (var entity in missingEntities)
            {
                await _staticCacheManager.SetAsync(_staticCacheManager.PrepareKeyForDefaultCache(EntityCacheDefaults<TEntity>.ByIdCacheKey, entity.Id), entity);
                cachedById[entity.Id] = entity;
            }

            return sortByIdList(ids, cachedById);
        }

        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="getCacheKey">Function to get a cache key; pass null to don't cache; return null from this function to use the default key</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref="Nop.Core.Domain.Common.ISoftDeletedEntity"/> entities)</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the entity entries
        /// </returns>
        public virtual async Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            Func<ICacheKeyService, CacheKey> getCacheKey = null, bool includeDeleted = true)
        {
            async Task<IList<TEntity>> getAllAsync()
            {
                var query = AddDeletedFilter(Table, includeDeleted);
                query = func != null ? func(query) : query;

                return await query.ToListAsync();
            }

            return await GetEntitiesAsync(getAllAsync, getCacheKey);
        }

        /// <summary>
        /// Get paged list of all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="getOnlyTotalCount">Whether to get only the total number of entries without actually loading data</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref="Nop.Core.Domain.Common.ISoftDeletedEntity"/> entities)</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the paged list of entity entries
        /// </returns>
        public virtual async Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false, bool includeDeleted = true)
        {
            var query = AddDeletedFilter(Table, includeDeleted);

            query = func != null ? func(query) : query;

            return await query.ToPagedListAsync(pageIndex, pageSize, getOnlyTotalCount);
        }

        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertAsync(TEntity entity, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await InsertEntityAsync(entity);

            //event notification
            //if (publishEvent)
            //    await _eventPublisher.EntityInsertedAsync(entity);
        }

        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Insert(TEntity entity, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entity);

            InsertEntity(entity);

            //event notification
            //if (publishEvent)
            //    _eventPublisher.EntityInserted(entity);
        }

        /// <summary>
        /// Insert entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertAsync(IList<TEntity> entities, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entities);

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await BulkInsertEntitiesAsync(entities);
            transaction.Complete();

            if (!publishEvent)
                return;

            //event notification
            //foreach (var entity in entities)
            //    await _eventPublisher.EntityInsertedAsync(entity);
        }

        /// <summary>
        /// Insert entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Insert(IList<TEntity> entities, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entities);

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            BulkInsertEntities(entities);
            transaction.Complete();

            if (!publishEvent)
                return;

            //event notification
            //foreach (var entity in entities)
            //    _eventPublisher.EntityInserted(entity);
        }

        /// <summary>
        /// Loads the original copy of the entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the copy of the passed entity
        /// </returns>
        public virtual async Task<TEntity> LoadOriginalCopyAsync(TEntity entity)
        {
            return await GetTable<TEntity>()
                .FirstOrDefaultAsync(e => e.Id == Convert.ToInt32(entity.Id));
        }

        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateAsync(TEntity entity, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await UpdateEntityAsync(entity);

            //event notification
            //if (publishEvent)
            //    await _eventPublisher.EntityUpdatedAsync(entity);
        }

        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Update(TEntity entity, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entity);

            UpdateEntity(entity);

            //event notification
            //if (publishEvent)
            //    _eventPublisher.EntityUpdated(entity);
        }

        /// <summary>
        /// Update entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateAsync(IList<TEntity> entities, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entities);

            if (!entities.Any())
                return;

            await UpdateEntitiesAsync(entities);

            //event notification
            if (!publishEvent)
                return;

            //foreach (var entity in entities)
            //    await _eventPublisher.EntityUpdatedAsync(entity);
        }

        /// <summary>
        /// Update entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Update(IList<TEntity> entities, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entities);

            if (!entities.Any())
                return;

            UpdateEntities(entities);

            //event notification
            if (!publishEvent)
                return;

            //foreach (var entity in entities)
            //    _eventPublisher.EntityUpdated(entity);
        }

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteAsync(TEntity entity, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entity);

            switch (entity)
            {
                case ISoftDeletedEntity softDeletedEntity:
                    softDeletedEntity.Deleted = true;
                    await UpdateEntityAsync(entity);
                    break;

                default:
                    await DeleteEntityAsync(entity);
                    break;
            }

            //event notification
            //if (publishEvent)
            //    await _eventPublisher.EntityDeletedAsync(entity);
        }

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Delete(TEntity entity, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entity);

            switch (entity)
            {
                case ISoftDeletedEntity softDeletedEntity:
                    softDeletedEntity.Deleted = true;
                    UpdateEntity(entity);
                    break;

                default:
                    DeleteEntity(entity);
                    break;
            }

            //event notification
            //if (publishEvent)
            //    _eventPublisher.EntityDeleted(entity);
        }

        /// <summary>
        /// Delete entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteAsync(IList<TEntity> entities, bool publishEvent = true)
        {
            ArgumentNullException.ThrowIfNull(entities);

            if (!entities.Any())
                return;

            await DeleteAsync(entities);

            //event notification
            if (!publishEvent)
                return;

            //foreach (var entity in entities)
            //    await _eventPublisher.EntityDeletedAsync(entity);
        }

        /// <summary>
        /// Delete entity entries by the passed predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the number of deleted records
        /// </returns>
        public virtual async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var countDeletedRecords = await BulkDeleteEntitiesAsync(predicate);
            transaction.Complete();

            return countDeletedRecords;
        }

        /// <summary>
        /// Delete entity entries by the passed predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// The number of deleted records
        /// </returns>
        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var countDeletedRecords = BulkDeleteEntities(predicate);
            transaction.Complete();

            return countDeletedRecords;
        }

        /// <summary>
        /// Truncates database table
        /// </summary>
        /// <param name="resetIdentity">Performs reset identity column</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task TruncateAsync(bool resetIdentity = false)
        {
            await TruncateAsync<TEntity>(resetIdentity);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => GetTable<TEntity>();

        #endregion
    }
}
