class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the first number:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int num2 = int.Parse(Console.ReadLine());

            int result = num1 / num2;
            Console.WriteLine($"Result: {result}");

            int[] numbers = { 1, 2, 3 };
            Console.WriteLine("Accessing array at index 5:");
            Console.WriteLine(numbers[5]);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error: Array index is out of bounds.");
        }
        finally
        {
            Console.WriteLine("Finally completed.");
        }

        ParseAndDivide();

        CustomException();

        Console.Read();
    }

    static void ParseAndDivide()
    {
        try
        {
            Console.WriteLine("Enter a number as a string:");
            string input = Console.ReadLine();

            // Outer try block - Parsing the string
            try
            {
                int parsedNumber = int.Parse(input);
                Console.WriteLine($"Parsed Number: {parsedNumber}");

                // Inner try block - Division operation
                try
                {
                    Console.WriteLine("Enter a divisor:");
                    int divisor = int.Parse(Console.ReadLine());
                    int result = parsedNumber / divisor;
                    Console.WriteLine($"Division Result: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input, not a valid integer.");
            }
        }
        finally
        {
            Console.WriteLine("Nested try-catch completed.");
        }
    }

    public class InvalidInputException : ApplicationException
    {
        public string InputValue { get; }
        public string ReasonForInvalidity { get; }

        public InvalidInputException(string message, string inputValue, string reason) : base(message)
        {
            InputValue = inputValue;
            ReasonForInvalidity = reason;
        }
    }

    static void CustomException()
    {
        try
        {
            Console.WriteLine("Enter the first number:");
            string input1 = Console.ReadLine();
            int num1 = ValidateInput(input1);

            Console.WriteLine("Enter the second number:");
            string input2 = Console.ReadLine();
            int num2 = ValidateInput(input2);

            // Perform division
            int result = num1 / num2;
            Console.WriteLine($"Result: {result}");
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Invalid Input: {ex.InputValue}");
            Console.WriteLine($"Reason: {ex.ReasonForInvalidity}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
    }

    // Method to validate input and throw InvalidInputException for invalid inputs
    static int ValidateInput(string input)
    {
        if (!int.TryParse(input, out int result))
        {
            throw new InvalidInputException("Input is not a valid integer.", input, "Non-numeric value provided.");
        }
        return result;
    }
}
