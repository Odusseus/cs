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

      return DateTime.Today.Date;
    }

  }