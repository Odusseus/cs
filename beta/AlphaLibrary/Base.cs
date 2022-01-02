using System;

namespace Cs.AlphaLibrary;
  public static class Base
  {
    public static int Age(this DateTime dateOfBirth)
    {
      var totalDays = DateTime.Today.Date.Subtract(dateOfBirth).TotalDays;
      var year = (int) Math.Truncate(totalDays / 365);

      return year;
    }

    public static bool ToDate(this string dateIn, out DateTime dateOut)
    {
      if(dateIn.Length != 10)
      {
        dateOut = DateTime.MinValue;
        return false;
      }

      string day = dateIn.Substring(0, 2);
      bool isInt = int.TryParse(day, out int dayInt);
      if(!isInt)
      {
        dateOut = DateTime.MinValue;
        return false;
      }

      if(dayInt < 1 || dayInt > 31)
      {
        dateOut = DateTime.MinValue;
        return false;
      }

      string month = dateIn.Substring(3, 2);
      
      isInt = int.TryParse(month, out int monthInt);
      if(!isInt)
      {
        dateOut = DateTime.MinValue;
        return false;
      }

      if(monthInt < 1 || monthInt > 12)
      {
        dateOut = DateTime.MinValue;
        return false;
      }

      string year = dateIn.Substring(6, 4);
      isInt = int.TryParse(year, out int yearInt);
      if(!isInt)
      {
        dateOut = DateTime.MinValue;
        return false;
      }
      
      if(yearInt < 1 || yearInt > 9999)
      {
        dateOut = DateTime.MinValue;
        return false;
      }

      try
      {
        DateTime dateTime = new DateTime(yearInt, monthInt, dayInt);
        dateOut = dateTime;
        return true;
      }
      catch
      {
        dateOut = DateTime.MinValue;
        return false;
      }
    }
  }