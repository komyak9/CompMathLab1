using System;

namespace Lab_1
{
    public class MatrixRandomFiller
    {
        private readonly Random random = new Random();
        public void FillRandomMatrix(double[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                FillRandomVector(matrix[i]);

                while (!IsDominantSuitable(matrix[i], i))
                {
                    matrix[i][i] = random.NextDouble() * matrix.Length * 200 - matrix.Length * 100;
                }
            }

        }

        public void FillRandomVector(double[] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = random.NextDouble() * 200 - 100;
            }
        }

        private bool IsDominantSuitable(double[] row, int i)
        {
            double sum = 0;
            for (int j = 0; j < row.Length; j++)  // let's check for dominant diagonal during filling to save time
            {
                if (i != j)
                {
                    sum += Math.Abs(row[j]);
                }
            }

            return row[i] > sum;
        }
    }
}
