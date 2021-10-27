using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
	internal class ChangeTracker<T> where T: class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            added = new List<T>();
            removed = new List<T>();

            allEntities = CloneEntities(entities);
        }

        private List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var propertiesToClone = typeof(T)
                .GetProperties()
                .Where(p => DbContext.AllowedSqlTypes.Contains(p.PropertyType))
                .ToArray();

            foreach (var e in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach (var p in propertiesToClone)
                {
                    var value = p.GetValue(e);

                    p.SetValue(clonedEntity, value);
                }

                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }

        public IReadOnlyCollection<T> AllEntities => allEntities;
        public IReadOnlyCollection<T> Added => added;
        public IReadOnlyCollection<T> Removed => removed;

        public void Add(T item)
        {
            added.Add(item);
        }

        public void Remove(T item)
        {
            removed.Add(item);
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> set)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T)
                .GetProperties()
                .Where(p => p.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var e in AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, e).ToArray();

                var entity = set.Entities
                    .Single(x => GetPrimaryKeyValues(primaryKeys, x).SequenceEqual(primaryKeyValues));

                var isModified = IsModified(e, entity);

                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private static bool IsModified(T proxy, T entity)
        {
            var monitored = typeof(T)
                .GetProperties()
                .Where(p => DbContext.AllowedSqlTypes.Contains(p.PropertyType));

            var modified = monitored
                .Where(p => !Equals(p.GetValue(entity), p.GetValue(proxy)))
                .ToArray();

            return modified.Any();
        }

        private IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(p => p.GetValue(entity));
        }
    }
}