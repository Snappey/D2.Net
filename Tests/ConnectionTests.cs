using D2.Enums;

namespace Tests;

public class ConnectionTests
{
    private readonly Shape A = new Shape("A");
    private readonly Shape B = new Shape("B");
    
    [Test]
    public void HelloWorld()
    {
        var helloWorld = new Connection(A, B);
        const string expected = "A -> B";
        
        Assert.That(helloWorld.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void HelloWorldWithLabel()
    {
        var helloWorldWithLabel = new Connection(A, B, "Hello World");
        const string expected = "A -> B: Hello World";
        
        Assert.That(helloWorldWithLabel.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void HelloWorldWithLabelAndType()
    {
        var helloWorldWithLabelAndType = new Connection(A, B, "Hello World", ConnectionType.To);
        const string expected = "A <- B: Hello World";
        
        Assert.That(helloWorldWithLabelAndType.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void HelloWorldWithLabelAndTypeAndArrowhead()
    {
        var helloWorldWithLabelAndTypeAndArrowhead = new Connection(A, B, "Hello World", 
            ConnectionType.To, 
            new ArrowheadOptions(ArrowheadType.Circle, "1"), 
            new ArrowheadOptions(ArrowheadType.Diamond, "2")
        );
        
        const string expected = @"A <- B: Hello World {
    source-arrowhead: 1 { shape: circle; style.filled: true }
    target-arrowhead: 2 { shape: diamond; style.filled: true }
}";
        
        Assert.That(helloWorldWithLabelAndTypeAndArrowhead.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void HelloWorldWithLabelAndTypeAndArrowheadAndNoFill()
    {
        var helloWorldWithLabelAndTypeAndArrowheadAndFill = new Connection(A, B, "Hello World", 
            ConnectionType.To, 
            new ArrowheadOptions(ArrowheadType.Circle, "1", false), 
            new ArrowheadOptions(ArrowheadType.Diamond, "2", false)
        );
        
        const string expected = @"A <- B: Hello World {
    source-arrowhead: 1 { shape: circle; style.filled: false }
    target-arrowhead: 2 { shape: diamond; style.filled: false }
}";
        
        Assert.That(helloWorldWithLabelAndTypeAndArrowheadAndFill.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void HelloWorldWithLabelAndTypeAndArrowheadAndNoLabel()
    {
        var helloWorldWithLabelAndTypeAndArrowheadAndFill = new Connection(A, B, "Hello World", 
            ConnectionType.To, 
            new ArrowheadOptions(ArrowheadType.Circle), 
            new ArrowheadOptions(ArrowheadType.Diamond)
        );
        
        const string expected = @"A <- B: Hello World {
    source-arrowhead: { shape: circle; style.filled: true }
    target-arrowhead: { shape: diamond; style.filled: true }
}";
        
        Assert.That(helloWorldWithLabelAndTypeAndArrowheadAndFill.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
}