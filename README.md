# CRACULATOR
> a horrid combination of "cross" and "calculator"..

This is just a basic calculator, It can add, subtract, multiply, divide and store the history of previous calculations. 
Since I'm just coming back to programming after a long break, I wanted to start with a simple project.

# todo..
- [] History window
- [] dark mode
- [] polish

#### fixing errors
- [] pressing equals gives an error since there's nothing to put onto the stack
- [] you can backspace until you run into an error since there's nothing left to remove
- [] decimals are supported as addition rather than being a whole number, also ignoring the rest of the equation

### BUILDING
**Since this is a WPF project, it can be built using Visual Studio or The dotnet CLI. This specific project uses .NET 8.0 and Visual Studio version 2022.**

*Since WPF is not cross-platform this works on Windows only.*

#### Through Visual Studio

    git clone https://github.com/cross-forever/craculator.git
    cd ./craculator
    ./craculator.sln

#### Through .NET

    git clone https://github.com/cross-forever/craculator.git
    cd ./craculator
  	dotnet build
