using System.Collections.Generic;
using System.Text;

namespace D2.Writers
{
  public class D2Writer
  {
    private readonly StringBuilder _sb = new StringBuilder();

    public override string ToString() => _sb.ToString();

    private void NewLine() => _sb.AppendLine();
    private void Tab() => _sb.Append('\t');
    private void Tab(int count) => _sb.Append('\t', count);

    private const string LABEL_SEPARATOR = ": ";
    private const string TAB_CHAR = "  ";
    private StringBuilder AppendShape(string key) => _sb.AppendLine(key);
    private StringBuilder AppendShape(string key, string label) => _sb.AppendLine(key + LABEL_SEPARATOR + label);

    // Basic Elements
    public void DeclareShape(string key) => AppendShape(key);
    public void DeclareShape(string key, string label) => AppendShape(key, label);

    // Connections
    private const string CONNECTION = " -- ";
    private const string CONNECTION_BIDIRECTIONAL = " <-> ";
    private const string CONNECTION_FROM = " <- ";
    private const string CONNECTION_TO = " -> ";

    private static string BuildConnection(string connection, IEnumerable<string> keys) => string.Join(connection, keys);
    private void AppendConnection(IEnumerable<string> keys, string connection, string? label, Dictionary<string, string>? attributes)
    {
      if (string.IsNullOrWhiteSpace(label))
        _sb.AppendLine(BuildConnection(connection, keys));
      else
        AppendShape(BuildConnection(connection, keys), label);

      if (attributes != null && attributes.Count > 0)
      {
        WriteContainer(attributes);
      }
    }

    public void DeclareConnection(IEnumerable<string> keys) => AppendConnection(keys, CONNECTION, null, null);
    public void DeclareConnection(string label, IEnumerable<string> keys) => AppendConnection(keys, CONNECTION, label, null);
    public void DeclareConnection(string label, IEnumerable<string> keys, Dictionary<string, string> attributes) => AppendConnection(keys, CONNECTION, label, attributes);

    public void DeclareToConnection(IEnumerable<string> keys) => AppendConnection(keys, CONNECTION_TO, null, null);
    public void DeclareToConnection(string label, IEnumerable<string> keys) => AppendConnection(keys, CONNECTION_TO, label, null);
    public void DeclareToConnection(string label, IEnumerable<string> keys, Dictionary<string, string> attributes) => AppendConnection(keys, CONNECTION_TO, label, attributes);

    public void DeclareFromConnection(IEnumerable<string> keys) => AppendConnection(keys, CONNECTION_FROM, null, null);
    public void DeclareFromConnection(string label, IEnumerable<string> keys) => AppendConnection(keys, CONNECTION_FROM, label, null);
    public void DeclareFromConnection(string label, IEnumerable<string> keys, Dictionary<string, string> attributes) => AppendConnection(keys, CONNECTION_FROM, label, attributes);

    public void DeclareBidirectionalConnection(IEnumerable<string> keys) => AppendConnection(keys, CONNECTION_BIDIRECTIONAL, null, null);
    public void DeclareBidirectionalConnection(string label, IEnumerable<string> keys) => AppendConnection(keys, CONNECTION_BIDIRECTIONAL, label, null);
    public void DeclareBidirectionalConnection(string label, IEnumerable<string> keys, Dictionary<string, string> attributes) => AppendConnection(keys, CONNECTION_BIDIRECTIONAL, label, attributes);

    // Containers
    private const string OPEN_CONTAINER = "{";
    private const string CLOSE_CONTAINER = "}";

    private void WriteContainer(Dictionary<string, string> attributes)
    {
      _sb.AppendLine(OPEN_CONTAINER);
      foreach (var (key, value) in attributes)
      {
        _sb.AppendLine(TAB_CHAR + key + LABEL_SEPARATOR + value);
      }
      _sb.AppendLine(CLOSE_CONTAINER);
    }

    private void WriteContainerInline(string prefix, Dictionary<string, string> attributes)
    {
      foreach (var (key, value) in attributes)
      {
        _sb.AppendLine(prefix + "." + key + LABEL_SEPARATOR + value);
      }
    }
  }
}
