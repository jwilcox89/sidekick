﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Threading.Tasks;

namespace sidekick
{
    public class BaseRepository<TContext> : IDisposable where TContext : DbContext, new()
    {
        private TContext _context;

        /// <summary>
        ///     Reference to the specified database context.
        /// </summary>
        protected TContext DB { 
            get {
                return _context = _context ?? new TContext();
            }
        }

        /// <summary>
        ///     Generates a new instance of the specified database context.
        /// </summary>
        public BaseRepository() {
            _context = new TContext();
        }

        /// <summary>
        ///     Uses the instance of the database context provided.
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(TContext context) {
            _context = context;
        }

        /// <summary>
        ///     Returns an entity object based on the specified entity and primary key value.
        /// </summary>
        /// <typeparam name="TEntity">Entity object type to be returned</typeparam>
        /// <typeparam name="TKey">Primary key type (int, short etc)</typeparam>
        /// <param name="primaryKey">Primary key value</param>
        /// <returns></returns>
        public TEntity Get<TEntity,TKey>(TKey id) where TEntity : class where TKey : IConvertible {
            return DB.Set<TEntity>().Find((TKey)id);
        }

        /// <summary>
        ///     Asynchronously returns an entity object based on the specified entity and primary key value.
        /// </summary>
        /// <typeparam name="TEntity">Entity object type to be returned</typeparam>
        /// <typeparam name="TKey">Primary key type (int, short etc)</typeparam>
        /// <param name="primaryKey">Primary key value</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync<TEntity,TKey>(TKey id) where TEntity : class where TKey : IConvertible {
            return await Task.Run(() => Get<TEntity,TKey>(id));
        }

        /// <summary>
        ///     Returns all entity objects of the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity object type to be returned</typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class {
            return DB.Set<TEntity>();
        }

        /// <summary>
        ///     Asynchronously returns all entity objects of the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity object type to be returned</typeparam>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAllAsync<TEntity>() where TEntity : class {
            return await Task.Run(() => GetAll<TEntity>());
        }

        /// <summary>
        ///     Returns all entity objects of the specified entity that meet the requirements of the provided query.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity,bool>> query) where TEntity : class {
            return DB.Set<TEntity>().Where(query);
        }

        /// <summary>
        ///     Asynchronously returns all entity objects of the specified entity that meet the requirements of the provided query.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> FindByAsync<TEntity>(Expression<Func<TEntity,bool>> query) where TEntity : class {
            return await Task.Run(() => FindBy<TEntity>(query));
        }

        /// <summary>
        ///     Adds a single entity to the specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Add<TEntity>(TEntity entity) where TEntity : class {
            DB.Set<TEntity>().Add(entity);
        }

        /// <summary>
        ///     Adds a list of entities to teh specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class {
            DB.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        ///     Removes a single entity from the specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Remove<TEntity>(TEntity entity) where TEntity : class {
            DB.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        ///     Removes a list of entities from the specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="collection"></param>
        public void Remove<TEntity>(IEnumerable<TEntity> collection) where TEntity : class {
            DB.Set<TEntity>().RemoveRange(collection);
        }

        /// <summary>
        ///     Removes a single entity (found by primary key) from the specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="id"></param>
        public void Remove<TEntity,TKey>(TKey id) where TEntity : class where TKey : IConvertible {
            TEntity entity = Get<TEntity,TKey>(id);

            if (entity != null)
                Remove<TEntity>(entity);
        }

        /// <summary>
        ///     Updates a single entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update<TEntity>(TEntity entity) where TEntity : class {
            DB.Set<TEntity>().Attach(entity);
            DB.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        ///     Updates multiple entities
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : class {
            foreach (TEntity e in entities) {
                DB.Set<TEntity>().Attach(e);
                DB.Entry(e).State = EntityState.Modified;
            }

            return entities;
        }

        /// <summary>
        ///     Method will toggle the boolean type property name that is supplied.
        ///     *Note : Will only work if you provide a boolean property and the primary key of the table you wish to toggle.
        ///     Otherwise will need to write a custom method.
        /// </summary>
        /// <typeparam name="TEntity">Database table object</typeparam>
        /// <typeparam name="TKey">Primary key column type (int, short etc)</typeparam>
        /// <param name="property">Property you wish to toggle</param>
        /// <param name="primaryKey">Value of the primary key of the row you wish to toggle</param>
        /// <returns></returns>
        public bool ToggleProperty<TEntity,TKey>(TKey primaryKey, Expression<Func<TEntity,object>> property) where TEntity : class where TKey : IConvertible {
            return ToggleProperty<TEntity,TKey>(primaryKey, property.GetMemberInfo().Member.Name);
        }

        /// <summary>
        ///     Method will toggle the boolean type property name that is supplied.
        ///     *Note : Will only work if you provide a boolean property and the primary key of the table you wish to toggle.
        ///     Otherwise will need to write a custom method.
        /// </summary>
        /// <typeparam name="TEntity">Database table object</typeparam>
        /// <typeparam name="TKey">Primary key column type (int, short etc)</typeparam>
        /// <param name="property">Property you wish to toggle ("Active", "Locked" etc)</param>
        /// <param name="primaryKey">Value of the primary key of the row you wish to toggle</param>
        /// <returns>Returns the value that the property was toggled to.</returns>
        /// <returns></returns>
        public async Task<bool> TogglePropertyAsync<TEntity,TKey>(TKey primaryKey, Expression<Func<TEntity,object>> property) where TEntity : class where TKey : IConvertible {
            return await Task.Run(() => ToggleProperty<TEntity,TKey>(primaryKey, property.GetMemberInfo().Member.Name));
        }

        private bool ToggleProperty<TEntity,TKey>(TKey primaryKey, string propertyName) where TEntity : class where TKey : IConvertible {
            TEntity entity = Get<TEntity,TKey>(primaryKey);

            if (entity == null)
                throw new NullReferenceException("no record found");

            PropertyInfo currentProperty = entity.GetType().GetProperty(propertyName);

            if (currentProperty.PropertyType != (typeof(Boolean)))
                throw new ArgumentException("not a boolean type");

            object currentValue = currentProperty.GetValue(entity, null);
            bool newValue = Convert.ToBoolean(currentValue).Toggle();

            currentProperty.SetValue(entity, newValue);

            return newValue;
        }

        /// <summary>
        ///     Saves changes made
        /// </summary>
        /// <returns></returns>
        public int Save() {
            try {
                return DB.SaveChanges();
            } catch (Exception ex) {
                throw new RepositoryException("An error has occured when trying to save.", ex);
            }
        }

        /// <summary>
        ///     Asynchronously saves changes made
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync() {
            return await Task.Run(() => Save());
        }

        #region SQL Scripts

        /// <summary>
        ///     Execute a custom SQL script on the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ensureTransaction"></param>
        public void ExecuteSqlScript(string sql, bool ensureTransaction = true) {
            if (ensureTransaction) {
                DB.Database.ExecuteSqlCommand(sql);
            } else {
                DB.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
            }
        }

        /// <summary>
        ///     Execute a custom SQL script on the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ensureTransaction"></param>
        /// <returns></returns>
        public async Task ExecuteSqlScriptAsync(string sql, bool ensureTransaction = true) {
            await Task.Run(() => ExecuteSqlScript(sql, ensureTransaction));
        }

        #endregion

        #region Dispose

        public void Dispose() {
            DB.Dispose();
        }

        #endregion
    }
}