using System;

namespace D2
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