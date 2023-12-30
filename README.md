

[D2 Language templates](https://github.com/terrastruct/d2)

<div align="center">
<h1>D2.Net</h1>
    <a href="https://github.com/terrastruct/d2">
        <img src="https://github.com/terrastruct/d2/blob/master/docs/assets/banner.png?raw=true" alt="D2" />
    </a>
<h3>
A .NET Library for programatically creating D2 Templates.
</h3>


![Latest Version](https://img.shields.io/github/v/release/Snappey/D2.Net)
[![NuGet](https://img.shields.io/nuget/v/D2.Net.svg)](https://www.nuget.org/packages/D2.Net/)
![License](https://img.shields.io/github/license/Snappey/D2.Net.svg)

</div>

## About

This library aims to provide a simple and expressive way to create D2 templates that can be easily integrated into any .NET application. Enabling easy generation of diagrams for documentation, reports, and more based off of data from your application.

Currently this library is in early development and not all D2 features are supported, see below for a high level list of supported features.

### Supported D2 Features

- [x] Shapes
  - [x] Labels
  - [x] Containers / Children
  - [ ] Styling
- [x] Connections
  - [x] Labels
  - [x] Arrow Styling/Directions
  - [ ] Styling
- [ ] Tooltips / Links
- [ ] Icons
- [ ] Standalone Text / Markdown / LateX
- [ ] Sequence Diagrams
- [ ] UML/Class Diagrams
- [ ] SQL Table Diagrams

## Installation

D2.Net is available on [NuGet](https://www.nuget.org/packages/D2.Net/).

```bash
dotnet add package D2.Net
```

## Usage

Here is an example of creating a basic template using D2.Net.

```csharp
using D2;

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
// or you can use the Render() method
Console.WriteLine(basicTemplate.Render());

```
This will output the following D2 code:

```d2
A: Starting Point
B: Ending Point
C: Middle Point {
  shape: hexagon
}
A -> C
C -> B: Hello World!
```
That is rendered to the following diagram, using the [D2 Playground](https://play.d2lang.com/?script=crRSCC5JLCrJzEtXCMjPzCvhcrJScM1LQfCdrRR8M1NSclIhfIVqLgUFBYXijMSCVCuFjNSKxPT8PK5aLkcFXTsFZy5nEOVkpeCRmpOTrxCeX5STosgFCAAA__8%3D&)!
![Basic Template](./assets/d2-readme.png)