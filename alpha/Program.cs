using System;

namespace Osusseus.Alpha {
  public static class Program {
    public static void Main (string[] args){
        Console.WriteLine("Hello, World! Here Pascal!");

        var box = new Box("Test");

        Console.WriteLine(box.name);

    }
  }
} 
