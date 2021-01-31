namespace ToyRobot
{
  public static class Extension
  {
    /// <summary>
    /// Used to determine if an integer is between two numbers
    /// </summary>
    /// <param name="num">The number that needs to be between the upper and lower bounds</param>
    /// <param name="lower">The lower bound</param>
    /// <param name="upper">The upper bound</param>
    /// <param name="inclusive">If the upper and lower bounds are inclusive</param>
    /// <returns>True or False depending on ff the supplied integer is between the upper and lower bounds</returns>
    public static bool Between(this int num, int lower, int upper, bool inclusive = true)
    {
      return inclusive ?
        lower <= num && num <= upper :
        lower < num && num < upper;
    }
  }
}
