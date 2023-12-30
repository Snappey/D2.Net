﻿using System;
using System.Collections.Generic;
using System.Text;
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

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _renderables);
        }
    }
}