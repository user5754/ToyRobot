# Toy Robot

This .NET Core solution is a toy robot simulation. The robot moves on a 5 x 5 square tabletop that is free of obstructions. The user can control the robot with the following commands:

```
PLACE: will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
MOVE: will move the toy robot one space forward in the direction it is currently facing.
LEFT/RIGHT: will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
REPORT: will output the current X,Y and orientation of the robot
```

The first valid command to the robot must be "PLACE". Until the robot is placed on the table, all other commands are ignored. After the robot is on the table, any valid command may be issued in any order.

To exit the application, use:
```
EXIT
```

## Prerequisites

* .NET Core SDK

## Running

Navigate to the /ToyRobot folder and run the following command to Build the application
```
dotnet build
```
To run the console application enter:
```
dotnet run
```

## Testing
Navigate to the /ToyRobot.Tests folder and run the following command to run the unit tests
```
dotnet test
```

## To Do

* Logging
* More edge case tests

## Authors

* **Brian**