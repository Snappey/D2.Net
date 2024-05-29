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
        private ShapeType? _type { get; set; }
        private Dictionary<string, string> _attributes { get; }
        private Dictionary<string, string> _styleAttributes { get; }
        private IEnumerable<Shape> _children { get; }

        public string Key => _key;
        public string Label => _label;

        public Shape(string label) : this(label, string.Empty) { }
        public Shape(string label, ShapeType? type) : this(label, string.Empty, type) { }

        public Shape(string key, string label, ShapeType? type = null, IEnumerable<Shape>? children = null)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty");

            _key = key;
            _label = label;
            _type = type;
            _children = children ?? Enumerable.Empty<Shape>();

            _attributes = new Dictionary<string, string>();
            _styleAttributes = new Dictionary<string, string>();
        }

        public Shape WithAttribute(string key, string value)
        {
            _attributes[key] = value;
            return this;
        }

        public Shape WithStyle(string key, string value)
        {
            _styleAttributes[key] = value;
            return this;
        }

        public Shape WithIcon(string icon)
        {
            _attributes["icon"] = icon;
            return this;
        }

        public Shape AsIcon(string icon)
        {
            _attributes["icon"] = icon;
            _type = ShapeType.Image;
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(_key);

            var hasProperties = _type.HasValue || _attributes.Count > 0 || _children.Any();
            var hasLabel = !string.IsNullOrWhiteSpace(_label);
            var hasStyle = _styleAttributes.Count > 0;
            if (hasProperties || hasLabel || hasStyle)
                sb.Append(":");

            if (hasLabel)
                sb.Append($" {_label}");

            if (!hasProperties && !hasStyle)
                return sb.ToString();

            sb.Append($" {OPEN_CONTAINER}{Environment.NewLine}");

            if (_type.HasValue)
                sb.AppendLine($"{TAB}shape: {_type.Value.CatalogName()}");

            if (hasStyle)
            {
                sb.AppendLine($"{TAB}style: {OPEN_CONTAINER}");
                foreach (var styleAttribute in _styleAttributes)
                {
                    sb.Append($"{TAB}{TAB}{styleAttribute.Key}: {styleAttribute.Value}");
                }
                sb.AppendLine($"{Environment.NewLine}{TAB}{CLOSE_CONTAINER}");
            }

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
