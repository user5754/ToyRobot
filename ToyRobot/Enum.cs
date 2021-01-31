namespace ToyRobot
{
  public class Enum
  {
    /// <summary>
    /// Used when turning the robot
    /// </summary>
    public enum Direction
    {
      LEFT,
      RIGHT
    }

    /// <summary>
    /// The currently supported orientations the robot can face
    /// </summary>
    public enum Orientation
    {
      NORTH,
      EAST,
      SOUTH,
      WEST
    }

    /// <summary>
    /// The currently supported actions the robot can undertake
    /// </summary>
    public enum ActionType
    {
      PLACE,
      MOVE,
      LEFT,
      RIGHT,
      REPORT,
      EXIT
    }
  }
}
