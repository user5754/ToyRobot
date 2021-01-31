namespace ToyRobot.Tabletop
{
  /// <summary>
  /// Contains the methods related to the table top
  /// </summary>
  public class Tabletop : ITabletop
  {
    private const int MIN_SIZE = 0;
    private const int MAX_SIZE = 4;

    private int xPosition;
    private int yPosition;
    private Enum.Orientation orientation;

    public Tabletop()
    {
    }

    /// <summary>
    /// Verifies the proposed move is still within the bounds of the table
    /// </summary>
    /// <param name="x">The X coordinate</param>
    /// <param name="y">The Y coordinate</param>
    /// <returns>True if the move would result in the robot staying on the table. Otherwise False</returns>
    private bool MoveIsValid(int x, int y)
    {
      return x.Between(MIN_SIZE, MAX_SIZE) && y.Between(MIN_SIZE, MAX_SIZE);
    }

    /// <summary>
    /// Used to place the robot on the table
    /// </summary>
    /// <param name="x">The X coordinate</param>
    /// <param name="y">The Y coordinate</param>
    /// <param name="o">The initial orientation for the robot</param>
    /// <returns>Empty string if robot successfully placed, otherwise an error message</returns>
    public string Place(int x, int y, Enum.Orientation o)
    {
      string result = string.Empty;
      if (MoveIsValid(x, y))
      {
        xPosition = x;
        yPosition = y;
        orientation = o;
      }
      else
      {
        result = Message.OUT_OF_BOUNDS_MESSAGE;
      }

      return result;
    }

    /// <summary>
    /// Used to turn the robot
    /// </summary>
    /// <param name="direction">Used to determine if the robot should turn left or right</param>
    /// <returns></returns>
    public string ChangeDirection(Enum.Direction direction)
    {
      int offset = direction.Equals(Enum.Direction.LEFT) ? 3 : 1;
      orientation = (Enum.Orientation)(((int)orientation + offset) % 4);

      return string.Empty;
    }

    /// <summary>
    /// Moves the robot forward one space in the direction it is currently facing if there
    /// is room
    /// </summary>
    /// <returns>Empty string if robot successfully moved, otherwise an error message</returns>
    public string Move()
    {
      int x = xPosition;
      int y = yPosition;

      switch (orientation)
      {
        case Enum.Orientation.NORTH:
          y++;
          break;
        case Enum.Orientation.EAST:
          x++;
          break;
        case Enum.Orientation.SOUTH:
          y--;
          break;
        case Enum.Orientation.WEST:
          x--;
          break;
        default:
          throw new System.Exception("Invalid orientation");
      }

      return Place(x, y, orientation);
    }

    /// <summary>
    /// Reports the robot's current position
    /// </summary>
    /// <returns>The robot's current position</returns>
    public string Report()
    {
      return $"{xPosition} {yPosition} {orientation}";
    }
  }
}
