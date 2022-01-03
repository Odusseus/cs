using System;

namespace Cs.AlphaLibrary;
public static class Base
{
  [Obsolete]
  public static int Age(this DateTime dateOfBirth)
  {
    var totalDays = DateTime.Today.Date.Subtract(dateOfBirth).TotalDays;
    var year = (int)Math.Truncate(totalDays / 365);

    return year;
  }
  public static int GetAge(this DateTime dateOfBirth)
  {
    var year = dateOfBirth.Year;
    var month = dateOfBirth.Month;
    var day = dateOfBirth.Day;

    var age = DateTime.Today.Year - year;

    if (DateTime.Today.Month < month)
    {
      age--;
    }
    else if (DateTime.Today.Month == month
            && DateTime.Today.Day < day)
    {
      age--;
    }

    return age;
  }

  public static bool ToDate(this string dateIn, out DateTime dateOut)
  {
    if (dateIn.Length != 10)
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    string day = dateIn.Substring(0, 2);
    bool isInt = int.TryParse(day, out int dayInt);
    if (!isInt)
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    if (dayInt < 1 || dayInt > 31)
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    string month = dateIn.Substring(3, 2);

    isInt = int.TryParse(month, out int monthInt);
    if (!isInt)
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    if (monthInt < 1 || monthInt > 12)
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    string year = dateIn.Substring(6, 4);
    isInt = int.TryParse(year, out int yearInt);
    if (!isInt)
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    if (yearInt < 1 || yearInt > 9999)
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

  public static bool TryToDate(this string dateIn, out DateTime dateOut)
  {
    var list = dateIn.ToStringIntList();
    if (list.Count != 3)
    {
      dateOut = DateTime.MinValue;
      return false;
    }
   
    int year = 0;
    int month = 0;
    int day = 0;

    if(list[0].Length == 4 && list[1].Length == 2 && list[2].Length == 2)
    {
      year = int.Parse(list[0]);
      month = int.Parse(list[1]);
      day = int.Parse(list[2]);
    }
    else if(list[0].Length == 2 && list[1].Length == 2 && list[2].Length == 4)
    {
      day = int.Parse(list[0]);
      month = int.Parse(list[1]);
      year = int.Parse(list[2]);
    }
    else 
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    
    if (day < 1 || day > 31)
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    if (month < 1 || month > 12)
    {
      dateOut = DateTime.MinValue;
      return false;
    }
    
    if (year < 1 || year > 9999)
    {
      dateOut = DateTime.MinValue;
      return false;
    }

    try
    {
      DateTime dateTime = new DateTime(year, month, day);
      dateOut = dateTime;
      return true;
    }
    catch
    {
      dateOut = DateTime.MinValue;
      return false;
    }
  }

  public static List<string> ToStringIntList(this string stringIn)
  {
    List<string> list = new List<string>();

    // End character to close the string.
    if(string.IsNullOrEmpty(stringIn))
    {
      return list;
    }
    else
    {
      stringIn += "E";
    }

    string newNumberString = string.Empty;
    foreach (char character in stringIn)
    {
      if (int.TryParse(character.ToString(), out int integer))
      {
        newNumberString += character;
      }
      else
      {
        if(newNumberString != string.Empty)
        {
          list.Add(newNumberString);
        }
        newNumberString = string.Empty;
      }
    }

    return list;
  }
}