# NASARover
Utility program to simulate rover movements

## How to run console app
This program is build with **.NET Core 3.1** (`NASARover.ConsoleApp` and `NASARover.Tests`) and **.NET Standard 2.1** (`NASARover.Core`). To build and run you need to install latest [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download). Note that in order to compile and run the latest version of Visual Studio or Visual Studio for Mac is required (2019).

You could run the console application in two different ways:

1. Open `NASARover.sln` in your favourite IDE (Visual Studio, VS Code, VS for Mac or Rider), select `NASARover.ConsoleApp` as a startup project and press the run button.
2. Open `src/NASARover/NASARover.ConsoleApp` directory in console or terminal and run `dotnet run` command.

## How to run tests

You could run the tests in two different ways:

1. Open `NASARover.sln` in your favourite IDE (Visual Studio, VS Code, VS for Mac or Rider), open Unit Tests pad or Tests Explorer and press the run button.
2. Open `src/NASARover/NASARover.Tests` directory in console or terminal and run `dotnet test` command.

## Dependencies
This program has no external dependencies for `NASARover.Core` and `NASARover.ConsoleApp` projects.

`NASARover.Tests` uses the [NUnit 3](https://github.com/nunit/nunit) NuGet package as a test framework.

## Architecture and structure decisions

For the sake of simplicity, the program is build fully with OOP paradigm. `Rover` class has the state and the actions that it could execute (e.g. `Move`, `Rotate`). All the user input is done in `NASARover.ConsoleApp` project and processed by the series of parsers.

There are many other ways of how this program could be built and I want to describe some of them:

1. Since the program is quite simillar to some simple games, it could utilize the **Entity Component System (ECS)**. `Rover` and `Plateau` could be a simple model classes and the behaviour could be added as an entity. This way we could reduce code coupeling and produce a bit cleaner code.
2. Another possible way is to inject strategies for moving and rotating to the `Rover` class. This is also helps separating state from the behaviour.
3. The whole program state could be managed by a separate entity. It could contain the information about all of the rovers and manipulate them. I don't this is a good design, because in this way this entity must manipulate rover's state (exposing public properties is rarely a good idea).

## Assumptions

Since the program specification is not complete, I made some assumptions during the development process.

1. Each plateau cell could contain multiple rovers at a single time. This logic could be changed by adding a condition to `Plateau.IsValidPosition` method.
2. For each invalid action (e.g. invalid input, invalid rover movement) the program throws an Exception (usually `ArgumentException` or `InvalidOperationException`).
3. Since the specification is very strict about the number of rovers and the bottom-left coordinate of the plateau, I assume that this could be changed in future. So, the console application asks about the number of the rovers to make it more flexible and extendable. Also, `Plateau` class has an additional ctor with bottom-left coordinate if needed.

## Specification
A squad of robotic rovers are to be landed by NASA on a plateau on Mars. 
The navigation team needs a utility for them to simulate rover movements so they can develop a navigation plan.

A rover's position is represented by a combination of an x and y co-ordinates and a letter
representing one of the four cardinal compass points. The plateau is divided up into a grid to
simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom
left corner and facing North.

In order to control a rover, NASA sends a simple string of letters. The possible letters are:

'L' – Make the rover spin 90 degrees left without moving from its current spot
'R' - Make the rover spin 90 degrees right without moving from its current spot
'M' - Move forward one grid point, and maintain the same heading.

Assume that the square directly North from (x, y) is (x, y+1).

### INPUT
The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are
assumed to be 0,0.

The rest of the input is information pertaining to the rovers that have been deployed. Each rover
has two lines of input. The first line gives the rover's position, and the second line is a series of
instructions telling the rover how to explore the plateau.

The position is made up of two integers and a letter separated by spaces, corresponding to the x
and y co-ordinates and the rover's orientation.

Each rover will be finished sequentially, which means that the second rover won't start to move
until the first one has finished moving.

### OUTPUT
The output for each rover should be its final co-ordinates and heading.
Example Program Flow:
```
Enter Graph Upper Right Coordinate: 5 5
Rover 1 Starting Position: 1 2 N
Rover 1 Movement Plan: LMLMLMLMM
Rover 1 Output: 1 3 N
Rover 2 Starting Position: 3 3 E
Rover 2 Movement Plan: MMRMMRMRRM
Rover 2 Output: 5 1 E
```
