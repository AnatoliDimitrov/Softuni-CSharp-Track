using CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IRemovable
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string element)
        {
            this.collection.Insert(0, element);

            return 0;
        }

        public string Remove()
        {
            string element = this.collection[this.collection.Count - 1];

            this.collection.RemoveAt(this.collection.Count - 1);

            return element;
        }
    }
}
