using System;
using System.Collections.Generic;
using ConsoleApp;
using Xunit;
using System.Collections.Immutable;
using System.Linq;

namespace UnitTests;

public class UnitTest1
{
  [Fact]
  public void Test1()
  {

    var examples = new Examples();

    var five = examples.getFive();

    var res1 = examples.Add(2, 3);



    Assert.Equal(res1, five);

  }

  [Fact]
  public void Test2()
  {
    var t = new Boken();
    var list = new List<int> { -100, 63, 30, 45, 1, 1000, -23, -67, 1, 2, 56, 75, 975, 432, -600, 193, 85, 12 };
    var expected = new List<int> { -600, -100, -67, -23, 1, 1, 2, 12, 30, 45, 56, 63, 75, 85, 193, 432, 975, 1000 };
    var actual = t.QuickSort(list);
    Assert.Equal(expected, actual);

  }

  [Fact]
  public void ShouldFilterByOdd()
  {
    var e = new Examples();

    var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

    var expected = new List<int>() { 2, 4, 6, 8 };

    var actual = e.FilterByOdd(list, 2);

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void IncreseNumbersInArrayBasedOnX()
  {
    var e = new Boken();

    var list = new List<int>() { 1, 2, 3 };

    var actual = e.IncreseBy(list, 10);

    var expected = new List<int>() { 10, 20, 30 };

    Assert.Equal(expected, actual);
  }

  [Fact]
  public void TestingExtensions()
  {
    var numbers = Enumerable.Range(1, 10);

    var isOdds = numbers.FilterWithWhereExpressions(x => x % 2 != 0);
    var odds = new List<int>() { 1, 3, 5, 7, 9 };

    var dubbels = numbers.TransformWithOperation(x => x * 2);
    var dubs = new List<int>() { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

    var added = numbers.TransformWithOperation(Extensions.AddTo(3).Compose(Extensions.RemoveTo(1)));

    var addedActual = new List<int>() { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

    Assert.Equal(isOdds, odds);
    Assert.Equal(dubbels, dubs);
    Assert.Equal(added, addedActual);
  }

  [Fact]
  public void TestingPipe()
  {

    // normal pipe
    var num = 10;
    var newNum = num.PipeAddTo(10).PipeAddTo(10);
    var actual = 30;

    // with lamba
    Func<int, int> timesTwo = x => x * 2;
    Func<int, int> add10 = x => x + 10;

    int value = 5;
    int resultA = value.PerformOperation(timesTwo).PerformOperation(add10).PerformOperation(x => x + 3);

    var actualValue = 23;

    Assert.Equal(newNum, actual);
    Assert.Equal(resultA, actualValue);
  }

  [Fact]
  public void TestingCustomReduceFunctions()
  {
    var robot1 = new Robot(name: "Robot1", batteryLevel: 60);
    var robot2 = new Robot(name: "Robot2", batteryLevel: 45);
    var robot3 = new Robot(name: "Robot3", batteryLevel: 95);
    var robot4 = new Robot(name: "Robot4", batteryLevel: 27);

    ImmutableList<Robot> robots = ImmutableList.Create(new Robot[] { robot1, robot2, robot3, robot4 });

    var lowBattery = robots.Min(x => x.BatteryLevel);
    var highBattery = robots.Max(x => x.BatteryLevel);
    var minVal = 27;
    var highVal = 95;

    var totaltBatteryLevel = robots.Select(robot => robot.BatteryLevel).Aggregate((first, second) => first + second);
    var batteryVal = 60 + 45 + 95 + 27;

    Assert.Equal(lowBattery, minVal);
    Assert.Equal(highBattery, highVal);
    Assert.Equal(totaltBatteryLevel, batteryVal);
  }
}