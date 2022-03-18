using System;

namespace Lab_1
{
    public class LineReplacer
    {
        public void ReplaceRows(double[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int dominatingIndex = FindDominatingIndex(A[i]);
                if (dominatingIndex == -1)
                {
                    throw new Exception("No dominating diagonal can be found.");
                }
                else if (dominatingIndex != i)
                {
                    if (dominatingIndex == FindDominatingIndex(A[dominatingIndex]))
                    {
                        throw new Exception("No dominating diagonal can be found.");
                    }
                    double[] temporaryRow = A[i];
                    A[i] = A[dominatingIndex];
                    A[dominatingIndex] = temporaryRow;
                }
            }
        }

        public int FindDominatingIndex(double[] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (Math.Abs(row[i]) > CalculateSum(row, i))
                    return i;
            }

            return -1;
        }

        private double CalculateSum(double[] row, int index)
        {
            double sum = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if (i != index)
                    sum += Math.Abs(row[i]);
            }
            return sum;
        }
    }
}
