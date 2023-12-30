namespace D2
{
    public class Shape
    {
        private string _key { get; }
        private string _label { get; }
        private ShapeType? _type { get; }
        
        public Shape(string key, string label, ShapeType? type)
        {
            _key = key;
            _label = label;
            _type = type;
        }

        public override string ToString() => _type.HasValue 
            ? $"{_key}.{_type}: {_label}"
            : $"{_key}: {_label}";
    }
}