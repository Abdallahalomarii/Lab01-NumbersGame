using System;

namespace NumberGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Call the StartSequence method
                StartSequence();
            }
            catch (Exception ex)
            {
                // When the user enters something wrong
                Console.WriteLine($"You did something wrong: {ex}");
            }
            finally
            {
                // Finally block will always appear
                Console.WriteLine("Program is completed");
            }
        }

        static void StartSequence()
        {
            try
            {
                // Ask the user to enter the size of the array
                Console.WriteLine("Enter the size of the array (the number should be greater than zero): ");
                int size = Int32.Parse(Console.ReadLine());

                // Initialize the numbers array with the given size
                int[] numbers = new int[size];

                // Check if the size is 1 because we have methods using more than one element in the array
                if (size == 1)
                {
                    // Throw an exception to the user
                    throw new Exception("The array size cannot be 1!");
                }

                // Call the Populate method to fill the array with user input
                numbers = Populate(numbers);

                // Calculate the sum of the array elements
                int sum = GetSum(numbers);

                // Get a random index from the user and calculate the product
                int Product = GetProduct(numbers, sum);

                // Calculate the quotient by dividing the product by a user-entered number
                decimal Quotient = GetQuotient(Product);

                // Print the size of the array
                Console.WriteLine($"Your array size is: {size}");

                // Print the array elements
                Console.Write("Your Array elements are: ");
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
                Console.WriteLine();

                // Print the sum of the array
                Console.WriteLine($"The sum of the array is: {sum}");

                // Print the product of the sum and the random index
                Console.WriteLine($"{sum} * {Product / sum} = {Product}");

                // Print the quotient of the product divided by the user input
                Console.WriteLine($"{Product} / {Product / Quotient} = {Quotient}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"You entered a non-integer value: {ex}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"You entered a huge number: {ex}");
            }
        }

        static int[] Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Please enter number {i + 1} of {numbers.Length}: ");
                string inputString = Console.ReadLine();
                int inputNumber = Int32.Parse(inputString);
                numbers[i] = inputNumber;
                Console.WriteLine($"You entered number: {numbers[i]}");
            }

            return numbers;
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            if (sum < 20)
            {
                throw new Exception($"Value of sum ({sum}) in the array is too low!");
            }

            return sum;
        }

        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine($"Please select a random number from 1 to {numbers.Length}: ");
            int randomIndex = Int32.Parse(Console.ReadLine()) - 1;

            if (randomIndex < 0 || randomIndex >= numbers.Length)
            {
                throw new IndexOutOfRangeException("You entered a number that is not a valid index in the array.");
            }

            int product = sum * numbers[randomIndex];
            return product;
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Enter a number to divide the product ({product}) by: ");
            int divide = Int32.Parse(Console.ReadLine());

            if (divide == 0)
            {
                Console.WriteLine("You divided by zero.");
                return 0;
            }

            decimal quotient = decimal.Divide(product, divide);
            return quotient;
        }
    }
}
