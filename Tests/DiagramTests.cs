using D2.Enums;

namespace Tests;

public class DiagramTests
{
    [Test]
    public void ReadMeExample()
    {
        
        var A = new Shape("A", "Starting Point");
        var B = new Shape("B", "Ending Point");
        var C = new Shape("C", "Middle Point", ShapeType.Hexagon);

        var basicTemplate = Diagram.Create()
            .Add(A)
            .Add(B)
            .Add(C)
            .Add(new Connection(A, C))
            .Add(new Connection(C, B, "Hello World!"));
        
        const string exepected = @"A: Starting Point
B: Ending Point
C: Middle Point {
    shape: hexagon
}
A -> C
C -> B: Hello World!";

        Assert.That(basicTemplate.ToString(), Is.EqualTo(exepected));
        Assert.Pass();
    }
    
    [Test]
    public void HelloWorld()
    {
        var helloWorld = Diagram.Create()
            .Add(new Shape("Hello World"));
        const string expected = "Hello World";

        Assert.That(helloWorld.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void HelloWorldWithConnection()
    {
        var A = new Shape("A");
        var B = new Shape("B");
        var helloWorldWithConnection = Diagram.Create()
            .Add(A)
            .Add(B)
            .Add(new Connection(A, B, "Hello World"));

        const string expected = @"A
B
A -> B: Hello World";

        Assert.That(helloWorldWithConnection.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void HelloWorldWithConnectionAndArrowheads()
    {
        var A = new Shape("A");
        var B = new Shape("B");
        var helloWorldWithConnection = Diagram.Create()
            .Add(A)
            .Add(B)
            .Add(new Connection(A, B, "Hello World", ConnectionType.To,
                new ArrowheadOptions(ArrowheadType.CrowsFootMany), new ArrowheadOptions(ArrowheadType.CrowsFootOne)));

        const string expected = @"A
B
A <- B: Hello World {
    source-arrowhead: { shape: cf-many; style.filled: true }
    target-arrowhead: { shape: cf-one; style.filled: true }
}";

        Assert.That(helloWorldWithConnection.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void ShapesWithChildren()
    {
        var A = new Shape("A");
        var B = new Shape("B");
        var C = new Shape("C");
        var D = new Shape("D");
        var E = new Shape("E");
        var F = new Shape("F");
        var shapesWithChildren = Diagram.Create()
            .Add(A)
            .Add(B)
            .Add(C)
            .Add(D)
            .Add(E)
            .Add(F)
            .Add(new Connection(A, B))
            .Add(new Connection(A, C))
            .Add(new Connection(B, D))
            .Add(new Connection(C, E))
            .Add(new Connection(D, F))
            .Add(new Connection(E, F));

        const string expected = @"A
B
C
D
E
F
A -> B
A -> C
B -> D
C -> E
D -> F
E -> F";

        Assert.That(shapesWithChildren.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
}