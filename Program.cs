namespace FibonacciSequenceGenerator
{
    class Program
    {
        private static int sequenceLength;
        private static ulong[] fibonacciSequence;

        static void Main(string[] args)
        {
            // selecting how many numbers in the sequence to generate
            SelectSequenceLength();
            // saving generated values to array for later use
            fibonacciSequence = GenerateFibonacciSequence(sequenceLength);

            foreach (int num in fibonacciSequence)
            {
                Console.Write(num + " ");
            }
        }

        private static void SelectSequenceLength()
        {
            bool loopEnable = true;
            
            Console.WriteLine("Select the length of the generated Fibonacci sequence:");
            while (loopEnable)
            {
                if (SimpleConsoleFunctions.ParseIntEC(out sequenceLength))
                {
                    if (sequenceLength < 1)
                    {
                        Console.WriteLine("Please enter a value greater than 0");
                    }
                    else
                    {
                        // valid number entered, continue the program
                        loopEnable = false;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }

        // my function
        private static ulong[] GenerateFibonacciSequence(int length)
        {
            ulong[] sequence = new ulong[length];
            // explicitly defining first value in sequence
            sequence[0] = 0;

            if (length > 1)
            {
                // explicitly defining second value if sequence length is 2 or more
                sequence[1] = 1;
                for (int i = 2; i < length; i++)
                {
                    sequence[i] = sequence[i - 1] + sequence[i - 2];
                }
            }

            return sequence;
        }

        // GPT function
        static int[] FibonacciSequence(int count)
        {
            int[] fibonacci = new int[count];
            fibonacci[0] = 0;

            if (count > 1)
                fibonacci[1] = 1;

            for (int i = 2; i < count; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci;
        }
    }
}