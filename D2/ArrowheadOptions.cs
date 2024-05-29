using System;
using System.Text;
using D2.Enums;
using D2.Extensions;
using static D2.Constants;

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
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(_label))
                sb.Append($"{_label} ");

            if (!_type.HasValue) return sb.ToString();

            sb.Append(OPEN_CONTAINER);

            sb.Append($" shape: {_type.Value.ToCatalog()};"); // TODO: Determine if fill is default for given arrowhead type
            sb.Append($" style.filled: {_fill.ToString().ToLower()} ");

            sb.Append(CLOSE_CONTAINER);

            return sb.ToString();
        }
    }
}
