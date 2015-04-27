using System;

namespace sidekick
{
    /// <summary>
    ///     Used for defining the primary key of an entity
    /// </summary>
    /// <typeparam name="TKey">The primary key data type (int, short etc)</typeparam>
    public interface IEntity<TKey> where TKey : IConvertible
    {
        /// <summary>
        ///     Primary key value for the entity
        /// </summary>
        TKey Id { get; }
    }
}
