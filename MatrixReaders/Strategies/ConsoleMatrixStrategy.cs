using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class ConsoleMatrixStrategy : MatrixStringRead
    {
        private readonly uint matrixSize;
        public ConsoleMatrixStrategy()
        {
            do
            {
                Console.Write("Please, enter size of matrix A: ");
            } while (!uint.TryParse(Console.ReadLine(), out matrixSize));
        }

        public override double[][] GetMatrixA()
        {
            Console.WriteLine("Please, enter elements of the matrix A line by line:");
            List<string> list = new List<string>();
            for (int i = 0; i < matrixSize; i++)
            {
                list.Add(Console.ReadLine());
            }
            return converter.ConvertIntoMatrix(list);
        }

        public override double[] GetMatrixB()
        {
            Console.WriteLine("Please, enter elements of the matrix B as a line:");
            return converter.ConvertIntoVector(Console.ReadLine());
        }
    }
}
