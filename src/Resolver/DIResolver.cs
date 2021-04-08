using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TheGamesDBApiWrapper.Resolver
{
    /// <summary>
    /// Resolver for using DI in Models Constructor or Properties via [DIRESOLVE]
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    public class DIContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// The provider
        /// </summary>
        private readonly IServiceProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DIContractResolver"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public DIContractResolver(IServiceProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonObjectContract" /> for the given type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// A <see cref="T:Newtonsoft.Json.Serialization.JsonObjectContract" /> for the given type.
        /// </returns>
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract = base.CreateObjectContract(objectType);
            contract.DefaultCreator = () => this.ResolveFromDI(objectType);

            return contract; 
        }


        /// <summary>
        /// Resolves servies from di.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns></returns>
        private object ResolveFromDI(Type objectType)
        {
            object o = ActivatorUtilities.CreateInstance(this.provider, objectType);

            objectType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance)
            .Where(x => x.GetCustomAttribute<Annotations.DIResolve>() != null)
            .ToList()
            .ForEach(prop =>
            {
                prop.SetValue(o, this.provider.GetService(prop.PropertyType));
            });

            return o;
        }
    }
}
