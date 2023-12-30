using System;
using D2.Enums;

namespace D2.Extensions
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
                ShapeType.SequenceDiagram => "sequence_diagram",
                ShapeType.ClassDiagram => "class",
                ShapeType.SqlTable => "sql_table",
                ShapeType.Grid => "grid",
                ShapeType.Image => "image",
                _ => throw new ArgumentException("ShapeType does not have a CatalogName", nameof(type), null)
            };
        }
    }
}