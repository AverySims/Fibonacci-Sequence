namespace FibonacciSequenceGenerator
{
	// test comment
	class Program
	{
		private static int sequenceLength;
		private static ulong[] fibonacciSequence;
		
		static void Main(string[] args)
		{
			bool loopMain = true;
			
			while (loopMain)
			{
				// selecting how many numbers in the sequence to generate
				SelectSequenceLength();
				// saving generated values to array for later use
				fibonacciSequence = GenerateFibonacciSequence(sequenceLength);
				
				SimpleConsoleFunctions.PrintBlank();
				Console.WriteLine("Sequence start:");
				for (int i = 0; i < sequenceLength; i++)
				{
					Console.WriteLine($"{i+1}. {fibonacciSequence[i]}");
				}
				Console.WriteLine("Sequence end");
				SimpleConsoleFunctions.PrintBlank();
				
				SimpleConsoleFunctions.SelectEndingAction(out loopMain);
				
			}
			
		}

		private static void SelectSequenceLength()
		{
			bool loopEnable = true;
			
			Console.WriteLine("Select the length of the generated Fibonacci sequence:");
			while (loopEnable)
			{
				// max is 47 steps, ulong begins to break after this
				if (SimpleConsoleFunctions.ParseIntEC(out sequenceLength))
				{
					// check if length is TOO high
					if (sequenceLength > 47)
					{
						Console.WriteLine("Length too high, please enter a lower length (max 47)");
					}
					// check if length is TOO low
					else if (sequenceLength < 1)
					{
						// invalid number entered, return to start of loop for new number
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
					// TryParse function determined input as invalid (not an int)
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