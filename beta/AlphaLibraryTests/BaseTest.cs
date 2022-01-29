using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Cs.AlphaLibrary;
using System;
using System.Globalization;
using System.Diagnostics;
using System.Threading;

namespace Cs.AlphaLibraryTest;

[TestClass]
public class UnitTest1
{
  [TestMethod]
  public void IsTrue()
  {
    var isTrue = true;

    Assert.IsTrue(isTrue);
    isTrue.Should().BeTrue();
  }

  [DataTestMethod]
  [DataRow("01-02-2021", "01-02-2021", true)]
  [DataRow("01-0A-2021", "01-01-0001", false)]
  public void IsDateTest(string dateString, string assertDateString, bool assertIsDate)
  {
    DateTime? assertDate = null;
    if (assertDateString != null)
    {
      assertDate = DateTime.ParseExact(assertDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    }

    #pragma warning disable 0612
    bool isDate = dateString.ToDate(out DateTime date);

    date.Should().Be(assertDate);
    isDate.Should().Be(assertIsDate);
  }

  [DataTestMethod]
  [DataRow("01-02-2021", "01-02-2021", true)]
  [DataRow("01-0A-2021", "01-01-0001", false)]
  public void TryToDateTest(string dateString, string assertDateString, bool assertIsDate)
  {
    DateTime? assertDate = null;
    if (assertDateString != null)
    {
      assertDate = DateTime.ParseExact(assertDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    }

    bool isDate = dateString.TryToDate(out DateTime date);

    date.Should().Be(assertDate);
    isDate.Should().Be(assertIsDate);
  }

  [DataTestMethod]
  [DataRow("16-02-1968", 53)]
  [DataRow("22-10-1969", 52)]
  [DataRow("02-02-2003", 18)]
  public void AgeTest(string dateString, int assertAge)
  {
    DateTime date = DateTime.MinValue;
    if (dateString != null)
    {
      date = DateTime.ParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    }

    #pragma warning disable 0618
    var age = date.Age();

    age.Should().Be(assertAge);
  }

  [DataTestMethod]
  [DataRow("16-02-1968", 53)]
  [DataRow("22-10-1969", 52)]
  [DataRow("02-02-2003", 18)]
  public void GetAgeTest(string dateString, int assertAge)
  {
    DateTime date = DateTime.MinValue;
    if (dateString != null)
    {
      date = DateTime.ParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    }

    var age = date.GetAge();

    age.Should().Be(assertAge);
  }

  [TestMethod]
  public void GetAgeMin5YearTest()
  {
    const int year = 5;

    DateTime date = DateTime.Today.AddYears(-year);

    var age = date.GetAge();

    age.Should().Be(year);
  }

  [TestMethod]
  public void GetAgeOneMonthOldTest()
  {
    const int month = 1;
    DateTime date = DateTime.Today.AddMonths(-month);

    var age = date.GetAge();

    age.Should().Be(0);
  }

  [TestMethod]
  public void GetAgeOneYearAndOneDayMonthOldTest()
  {
    const int day = 1;
    DateTime date = DateTime.Today.AddYears(-1).AddDays(+day);

    var age = date.GetAge();

    age.Should().Be(0);
  }

  [TestMethod]
  public void GetAgeBirthTodayTest()
  {
    DateTime date = DateTime.Today;

    var age = date.GetAge();

    age.Should().Be(0);
  }

  [DataTestMethod]
  [DataRow("", 0)]
  [DataRow(null, 0)]
  [DataRow("22", 1)]
  [DataRow("02-02", 2)]
  [DataRow("02-02-2003", 3)]
  [DataRow("02.02-2003", 3)]
  [DataRow("02X02Y2003", 3)]
  [DataRow("02X02Y2003Z", 3)]
  public void ToIntListTest(string dateString, int assertCountPart)
  {

    var list = dateString.ToStringIntList();

    list.Count.Should().Be(assertCountPart);
  }
}