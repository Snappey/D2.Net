using System;
using System.Collections.Generic;
using D2.Enums;

namespace D2
{
    public class LateX : Shape
    {
        private static string GeneratedKey => $"latex-{Guid.NewGuid()}";
        private static string PrefixLabel(string label) => $"|latex{Environment.NewLine}{label}|";
        
        public LateX(string label) : base(GeneratedKey, PrefixLabel(label)) {}
        public LateX(string key, string label) : base(key, PrefixLabel(label)) {}
        public LateX(string label, ShapeType? type) : base(GeneratedKey, PrefixLabel(label), type) {}
        public LateX(string key, string label, ShapeType? type = null, IEnumerable<Shape>? children = null) : base(key, PrefixLabel(label), type, children) {}
    }
}