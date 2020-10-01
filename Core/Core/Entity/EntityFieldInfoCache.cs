using System;
using System.Collections;
using System.Collections.Generic;

namespace ePower.Core.Entity
{
    public class EntityFieldInfoCache<EntityType> where EntityType : BaseEntity
    {
        private static readonly object rootSync = new object();
        private static readonly IDictionary<string, IList<EntityFieldInfo>> cache = new Dictionary<string, IList<EntityFieldInfo>>();
        /// <summary>
        /// Returns a list of a entity to list mapping information.
        /// </summary>
        /// <returns></returns>
        public static IList<EntityFieldInfo> GetEntityFieldInfos()
        {
            string name = typeof(EntityType).FullName;
            if (! cache.ContainsKey(name))
            {
                lock (rootSync)
                {
                    cache[name] = EntityReflector<EntityType>.GetFieldInfo();
                }
            }
            return cache[name];
        }
    }
}
