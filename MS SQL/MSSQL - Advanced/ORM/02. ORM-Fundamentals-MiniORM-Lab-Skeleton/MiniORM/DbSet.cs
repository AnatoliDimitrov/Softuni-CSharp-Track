﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
    public class DbSet<TEntity> : ICollection<TEntity> where TEntity : class, new()
    {
        internal DbSet(IEnumerable<TEntity> entities)
        {
            Entities = entities.ToList();
            ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        internal IList<TEntity> Entities { get; set; }

        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            Entities.Add(item);
            ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (Entities.Any())
            {
                var entity = Entities.First();
                Remove(entity);
            }
        }
        public bool Contains(TEntity item)
        {
            return Entities.Contains(item);
        }
        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            Entities
                .CopyTo(array,arrayIndex);
        }


        public IEnumerator<TEntity> GetEnumerator()
        {
            return Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null!");
            }

            var removedSuccessfully = Entities.Remove(item);

            if (removedSuccessfully)
            {
                ChangeTracker.Remove(item);
            }

            return removedSuccessfully;
        }

        public int Count => Entities.Count;

        public bool IsReadOnly => Entities.IsReadOnly;

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities.ToArray())
            {
                Remove(entity);
            }
        }
    }
}