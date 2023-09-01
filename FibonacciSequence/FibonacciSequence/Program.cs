using System.Numerics;
using ConsoleFunctions;
using GenericParse;

namespace FibonacciSequence
{
	class Program
	{
		// I've tested this with a StepLimit of 100, 500, and 1000. All of them produce the correct result. (I think)
		public static int StepLimit = 5000;
		public static int StepCount;

		static void Main(string[] args)
		{
			bool loopMain = true;

			while (loopMain)
			{
				// selecting how many numbers in the sequence to generate
				SelectSequenceLength();
				
				ConsoleHelper.PrintBlank();
				PrintFibonacci(StepCount);

				ConsoleHelper.SelectEndingAction(out loopMain);
			}
		}

		private static void SelectSequenceLength()
		{
			Console.Write("Enter your desired Fibonacci sequence length: ");
			while (true)
			{
				StepCount = GenericReadLine.TryReadLine<int>();
				if (StepCount >= 1 && StepCount <= StepLimit)
				{
					// valid number entered, break out of loop and continue
					break;
				}
				else
				{
					Console.Write($"Please choose a valid length (min: 1, max: {StepLimit}): ");
				}
			}
		}

		private static void PrintFibonacci(int n)
		{
			if (n >= 1)
			{
				Console.WriteLine(FormatFibonacci(1, 0));
			}
			if (n >= 2)
			{
				Console.WriteLine(FormatFibonacci(2, 1));
			}

			BigInteger a = 0;
			BigInteger b = 1;

			for (int i = 2; i < n; i++)
			{
				BigInteger next = a + b;
				Console.WriteLine(FormatFibonacci(i + 1, next));
				ConsoleHelper.PrintBlank();
				a = b;
				b = next;
			}
		}
		
		static string FormatFibonacci(int index, BigInteger value)
		{
			return $"{index}. {value.ToString("N").Replace(".00", "")}";
		}
	}
}