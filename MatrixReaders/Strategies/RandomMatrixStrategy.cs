using System;

namespace Lab_1
{
    public class RandomMatrixStrategy : IMatrixReadStrategy
    {
        private readonly uint matrixSize;
        private readonly MatrixRandomFiller matrixRandomFiller = new MatrixRandomFiller();

        public RandomMatrixStrategy()
        {
            do
            {
                Console.Write("Please, enter size of the matrixes: ");
            } while (!uint.TryParse(Console.ReadLine(), out matrixSize));
        }

        public double[][] GetMatrixA()
        {
            double[][] A = new double[matrixSize][];
            for (int i = 0; i < matrixSize; i++)
            {
                A[i] = new double[matrixSize];
            }
            matrixRandomFiller.FillRandomMatrix(A);
            return A;
        }

        public double[] GetMatrixB()
        {
            double[] B = new double[matrixSize];
            matrixRandomFiller.FillRandomVector(B);
            return B;
        }
    }
}
