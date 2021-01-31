using Microsoft.Extensions.DependencyInjection;
using System;
using ToyRobot.Robot;
using ToyRobot.Tabletop;

namespace ToyRobot
{
  public class Program
  {
    /// <summary>
    /// Entry point for the program
    /// </summary>
    /// <param name="args">Any additional command line arguments</param>
    public static void Main(string[] args)
    {
      var serviceProvider = new ServiceCollection()
            .AddSingleton<IRobot, Robot.Robot>()
            .AddSingleton<ITabletop, Tabletop.Tabletop>()
            .BuildServiceProvider();

      Console.WriteLine(Message.WELCOME_MESSAGE);

      var robot = serviceProvider.GetService<IRobot>();

      string input;
      while (true)
      {
        Console.Write("Enter a command: ");
        input = Console.ReadLine().ToUpper();

        if (Enum.ActionType.EXIT.ToString().Equals(input))
        {
          break;
        }

        Console.WriteLine(robot.ProcessCommand(input));
      }

      Environment.Exit(0);
    }
  }
}
