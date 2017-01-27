using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Threading.Tasks;

namespace sidekick
{
    /// <summary>
    ///     Generic repository designed to account for all generic query functionality
    /// </summary>
    /// <typeparam name="TContext">The database context you would like to query</typeparam>
    public class BaseRepo<TContext> : IDisposable
        where TContext : DbContext, new()
    {
        /// <summary>
        ///     Reference to the database context.
        /// </summary>
        protected TContext Context { get; set; }

        /// <summary>
        ///     Generates a new instance of the specified database context.
        /// </summary>
        public BaseRepo()
        {
            Context = new TContext();
        }

        /// <summary>
        ///     Uses the instance of the database context provided.
        /// </summary>
        /// <param name="context"></param>
        public BaseRepo(TContext context)
        {
            Context = context;
        }

        /// <summary>
        ///     Returns all entities
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> Get<TEntity>()
            where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        ///     Returns a single entity object based on primary key value
        /// </summary>
        /// <typeparam name="TEntity">Entity object type to be returned</typeparam>
        /// <param name="id">Primary key value</param>
        /// <returns></returns>
        public TEntity Get<TEntity>(params object[] id)
            where TEntity : class
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        ///     Returns all entities based on the query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query">Query to filter results</param>
        /// <returns></returns>
        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
        {
            return Context.Set<TEntity>().Where(query);
        }

        /// <summary>
        ///     Asynchronously returns all entities
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAsync<TEntity>()
            where TEntity : class
        {
            return await Task.Run(() => Get<TEntity>());
        }

        /// <summary>
        ///     Asynchronously returns a single entity object based on primary key value
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id">Primary key value</param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync<TEntity>(params object[] id)
            where TEntity : class
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        ///     Asynchronously returns all entities based on the query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query">Query to filter results</param>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> GetAsync<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
        {
            return await Task.Run(() => Get(query));
        }

        /// <summary>
        ///     Adds a single entity to the specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public BaseRepo<TContext> Add<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
            return this;
        }

        /// <summary>
        ///     Adds a list of entities to the specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public BaseRepo<TContext> Add<TEntity>(IEnumerable<TEntity> collection)
            where TEntity : class
        {
            Context.Set<TEntity>().AddRange(collection);
            return this;
        }

        /// <summary>
        ///     Removes a single entity from the specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public BaseRepo<TContext> Remove<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Set<TEntity>().Remove(entity);
            return this;
        }

        /// <summary>
        ///     Removes a list of entities from the specified set.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="collection"></param>
        public BaseRepo<TContext> Remove<TEntity>(IEnumerable<TEntity> collection)
            where TEntity : class
        {
            Context.Set<TEntity>().RemoveRange(collection);
            return this;
        }

        /// <summary>
        ///     Method will toggle the boolean type property name that is supplied.
        ///     *Note : Will only work if you provide a boolean property and the primary key of the table you wish to toggle.
        ///     Otherwise will need to write a custom method.
        /// </summary>
        /// <typeparam name="TEntity">Database table object</typeparam>
        /// <typeparam name="TKey">Primary key column type (int, short etc)</typeparam>
        /// <param name="property">Property you wish to toggle</param>
        /// <param name="id">Value of the primary key of the row you wish to toggle</param>
        /// <returns></returns>
        public bool ToggleProperty<TEntity>(Expression<Func<TEntity, object>> property, params object[] id)
            where TEntity : class
        {
            return ToggleProperty<TEntity>(property.GetMemberName(), id);
        }

        /// <summary>
        ///     Method will toggle the boolean type property name that is supplied.
        ///     *Note : Will only work if you provide a boolean property and the primary key of the table you wish to toggle.
        ///     Otherwise will need to write a custom method.
        /// </summary>
        /// <typeparam name="TEntity">Database table object</typeparam>
        /// <typeparam name="TKey">Primary key column type (int, short etc)</typeparam>
        /// <param name="property">Property you wish to toggle ("Active", "Locked" etc)</param>
        /// <param name="id">Value of the primary key of the row you wish to toggle</param>
        /// <returns>Returns the value that the property was toggled to.</returns>
        /// <returns></returns>
        public async Task<bool> TogglePropertyAsync<TEntity>(Expression<Func<TEntity, object>> property, params object[] id)
            where TEntity : class
        {
            return await Task.Run(() => ToggleProperty<TEntity>(property.GetMemberName(), id));
        }

        private bool ToggleProperty<TEntity>(string propertyName, params object[] id)
            where TEntity : class
        {
            TEntity entity = Get<TEntity>(id);
            if (entity == null)
                throw new NullReferenceException("No record found");

            PropertyInfo currentProperty = entity.GetProperty(propertyName);
            if (currentProperty.PropertyType != (typeof(Boolean)) && currentProperty.PropertyType != (typeof(Nullable<Boolean>)))
                throw new ArgumentException("Not a boolean or nullable boolean type");

            object currentValue = currentProperty.GetValue(entity, null);
            bool newValue = Convert.ToBoolean(currentValue).Toggle();

            currentProperty.SetValue(entity, newValue);

            return newValue;
        }

        /// <summary>
        ///     Saves changes made
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepoException(ex, Context.GetValidationErrors());
            }
        }

        /// <summary>
        ///     Asynchronously saves changes made
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
            return await Task.Run(() => Save());
        }

        /// <summary>
        ///     Execute a custom SQL script on the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public void ExecuteSql(string sql)
        {
            Context.Database.ExecuteSqlCommand(sql);
        }

        /// <summary>
        ///     Execute a custom SQL script on the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public void ExecuteSql(string sql, TransactionalBehavior behavior)
        {
            Context.Database.ExecuteSqlCommand(behavior, sql);
        }

        public void Dispose()
        {
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}