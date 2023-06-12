namespace NumberGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"You did something wrong {ex}");
            }
            finally
            {
                Console.WriteLine("Program is completed");
            }


        }
        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Enter a number greater than zero");
                //int size = Convert.ToInt32(Console.ReadLine());
                int size = Int32.Parse(Console.ReadLine());
                int[] numbers = new int[size];
                if (size == 1)
                {
                    throw new Exception("The array size connot be 1 Only!");

                }
                numbers = Populate(numbers);
                int sum = GetSum(numbers);
                int Product = GetProduct(numbers, sum);
                decimal Quotient = GetQuotient(Product);
                Console.WriteLine($"Your array size {size}");
                Console.Write("Your Array element is : ");
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine($"the sum of array is {sum}");
                Console.WriteLine($"{sum} * {Product / sum} = {Product} ");
                Console.WriteLine($" {Product} / {Product / Quotient} = {Quotient}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"You entered not an integer  {ex}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"You inputed a huge Number {ex}");
            }

        }
        static int[] Populate(int[] numbers)
        {
            string inputString = "";
            int inputNumber = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Please enter a number {i + 1} of {numbers.Length}");
                inputString = Console.ReadLine();
                inputNumber = Int32.Parse(inputString);
                numbers[i] = inputNumber;
                Console.WriteLine($"You Enterd number :  {numbers[i]}");
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
                throw new Exception($"Value of sum: {sum} in array is too low! ");
            }


            return sum;
        }

        static int GetProduct(int[] numbers, int sum)
        {

            Console.WriteLine($"Please Select Random Number  From 1 to {numbers.Length}");
            int randomIndex = Int32.Parse(Console.ReadLine()) -1;
            if (randomIndex < 0 || randomIndex >= numbers.Length)
            {
                throw new IndexOutOfRangeException("You inputed number which is not index in array and it is out of Range");
            }
            int product = sum * numbers[randomIndex];
            return product;
        }
        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"enter a number to divide the product :{product} by!");
            int divide = Convert.ToInt32(Console.ReadLine());
            if (divide == 0)
            {
                Console.WriteLine("You Divided by Zero");
                return 0;
            }
            decimal quotient = decimal.Divide(product, divide);
            return quotient;
        }

    }
}