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
    [DataRow("01-02-2021", "01-02-2021")]
    [DataRow("01-0A-2021", null)]
    public void IsDate(string dateString, string? assertDateString)
    {
        DateTime? assertDate = null;
        if(assertDateString != null)
        {
            assertDate = DateTime.ParseExact(assertDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        DateTime? date = dateString.ToDate();

        date.Should().Be(assertDate);
    }
}