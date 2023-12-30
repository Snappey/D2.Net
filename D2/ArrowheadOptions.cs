using System.Text;

namespace D2
{
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
}