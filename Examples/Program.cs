using D2;
using D2.Enums;

var A = new Shape("A", "Starting Point");
var B = new Shape("B", "Ending Point");
var C = new Shape("C", "Middle Point", ShapeType.Hexagon);

var basicTemplate = Diagram.Create()
    .Add(A)
    .Add(B)
    .Add(C)
    .Add(new Connection(A, C))
    .Add(new Connection(C, B, "Hello World!"));

// Each component overrides ToString() to return the D2 code for that instance
Console.WriteLine(basicTemplate);