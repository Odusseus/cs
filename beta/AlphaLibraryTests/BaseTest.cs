using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Cs.AlphaLibrary;
using System;

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

    [TestMethod]
    public void IsDate()
    {
        var dateString = "01-02-2021";

        DateTime? date = dateString.ToDate();

        date.Should().Be(new DateTime(2021,03,01));
    }
}