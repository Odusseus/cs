using Cs.AlphaLibrary;

class Program
{
    static void Main(string[] args)
    {
       do
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            Console.WriteLine($"Input: {input}");
            var dateIn = input.ToDate();
            string message = string.Empty;
            if(dateIn == null)
            {
              message = "is not a valide date dd-mm-yyyy.";
            }
            Console.WriteLine("Age ? " +
                 $"{(input)}");
            Console.WriteLine(message);
        } while (true);
        return;
    }
}
