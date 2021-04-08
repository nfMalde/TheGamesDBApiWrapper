using System;
using System.Collections.Generic;
using System.Text;

namespace TheGamesDBApiWrapper.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DIResolve:Attribute
    {
    }
}
