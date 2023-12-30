namespace D2.Interfaces
{
    public interface IRenderable
    {
        public string Render() => ToString();
        public string ToString();
    }
}