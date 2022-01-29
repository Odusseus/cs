using Cs.AlphaLibrary;

class Program
{
    static void Main(string[] args)
    {
var builder = WebApplication.CreateBuilder(args);

       do
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            Console.WriteLine($"Input: {input}");
            var isDate = input.TryToDate(out DateTime dateIn);
            string message = string.Empty;
            if(!isDate)
            {
              message = $" {input} is not a valide date dd-mm-yyyy.";
             Console.WriteLine(message);
            }
            else
            {
              int age = dateIn.GetAge();
              Console.WriteLine($"Date of birth {dateIn.Date}, age is " + $"{(age)}.");

            }
        } while (true);
        return;
    }
}
