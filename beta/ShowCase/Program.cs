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
            var isDate = input.ToDate(out DateTime dateIn);
            string message = string.Empty;
            if(!isDate)
            {
              message = $" {input} is not a valide date dd-mm-yyyy.";
             Console.WriteLine(message);
            }
            else
            {
              int age = dateIn.Age();
              Console.WriteLine($"Date of birth {dateIn.Date}, age is " + $"{(age)}.");

            }
        } while (true);
        return;
    }
}
