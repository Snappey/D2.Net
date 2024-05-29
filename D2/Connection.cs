using System;
using System.Text;
using D2.Enums;
using D2.Extensions;
using D2.Interfaces;
using static D2.Constants;

namespace D2
{
    public class Connection : IRenderable
    {
        private string _from { get; }
        private string _to { get; }
        private string? _label { get; }

        private ConnectionType _type { get; }
        private ArrowheadOptions? _fromArrowhead { get; }
        private ArrowheadOptions? _toArrowhead { get; }

        public Connection(Guid from, Guid to) : this(from.ToString(), to.ToString(), string.Empty, null) { }
        public Connection(Shape from, Shape to) : this(from.Key, to.Key, string.Empty, null) { }
        public Connection(string from, string to) : this(from, to, string.Empty, null) { }
        public Connection(Guid from, Guid to, string label) : this(from.ToString(), to.ToString(), label, null) { }
        public Connection(Shape from, Shape to, string label) : this(from.Key, to.Key, label, null) { }
        public Connection(string from, string to, string label, ArrowheadOptions? fromArrowhead = null, ArrowheadOptions? toArrowhead = null) : this(from, to, label, ConnectionType.From, fromArrowhead, toArrowhead) { }
        public Connection(Guid from, Guid to, string label, ConnectionType type) : this(from.ToString(), to.ToString(), label, type) { }
        public Connection(Shape from, Shape to, string label, ConnectionType type) : this(from.Key, to.Key, label, type) { }
        public Connection(string from, string to, string label, ConnectionType type) : this(from, to, label, type, null, null) { }
        public Connection(string from, string to, string label, ConnectionType type, ArrowheadOptions? fromArrowhead) : this(from, to, label, type, fromArrowhead, null) { }
        public Connection(Shape from, Shape to, string label, ConnectionType type = ConnectionType.From, ArrowheadOptions? fromArrowhead = null, ArrowheadOptions? toArrowhead = null) : this(from.Key, to.Key, label, type, fromArrowhead, toArrowhead) { }
        public Connection(Guid from, Guid to, string label, ConnectionType type = ConnectionType.From, ArrowheadOptions? fromArrowhead = null, ArrowheadOptions? toArrowhead = null) : this(from.ToString(), to.ToString(), label, type, fromArrowhead, toArrowhead) { }
        public Connection(string from,
            string to,
            string label,
            ConnectionType type = ConnectionType.From,
            ArrowheadOptions? fromArrowhead = null,
            ArrowheadOptions? toArrowhead = null)
        {
            _from = from;
            _to = to;
            _label = label;
            _type = type;
            _fromArrowhead = fromArrowhead;
            _toArrowhead = toArrowhead;
        }

        public override string ToString()
        {
            var sb = new StringBuilder($"{_from} {_type.CatalogName()} {_to}");

            var hasProperties = _fromArrowhead != null || _toArrowhead != null;
            var hasLabel = !string.IsNullOrEmpty(_label);
            if (hasProperties || hasLabel)
                sb.Append(":");

            if (hasLabel)
                sb.Append($" {_label}");

            if (!hasProperties) return sb.ToString();

            sb.Append($" {OPEN_CONTAINER}{Environment.NewLine}");

            if (_fromArrowhead != null)
                sb.AppendLine($"{TAB}source-arrowhead: {_fromArrowhead}");

            if (_toArrowhead != null)
                sb.AppendLine($"{TAB}target-arrowhead: {_toArrowhead}");

            sb.Append(CLOSE_CONTAINER);

            return sb.ToString();
        }
    }
}
