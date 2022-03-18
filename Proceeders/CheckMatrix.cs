using System;

namespace Lab_1
{
    public class CheckMatrix
    {
        public bool IsSuitableForCalculation(double[][] A, double[] B)
        {
            CheckSquare(A);
            CheckCompatibility(A, B);
            CheckZeroDiagonal(A);
            return IsConvergent(A);
        }

        private void CheckSquare(double[][] A)
        {
            if (A.Length != A[0].Length)
                throw new Exception("Matrix A is not squared.");
        }

        private void CheckCompatibility(double[][] A, double[] B)
        {
            if (A.Length != B.Length)
                throw new Exception("Matrixes A and B are not size-compatible.\nSize of A: " + A.Length + "\tSize of B: " + B.Length);
        }

        private void CheckZeroDiagonal(double[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            { 
                if (A[i][i] == 0)
                    throw new Exception("Matrix A contains 0 in the diagonal.");  // it's impossible due to future division
            }
        }

        private bool IsConvergent(double[][] A)
        {
            double sum;
            for (int i = 0; i < A.Length; i++)
            {
                sum = 0;
                for (int j = 0; j < A[i].Length; j++)
                {
                    if (i != j)
                    {
                        sum += Math.Abs(A[i][j]);
                    }
                }

                if (Math.Abs(A[i][i]) < sum)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
