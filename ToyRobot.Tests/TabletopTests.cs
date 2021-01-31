using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ToyRobot.Tabletop;

namespace ToyRobot.Tests
{
  [TestFixture]
  class TabletopTests
  {
    private ITabletop _tabletop;

    [SetUp]
    public void SetUp()
    {
      var serviceProvider = new ServiceCollection()
            .AddTransient<ITabletop, Tabletop.Tabletop>()
            .BuildServiceProvider();

      _tabletop = serviceProvider.GetService<ITabletop>();
    }

    [Test]
    public void PlaceRobotInLowerCorner()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      Assert.AreEqual(_tabletop.Report(), "0 0 NORTH");
    }

    [Test]
    public void PlaceRobotInUpperCorner()
    {
      _tabletop.Place(4, 4, Enum.Orientation.SOUTH);
      Assert.AreEqual(_tabletop.Report(), "4 4 SOUTH");
    }

    [Test]
    public void PlaceRobotInMiddle()
    {
      _tabletop.Place(2, 2, Enum.Orientation.SOUTH);
      Assert.AreEqual(_tabletop.Report(), "2 2 SOUTH");
    }

    [Test]
    public void InvalidPlaceCommandTooHighEdge()
    {
      Assert.AreEqual(_tabletop.Place(5, 1, Enum.Orientation.EAST), Message.OUT_OF_BOUNDS_MESSAGE);
    }

    [Test]
    public void InvalidPlaceCommandTooHigh()
    {
      Assert.AreEqual(_tabletop.Place(6, 1, Enum.Orientation.NORTH), Message.OUT_OF_BOUNDS_MESSAGE);
    }

    [Test]
    public void InvalidPlaceCommandTooLow()
    {
      Assert.AreEqual(_tabletop.Place(0, -1, Enum.Orientation.WEST), Message.OUT_OF_BOUNDS_MESSAGE);
    }

    [Test]
    public void TurnLeft()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      _tabletop.ChangeDirection(Enum.Direction.LEFT);
      Assert.AreEqual(_tabletop.Report(), "0 0 WEST");
    }

    [Test]
    public void TurnLeftTwice()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      _tabletop.ChangeDirection(Enum.Direction.LEFT);
      _tabletop.ChangeDirection(Enum.Direction.LEFT);
      Assert.AreEqual(_tabletop.Report(), "0 0 SOUTH");
    }

    [Test]
    public void TurnRight()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      _tabletop.ChangeDirection(Enum.Direction.RIGHT);
      Assert.AreEqual(_tabletop.Report(), "0 0 EAST");
    }

    [Test]
    public void TurnRightTwice()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      _tabletop.ChangeDirection(Enum.Direction.RIGHT);
      _tabletop.ChangeDirection(Enum.Direction.RIGHT);
      Assert.AreEqual(_tabletop.Report(), "0 0 SOUTH");
    }

    [Test]
    public void MoveOnce()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      _tabletop.Move();
      Assert.AreEqual(_tabletop.Report(), "0 1 NORTH");
    }

    [Test]
    public void MoveTurn()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      _tabletop.Move();
      _tabletop.ChangeDirection(Enum.Direction.LEFT);
      Assert.AreEqual(_tabletop.Report(), "0 1 WEST");
    }

    [Test]
    public void MoveTurnMove()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      _tabletop.Move();
      _tabletop.ChangeDirection(Enum.Direction.RIGHT);
      _tabletop.Move();
      Assert.AreEqual(_tabletop.Report(), "1 1 EAST");
    }

    [Test]
    public void MoveTurnInvalidMove()
    {
      _tabletop.Place(0, 0, Enum.Orientation.NORTH);
      _tabletop.Move();
      _tabletop.ChangeDirection(Enum.Direction.LEFT);
      Assert.AreEqual(_tabletop.Move(), Message.OUT_OF_BOUNDS_MESSAGE);
    }
  }
}
