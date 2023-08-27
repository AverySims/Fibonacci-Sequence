using System.Numerics;
using ConsoleFunctions;
using GenericParse;

namespace FibonacciSequence
{
	class Program
	{
		// user input
		public static int StepCount;

		// StepLimit is an arbitrary cap on how far we can generate before count the input as "out of range."
		// it seems that it calculates correctly at any StepLimit. However, the console display can sometimes "break"
		// and produce a *very* long line of text making it look line it's producing an incorrect result.
		public static int StepLimit = 500;

		static void Main(string[] args)
		{
			bool loopMain = true;

			while (loopMain)
			{
				// selecting how many numbers in the sequence to generate
				SelectSequenceLength();

				// saving generated values to array for later use
				BigInteger[] fibonacci = GenerateFibonacciSequenceB(StepCount);
				
				ConsoleHelper.PrintBlank();
				for (int i = 0; i < StepCount; i++)
				{
					// formatting the values to make them more readable
					string readableInt = fibonacci[i].ToString("#,##0");
					Console.WriteLine($"{i + 1}. {readableInt}");
				}
				ConsoleHelper.PrintBlank();

				ConsoleHelper.SelectEndingAction(out loopMain);
			}
		}

		private static void SelectSequenceLength()
		{
			bool loopValid = false;

			Console.Write("Enter your desired Fibonacci sequence length: ");
			do
			{
				StepCount = GenericReadLine.TryReadLine<int>();
				if (StepCount >= 1 && StepCount <= StepLimit)
				{
					// valid number entered, continue the program
					loopValid = true;
				}
				else
				{
					Console.Write($"Please choose a valid length (min: 1, max: {StepLimit}): ");
				}
			} while (!loopValid);
		}

		private static BigInteger[] GenerateFibonacciSequenceB(int length)
		{
			// defining the maximum size of the generated array
			BigInteger[] sequence = new BigInteger[length];

			// explicitly defining first value in sequence
			sequence[0] = 0;

			if (length > 1)
			{
				// explicitly defining second value if sequence length is 2 or more
				sequence[1] = 1;

				// generating via formula after 2 values have been defined
				for (int i = 2; i < length; i++)
				{
					sequence[i] = sequence[i - 1] + sequence[i - 2];
				}
			}
			return sequence;
		}
	}
}