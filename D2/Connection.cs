using System.Text;

namespace D2
{
    public enum ArrowheadType
    {
        Triangle,
        Arrow,
        Diamond,
        Circle,
        CrowsFootOne,
        CrowsFootMany,
        CrowsFootOneRequired,
        CrowsFootManyRequired,
    }
    
    public class ArrowheadOptions
    {
        private ArrowheadType? _type { get; }
        private string _label { get; }
        private bool _fill { get; }
        
        public ArrowheadOptions(ArrowheadType type, string label = "", bool fill = true)
        {
            _type = type;
            _label = label;
            _fill = fill;
        }   
        
        public override string ToString()
        {
            if (!_type.HasValue)
                return _label;
            
            var sb = new StringBuilder(_label);
            sb.Append(" {");
            sb.AppendLine();
            
            sb.AppendLine($"shape: {_type},");
            sb.AppendLine($"style.filled: {_fill}");
            
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
    
    public class Connection
    {
        private Shape _from { get; }
        private Shape _to { get; }
        private string _label { get; }
        
        private ConnectionType _type { get; }
        private ArrowheadOptions? _fromArrowhead { get; }
        private ArrowheadOptions? _toArrowhead { get; }
        
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
            var hasCustomisedArrowheads = _fromArrowhead != null || _toArrowhead != null;
            var line = $"{_from} {_type} {_to}: {_label}"; // From A to B: Label
            if (!hasCustomisedArrowheads)
                return line;
            
            var sb = new StringBuilder(line);
            sb.Append(" {");
            sb.AppendLine();
            if (_fromArrowhead != null)
                sb.AppendLine($"source-arrowhead: {_fromArrowhead}");
            
            if (_toArrowhead != null)
                sb.AppendLine($"target-arrowhead: {_toArrowhead}");
            
            sb.AppendLine("}");
            
            return sb.ToString();
        }
    }
}