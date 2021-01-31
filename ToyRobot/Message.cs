namespace ToyRobot
{
  /// <summary>
  /// Constants used to present information to the user
  /// </summary>
  public class Message
  {
    public const string WELCOME_MESSAGE = "==========================\nToy Robot Coding Challenge\n==========================";
    public const string OUT_OF_BOUNDS_MESSAGE = "Invalid command - out of bounds";
    public const string NOT_YET_PLACED_MESSAGE = "Invalid command - robot not placed yet";
    public const string VALID_COMMANDS_MESSAGE = "Error during command handling.\nValid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT\nEXIT";
  }
}
