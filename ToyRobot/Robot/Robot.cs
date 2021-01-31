using System;
using ToyRobot.Tabletop;

namespace ToyRobot.Robot
{
  /// <summary>
  /// Contains the methods related to the robot
  /// </summary>
  public class Robot : IRobot
  {
    private const int COMMAND_INDEX = 0;
    private const int X_INDEX = 1;
    private const int Y_INDEX = 2;
    private const int ORIENTATION_INDEX = 3;

    private readonly ITabletop _tabletop;
    private bool isPlaced;

    public Robot(ITabletop tabletop)
    {
      _tabletop = tabletop;
      isPlaced = false;
    }

    /// <summary>
    /// Splits the input from the user and calls the intended action's method
    /// </summary>
    /// <param name="command">The user input</param>
    /// <returns>An error message if applicable else empty sting</returns>
    public string ProcessCommand(string command)
    {
      char[] delimiterChars = { ',', ' ' };
      string[] wordsInCommand = command.Split(delimiterChars);

      string result;
      if (System.Enum.TryParse(wordsInCommand[COMMAND_INDEX], out Enum.ActionType action))
      {
        switch (action)
        {
          case Enum.ActionType.PLACE:
            try
            {
              result = _tabletop.Place(
                int.Parse(wordsInCommand[X_INDEX]),
                int.Parse(wordsInCommand[Y_INDEX]),
                System.Enum.Parse<Enum.Orientation>(wordsInCommand[ORIENTATION_INDEX]));
              
              isPlaced = result.Equals(string.Empty);
            }
            catch (Exception ex)
            {
              if (ex is ArgumentException || ex is FormatException)
              {
                result = ex.Message;
              }
              else
              {
                throw;
              }
            }
            break;
          case Enum.ActionType.MOVE:
            result = isPlaced ? _tabletop.Move() : Message.NOT_YET_PLACED_MESSAGE;
            break;
          case Enum.ActionType.LEFT:
            result = isPlaced ? _tabletop.ChangeDirection(Enum.Direction.LEFT) : Message.NOT_YET_PLACED_MESSAGE;
            break;
          case Enum.ActionType.RIGHT:
            result = isPlaced ? _tabletop.ChangeDirection(Enum.Direction.RIGHT) : Message.NOT_YET_PLACED_MESSAGE;
            break;
          case Enum.ActionType.REPORT:
            result = isPlaced ? _tabletop.Report() : Message.NOT_YET_PLACED_MESSAGE;
            break;
          default:
            result = Message.VALID_COMMANDS_MESSAGE;
            break;
        }
      }
      else
      {
        result = Message.VALID_COMMANDS_MESSAGE;
      }

      return result;
    }
  }
}
