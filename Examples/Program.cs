using D2;
using D2.Enums;
using D2.Writers;

var A = new Shape("A", "Starting Point");
var B = new Shape("B", "Ending Point");
var C = new Shape("C", "Middle Point", ShapeType.Hexagon);

A.WithStyle("fill", "green");
B.WithStyle("fill", "red");
C.WithStyle("fill", "blue");

var basicTemplate = Diagram.Create()
    .Add(A)
    .Add(B)
    .Add(C)
    .Connect(A, C)
    .Connect(C, B);

// Each component overrides ToString() to return the D2 code for that instance
Console.WriteLine("Basic Template:");
Console.WriteLine(basicTemplate);

var styledTemplate = Diagram.Create()
    .CreateShape("D", type: ShapeType.Circle)
    .CreateShape("E", "Styled Shape", ShapeType.Hexagon)
    .CreateShape("F", "Styled Diamond Shape", ShapeType.Diamond)
    .CreateDirectionalConnection("D", "E", "Styled Connection", new ArrowheadOptions(ArrowheadType.CrowsFootManyRequired, "Filled Triangle"))
    .CreateBidirectionalConnection("E", "F", "Bidirectional Connection",
        new ArrowheadOptions(ArrowheadType.CrowsFootManyRequired),
        new ArrowheadOptions(ArrowheadType.CrowsFootManyRequired))
    .CreateConnection("F", "D")
    .CreateMarkdownShape("G", @"  # I can do headers

  - lists
  - lists

  And other normal markdown stuff")
    .CreateLatexShape("H", @"\\lim_{h \\rightarrow 0 } \\frac{f(x+h)-f(x)}{h}")
    .CreateBidirectionalConnection("G", "H");

Console.WriteLine("Styled Template:");
Console.WriteLine(styledTemplate);
