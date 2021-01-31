using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ToyRobot.Robot;
using ToyRobot.Tabletop;

namespace ToyRobot.Tests
{
  [TestFixture]
  class RobotTests
  {
    private IRobot _robot;

    [SetUp]
    public void SetUp()
    {
      var serviceProvider = new ServiceCollection()
            .AddTransient<ITabletop, Tabletop.Tabletop>()
            .AddTransient<IRobot, Robot.Robot>()
            .BuildServiceProvider();

      _robot = serviceProvider.GetService<IRobot>();
    }

    [Test]
    public void XYMissingFromPlace()
    {
      Assert.AreEqual(_robot.ProcessCommand("PLACE 0 NORTH"), "Input string was not in a correct format.");
    }

    [Test]
    public void InvalidOrientationInPlace()
    {
      string invalidOrientation = "NORTHWEST";
      Assert.AreEqual(_robot.ProcessCommand($"PLACE 0 0 {invalidOrientation}"), $"Requested value '{invalidOrientation}' was not found.");
    }

    [Test]
    public void MoveWhenNotPlaced()
    {
      Assert.AreEqual(_robot.ProcessCommand("MOVE"), Message.NOT_YET_PLACED_MESSAGE);
    }

    [Test]
    public void TurnLeftWhenNotPlaced()
    {
      Assert.AreEqual(_robot.ProcessCommand("LEFT"), Message.NOT_YET_PLACED_MESSAGE);
    }

    [Test]
    public void TurnRightWhenNotPlaced()
    {
      Assert.AreEqual(_robot.ProcessCommand("RIGHT"), Message.NOT_YET_PLACED_MESSAGE);
    }

    [Test]
    public void ReportWhenNotPlaced()
    {
      Assert.AreEqual(_robot.ProcessCommand("REPORT"), Message.NOT_YET_PLACED_MESSAGE);
    }

    [Test]
    public void PlaceRobot()
    {
      _robot.ProcessCommand("PLACE 0 0 NORTH");
      Assert.AreEqual(_robot.ProcessCommand("REPORT"), "0 0 NORTH");
    }
  }
}
