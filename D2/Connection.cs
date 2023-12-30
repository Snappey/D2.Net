using System.Text;
using D2.Enums;
using D2.Extensions;
using D2.Interfaces;
using static D2.Constants;

namespace D2
{
    public class Connection : IRenderable
    {
        private Shape _from { get; }
        private Shape _to { get; }
        private string? _label { get; }
        
        private ConnectionType _type { get; }
        private ArrowheadOptions? _fromArrowhead { get; }
        private ArrowheadOptions? _toArrowhead { get; }
        
        public Connection(Shape from, Shape to) : this(from, to, string.Empty) { }
        public Connection(Shape from,
            Shape to,
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
            var sb = new StringBuilder($"{_from.Key} {_type.CatalogName()} {_to.Key}");
            
            var hasProperties = _fromArrowhead != null || _toArrowhead != null;
            var hasLabel = !string.IsNullOrEmpty(_label);
            if (hasProperties || hasLabel)
                sb.Append(":");
            
            if (hasLabel)
                sb.Append($" {_label}");
            
            if (!hasProperties) return sb.ToString();

            sb.Append($" {OPEN_CONTAINER}");

            if (_fromArrowhead != null)
                sb.AppendLine($"{TAB}source-arrowhead: {_fromArrowhead}");
            
            if (_toArrowhead != null)
                sb.AppendLine($"{TAB}target-arrowhead: {_toArrowhead}");
            
            sb.Append(CLOSE_CONTAINER);
            
            return sb.ToString();
        }
    }
}