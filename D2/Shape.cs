using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D2.Enums;
using D2.Extensions;
using D2.Interfaces;
using static D2.Constants;

namespace D2
{
    public class Shape : IRenderable
    {
        private string _key { get; }
        private string _label { get; }
        private ShapeType? _type { get; }
        private Dictionary<string, string> _attributes { get; }
        private IEnumerable<Shape> _children { get; }
        
        public Shape(string label) : this(label, string.Empty, null) { }
        public Shape(string label, ShapeType? type) : this(label, string.Empty, type) { }
        public Shape(string label, string key) : this(label, key, null) { }
        
        public Shape(string key, string label, ShapeType? type, IEnumerable<Shape>? children = null)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty");
            
            _key = key;
            _label = label;
            _type = type;

            _attributes = new Dictionary<string, string>();
            _children = children ?? Array.Empty<Shape>();
        }
        
        public Shape WithAttribute(string key, string value)
        {
            _attributes[key] = value;
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(_key);
            
            var hasProperties = _type.HasValue || _attributes.Count > 0 || _children.Any();
            var hasLabel = !string.IsNullOrWhiteSpace(_label);
            if (hasProperties || hasLabel)
                sb.Append(":");
            
            if (hasLabel)
                sb.Append($" {_label}");

            if (!hasProperties) return sb.ToString();
            
            sb.Append($" {OPEN_CONTAINER}");
                
            if (_type.HasValue)
                sb.AppendLine($"{TAB}shape: {_type.Value.CatalogName()}");

            if (_attributes.Count > 0)
            {
                foreach (var attribute in _attributes)
                {
                    sb.AppendLine($"{TAB}{attribute.Key}: {attribute.Value}");
                }
            }
            
            if (_children.Any())
            {
                foreach (var child in _children)
                {
                    var childString = child.ToString();
                    var indentedChildString = childString.Replace(Environment.NewLine, $"{Environment.NewLine}{TAB}");
                    sb.AppendLine($"{TAB}{indentedChildString}");
                }
            }
                
            sb.Append(CLOSE_CONTAINER);

            return sb.ToString();
        }
    }
}