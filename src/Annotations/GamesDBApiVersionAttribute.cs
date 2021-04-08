using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGamesDBApiWrapper.Annotations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GamesDBApiVersionAttribute: Attribute
    {
        public GamesDBApiVersionAttribute(double version)
        {
            this.Version = version;
        }

        public double Version { get; private set; }
    }
}
