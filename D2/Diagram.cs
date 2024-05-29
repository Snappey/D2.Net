using System;
using System.Collections.Generic;
using System.Text;
using D2.Enums;
using D2.Interfaces;

namespace D2
{
    public class Diagram : IRenderable
    {
        private readonly List<IRenderable> _renderables = new List<IRenderable>();

        public static Diagram Create() => new Diagram();

        public Diagram Add(IRenderable renderable)
        {
            _renderables.Add(renderable);
            return this;
        }

        public Diagram Add(IEnumerable<IRenderable> renderable)
        {
            _renderables.AddRange(renderable);
            return this;
        }

        public Diagram Connect(Shape from, Shape to, string label = "", ArrowheadOptions? fromArrowhead = null, ArrowheadOptions? toArrowhead = null)
        {
            _renderables.Add(new Connection(from.Key, to.Key, label, fromArrowhead, toArrowhead));
            return this;
        }

        public Diagram CreateShape(string key, string label, ShapeType type)
        {
            _renderables.Add(new Shape(key, label, type));
            return this;
        }

        public Diagram CreateShape(string key, string label)
        {
            _renderables.Add(new Shape(key, label));
            return this;
        }

        public Diagram CreateShape(string key, ShapeType type)
        {
            _renderables.Add(new Shape(key, type));
            return this;
        }

        public Diagram CreateMarkdownShape(string key, string label)
        {
            _renderables.Add(new Markdown(key, label));
            return this;
        }

        public Diagram CreateMarkdownShape(string key, string label, ShapeType type)
        {
            _renderables.Add(new Markdown(key, label, type));
            return this;
        }

        public Diagram CreateLatexShape(string key, string label)
        {
            _renderables.Add(new LateX(key, label));
            return this;
        }

        public Diagram CreateLatexShape(string key, string label, ShapeType type)
        {
            _renderables.Add(new LateX(key, label, type));
            return this;
        }

        public Diagram CreateDirectionalConnection(string from, string to, string label = "", ArrowheadOptions? toArrowhead = null)
        {
            _renderables.Add(new Connection(from, to, label, null, toArrowhead));
            return this;
        }

        public Diagram CreateBidirectionalConnection(string from, string to, string label = "", ArrowheadOptions? fromArrowhead = null, ArrowheadOptions? toArrowhead = null)
        {
            _renderables.Add(new Connection(from, to, label, ConnectionType.Bidirectional, fromArrowhead, toArrowhead));
            return this;
        }

        public Diagram CreateConnection(string from, string to, string label = "")
        {
            _renderables.Add(new Connection(from, to, label, ConnectionType.From));
            return this;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _renderables);
        }
    }
}
