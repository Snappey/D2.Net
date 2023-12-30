
using System;
using System.Collections.Generic;
using D2.Enums;

namespace D2
{
    public class Markdown : Shape
    {
        private static string GeneratedKey => $"markdown-{Guid.NewGuid()}";
        private static string PrefixLabel(string label) => $"|md{Environment.NewLine}{label}|";
        
        public Markdown(string label) : base(GeneratedKey, PrefixLabel(label)) {}
        public Markdown(string key, string label) : base(key, PrefixLabel(label)) {}
        public Markdown(string label, ShapeType? type = null) : base(GeneratedKey, PrefixLabel(label), type) {}
        public Markdown(string key, string label, ShapeType? type = null, IEnumerable<Shape>? children = null) 
            : base(key, PrefixLabel(label), type, children) {}
    }
}