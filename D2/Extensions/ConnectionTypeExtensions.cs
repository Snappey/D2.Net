using System;
using D2.Enums;

namespace D2.Extensions
{
    public static class ConnectionTypeExtensions
    {
        public static string CatalogName(this ConnectionType type)
        {
            return type switch
            {
                ConnectionType.Line => "--",
                ConnectionType.To => "<-",
                ConnectionType.From => "->",
                ConnectionType.Bidirectional => "<->",
                _ => throw new ArgumentException("ConnectionType does not have a catalog format", nameof(type), null)
            };
        }
    }
}