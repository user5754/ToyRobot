using NUnit.Framework;

namespace ToyRobot.Tests
{
  class ExtensionTests
  {
    [Test]
    public void NumberIsBetweenUpperAndLowerBounds()
    {
      Assert.IsTrue(5.Between(1, 10));
    }

    [Test]
    public void NumberIsNotBetweenUpperAndLowerBoundsUpper()
    {
      Assert.IsFalse(15.Between(1, 10));
    }

    [Test]
    public void NumberIsNotBetweenUpperAndLowerBoundsLower()
    {
      Assert.IsFalse((-15).Between(1, 10));
    }

    [Test]
    public void NumberIsBetweenUpperAndLowerBoundsUpperEdgeInclusive()
    {
      Assert.IsTrue(10.Between(1, 10));
    }

    [Test]
    public void NumberIsBetweenUpperAndLowerBoundsLowerEdgeInclusive()
    {
      Assert.IsTrue(1.Between(1, 10));
    }

    [Test]
    public void NumberIsNotBetweenUpperAndLowerBoundsUpperEdgeNotInclusive()
    {
      Assert.IsFalse(10.Between(1, 10, false));
    }

    [Test]
    public void NumberIsNotBetweenUpperAndLowerBoundsLowerEdgeNotInclusive()
    {
      Assert.IsFalse(1.Between(1, 10, false));
    }
  }
}
