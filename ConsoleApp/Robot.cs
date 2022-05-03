using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
  public class Robot
  {
    public string Name { get; }
    public int BatteryLevel { get; }
    public Robot(string name, int batteryLevel)
    {
      Name = name;
      BatteryLevel = batteryLevel;
    }
  }
}
