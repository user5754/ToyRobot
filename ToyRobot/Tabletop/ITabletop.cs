namespace ToyRobot.Tabletop
{
  public interface ITabletop
  {
    public string Place(int x, int y, Enum.Orientation f);
    public string Report();
    public string ChangeDirection(Enum.Direction direction);
    public string Move();
  }
}
