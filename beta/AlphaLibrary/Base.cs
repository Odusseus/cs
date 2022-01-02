using System;

namespace Cs.AlphaLibrary;
  public static class Base
  {
    public static int Age(this DateTime DateOfBirth)
    {
      return 0;
    }

    public static DateTime? ToDate(this string dateIn)
    {
      if(dateIn.Length != 10)
      {
        return null;
      }

      string day = dateIn.Substring(0, 2);
      bool isInt = int.TryParse(day, out int dayInt);
      if(!isInt)
      {
        return null;
      }

      if(dayInt < 1 || dayInt > 31)
      {
        return null;
      }

      string month = dateIn.Substring(3, 2);
      
      isInt = int.TryParse(month, out int monthInt);
      if(!isInt)
      {
        return null;
      }

      if(monthInt < 1 || monthInt > 12)
      {
        return null;
      }

      string year = dateIn.Substring(6, 4);
      isInt = int.TryParse(year, out int yearInt);
      if(!isInt)
      {
        return null;
      }
      
      if(yearInt < 1 || yearInt > 9999)
      {
        return null;
      }

      try
      {
        DateTime dateTime = new DateTime(yearInt, monthInt, dayInt);
        return dateTime;
      }
      catch
      {
        return null;
      }
    }
  }