using System;

namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Reading a mode choice
                uint inputChoice;
                do
                {
                    Console.WriteLine("Please, choose a mode for matrix input: \t1 - console | 2 - file | 3 - random");
                } while (!uint.TryParse(Console.ReadLine(), out inputChoice));

                // Choosing a strategy
                IMatrixReadStrategy matrixReadStrategy;
                switch (inputChoice)
                {
                    case 1:
                        matrixReadStrategy = new ConsoleMatrixStrategy();
                        break;
                    case 2:
                        matrixReadStrategy = new FileMatrixStrategy();
                        break;
                    case 3:
                        matrixReadStrategy = new RandomMatrixStrategy();
                        break;
                    default:
                        Console.WriteLine("Wrong input choice.");
                        continue;
                }

                double[][] A;
                double[] B;
                try
                {
                    A = matrixReadStrategy.GetMatrixA();
                    B = matrixReadStrategy.GetMatrixB();

                    // Checking convergence, A and B compatibility
                    CheckMatrix checkMatrix = new CheckMatrix();
                    if (!checkMatrix.IsSuitableForCalculation(A, B))
                    {
                        Console.WriteLine("Matrix doesn't have dominating diagonal. Trying to replace rows...");
                        LineReplacer lineReplacer = new LineReplacer();
                        lineReplacer.ReplaceRows(A);

                        // Showing new matrix
                        Console.WriteLine("\nAfter replacing:");
                        for (int i = 0; i < A.Length; i++)
                        {
                            for (int j = 0; j < A[i].Length; j++)
                            {
                                Console.Write($"{Math.Round(A[i][j], 3)}\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                double accuracy;
                do
                {
                    Console.Write("Please, enter accuracy: ");
                } while (!double.TryParse(Console.ReadLine(), out accuracy));

                // Main logic of the iterative method
                SimpleIterations simpleIterations = new SimpleIterations(A.Length);
                simpleIterations.Iterate(A, B, accuracy);

                // Showing results and errors
                Console.WriteLine("\nResult matrix:");
                for (int i = 0; i < simpleIterations.ResultX.Length; i++)
                {
                    Console.WriteLine($"x[{i + 1}]: {Math.Round(simpleIterations.ResultX[i], 3)}");
                }
                Console.WriteLine("\nErrors:");
                for (int i = 0; i < simpleIterations.ErrorX.Length; i++)
                {
                    Console.WriteLine($"x[{i + 1}]: {simpleIterations.ErrorX[i]}");
                }
                Console.WriteLine($"\nCount of iterations: {simpleIterations.IterationCount}");

                Console.Write("\nContinue? 'yes' or 'no': ");
                if (Console.ReadLine() != "yes")
                {
                    break;
                }
            }
        }
    }
}
