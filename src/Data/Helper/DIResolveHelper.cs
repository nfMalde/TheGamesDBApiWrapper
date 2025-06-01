using System;
using System.Collections.Generic;
using System.Reflection;
using TheGamesDBApiWrapper.Annotations;
using TheGamesDBApiWrapper.Domain.Helper;

namespace TheGamesDBApiWrapper.Data.Helper
{
    public class DIResolveHelper(IServiceProvider provider) : IDIResolveHelper
    {
        private readonly Dictionary<Type, PropertyInfo[]> _reflectionCache = new();
        public void EnrichViaDI(object? data)
        {
            if (data == null)
            {
                return;
            }

            var reflectType = data.GetType();

            // Cache reflection results
            if (!_reflectionCache.TryGetValue(reflectType, out var properties))
            {
                properties = reflectType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                _reflectionCache[reflectType] = properties;
            }

            foreach (var prop in properties)
            {
                if (prop.GetCustomAttribute<DIResolveAttribute>() != null)
                {
                    var service = provider.GetService(prop.PropertyType);
                    if (service != null)
                    {
                        prop.SetValue(data, service);
                    }
                }
                else if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var itemType = prop.PropertyType.GetGenericArguments()[0];
                    var collection = prop.GetValue(data) as System.Collections.IEnumerable;
                    if (collection != null)
                    {
                        foreach (var item in collection)
                        {
                            this.EnrichViaDI(item);
                        }
                    }
                }
                else if (prop.PropertyType.IsClass && prop.PropertyType.Namespace!.StartsWith("TheGamesDBApiWrapper.Models"))
                {
                    var item = prop.GetValue(data);
                    if (item != null)
                    {
                        this.EnrichViaDI(item);
                    }
                }
            }
        }
    }
}
