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
        if(assertDateString != null)
        {
            assertDate = DateTime.ParseExact(assertDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        bool isDate = dateString.ToDate(out DateTime date);

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
        if(dateString != null)
        {
            date = DateTime.ParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        var age = date.Age();

        age.Should().Be(assertAge);
    }
}