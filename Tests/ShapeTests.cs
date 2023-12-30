using D2.Enums;

namespace Tests;

public class ShapeTests
{
    [Test]
    public void HelloWorld()
    {
        var helloWorld = new Shape("A", "Hello World");
        const string expected = "A: Hello World";

        Assert.That(helloWorld.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void CustomShape()
    {
        var customShape = new Shape("B", ShapeType.Hexagon);
        const string expected = @"B: {
    shape: hexagon
}";

        Assert.That(customShape.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void NullShapeType()
    {
        var nullShapeType = new Shape("C", "Null Shape Type", null);
        const string expected = "C: Null Shape Type";

        Assert.That(nullShapeType.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void FullyConfigured()
    {
        var fullyConfigured = new Shape("D", "Fully Configured", ShapeType.Circle);
        const string expected = @"D: Fully Configured {
    shape: circle
}";

        Assert.That(fullyConfigured.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void NullShapeTypeWithNullLabel()
    {
        var nullShapeTypeWithNullLabel = new Shape("E");
        const string expected = "E";

        Assert.That(nullShapeTypeWithNullLabel.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void NullShapeTypeWithEmptyLabel()
    {
        var nullShapeTypeWithEmptyLabel = new Shape("F", string.Empty);
        const string expected = "F";

        Assert.That(nullShapeTypeWithEmptyLabel.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void NullKey()
    {
        Assert.Throws<ArgumentException>(() => new Shape(string.Empty));
        Assert.Pass();
    }

    [Test]
    public void ShapeWithChildren()
    {
        var shapeWithChildren = new Shape("G", "Shape With Children", ShapeType.Rectangle, new[]
        {
            new Shape("H", "Child 1"),
            new Shape("I", "Child 2"),
            new Shape("J", "Child 3")
        });
        const string expected = @"G: Shape With Children {
    shape: rectangle
    H: Child 1
    I: Child 2
    J: Child 3
}";

        Assert.That(shapeWithChildren.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void ShapeWithUniqueChildren()
    {
        var shapeWithChildren = new Shape("G", "Shape With Children", ShapeType.Rectangle, new[]
        {
            new Shape("H", "Child 1"),
            new Shape("I", "Child 2"),
            new Shape("J", "Child 3"),
            new Shape("L", "Child 4", ShapeType.Circle),
            new Shape("K", "Child 5", ShapeType.Hexagon),
            new Shape("M", "Child 6", ShapeType.StoredData)
        });
        const string expected = @"G: Shape With Children {
    shape: rectangle
    H: Child 1
    I: Child 2
    J: Child 3
    L: Child 4 {
        shape: circle
    }
    K: Child 5 {
        shape: hexagon
    }
    M: Child 6 {
        shape: stored_data
    }
}";

        Assert.That(shapeWithChildren.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }


    [Test]
    public void ShapeWithNonFriendlyName()
    {
        var shapeWithNonFriendlyName = new Shape("M", "Shape With Non-Friendly Name", ShapeType.StoredData);
        const string expected = @"M: Shape With Non-Friendly Name {
    shape: stored_data
}";

        Assert.That(shapeWithNonFriendlyName.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void ShapeWithAttributes()
    {
        var shapeWithAttributes = new Shape("N", "Shape With Attributes", ShapeType.Rectangle)
            .WithAttribute("near", "top-center")
            .WithAttribute("direction", "right")
            .WithAttribute("link", "https://www.google.co.uk");

        const string expected = @"N: Shape With Attributes {
    shape: rectangle
    near: top-center
    direction: right
    link: https://www.google.co.uk
}";

        Assert.That(shapeWithAttributes.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void ShapeWithAttributesAndChildren()
    {
        var shapeWithAttributesAndChildren = new Shape("O", "Shape With Attributes And Children", ShapeType.Rectangle,
                new[]
                {
                    new Shape("P", "Child 1"),
                    new Shape("Q", "Child 2"),
                    new Shape("R", "Child 3")
                })
            .WithAttribute("near", "top-center")
            .WithAttribute("direction", "right")
            .WithAttribute("link", "https://www.google.co.uk");

        const string expected = @"O: Shape With Attributes And Children {
    shape: rectangle
    near: top-center
    direction: right
    link: https://www.google.co.uk
    P: Child 1
    Q: Child 2
    R: Child 3
}";

        Assert.That(shapeWithAttributesAndChildren.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void MarkdownShape()
    {
        var markdownShape = new Markdown("S",
            $"# I can do headers{Environment.NewLine}  - lists{Environment.NewLine}  - lists");
        const string expected = @"S: |md
# I can do headers
  - lists
  - lists|";

        Assert.That(markdownShape.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }

    [Test]
    public void MarkdownShapeWithChildrenAndShape()
    {
        var markdownShapeWithChildren = new Markdown("T",
            $"# I can do headers{Environment.NewLine}  - lists{Environment.NewLine}  - lists", ShapeType.Hexagon, new[]
            {
                new Shape("U", "Child 1"),
                new Shape("V", "Child 2"),
                new Shape("W", "Child 3")
            });
        const string expected = @"T: |md
# I can do headers
  - lists
  - lists| {
    shape: hexagon
    U: Child 1
    V: Child 2
    W: Child 3
}";

        Assert.That(markdownShapeWithChildren.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void LateXShape()
    {
        var lateXShape = new LateX("X",
            @"\\lim_{h \\rightarrow 0 } \\frac{f(x+h)-f(x)}{h}");
        const string expected = @"X: |latex
\\lim_{h \\rightarrow 0 } \\frac{f(x+h)-f(x)}{h}|";
        
        Assert.That(lateXShape.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void LateXShapeWithChildrenAndShape()
    {
        var lateXShapeWithChildren = new LateX("Y",
            @"\\lim_{h \\rightarrow 0 } \\frac{f(x+h)-f(x)}{h}", ShapeType.Hexagon, new[]
            {
                new Shape("Z", "Child 1"),
                new Shape("AA", "Child 2"),
                new Shape("AB", "Child 3")
            });
        const string expected = @"Y: |latex
\\lim_{h \\rightarrow 0 } \\frac{f(x+h)-f(x)}{h}| {
    shape: hexagon
    Z: Child 1
    AA: Child 2
    AB: Child 3
}";
        
        Assert.That(lateXShapeWithChildren.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void ShapeWithIcon()
    {
        var shapeWithIcon = new Shape("AC", "Shape With Icon", ShapeType.Rectangle)
            .WithIcon("https://icons.terrastruct.com/aws%2FCompute%2F_Instance%2FAmazon-EC2_C4-Instance_light-bg.svg");
        const string expected = @"AC: Shape With Icon {
    shape: rectangle
    icon: https://icons.terrastruct.com/aws%2FCompute%2F_Instance%2FAmazon-EC2_C4-Instance_light-bg.svg
}";

        Assert.That(shapeWithIcon.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
    
    [Test]
    public void ShapeAsIcon()
    {
        var shapeAsIcon = new Shape("AD", "Shape As Icon", ShapeType.Rectangle) // Rectangle is ignored and overwritten
            .AsIcon("https://icons.terrastruct.com/aws%2FCompute%2F_Instance%2FAmazon-EC2_C4-Instance_light-bg.svg");
        const string expected = @"AD: Shape As Icon {
    shape: image
    icon: https://icons.terrastruct.com/aws%2FCompute%2F_Instance%2FAmazon-EC2_C4-Instance_light-bg.svg
}";

        Assert.That(shapeAsIcon.ToString(), Is.EqualTo(expected));
        Assert.Pass();
    }
}