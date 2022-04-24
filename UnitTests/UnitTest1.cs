using System;
using System.Collections.Generic;
using ConsoleApp;
using Xunit;

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
}