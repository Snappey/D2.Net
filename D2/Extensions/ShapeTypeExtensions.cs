using System;

namespace D2
{
    public static class ShapeTypeExtensions
    {
        public static string CatalogName(this ShapeType type)
        {
            return type switch
            {
                ShapeType.Rectangle => "rectangle",
                ShapeType.Square => "square",
                ShapeType.Page => "page",
                ShapeType.Parallelogram => "parallelogram",
                ShapeType.Document => "document",
                ShapeType.Cylinder => "cylinder",
                ShapeType.Queue => "queue",
                ShapeType.Package => "package",
                ShapeType.Step => "step",
                ShapeType.Callout => "callout",
                ShapeType.StoredData => "stored_data",
                ShapeType.Person => "person",
                ShapeType.Diamond => "diamond",
                ShapeType.Oval => "oval",
                ShapeType.Circle => "circle",
                ShapeType.Hexagon => "hexagon",
                ShapeType.Cloud => "cloud",
                _ => throw new ArgumentException("ShapeType does not have a CatalogName", nameof(type), null)
            };
        }
    }
}