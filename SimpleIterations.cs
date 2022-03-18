using System;

namespace Lab_1
{
    public class SimpleIterations
    {
        private readonly double[] resultX; // contains result X values after each iteration
        private readonly double[] errorX;  // contains result error for each X value after each iteration

        public SimpleIterations(int size)
        {
            resultX = new double[size]; // filling with starting X values (0) - default values for an empty array
            errorX = new double[size];
        }

        public void Iterate(double[][] A, double[] B, double accuracy)
        {
            double[] currentX = new double[A.Length]; // contains current X values that will be saved as a result ones in the end of each iteration
            double sum = 0;

            while (IterationCount < 10000) // 10000 iterations limit is needed for situations when result can't be found (endless iterations suspension)
            {
                IterationCount++;
                for (int i = 0; i < A.Length; i++)
                {
                    for (int j = 0; j < A.Length; j++)
                    {
                        if (i != j)
                        {
                            sum += A[i][j] * resultX[j];  // calculating multiplication of matrixes A * B, i != j
                        }
                    }

                    currentX[i] = (B[i] - sum) / A[i][i]; // main formula for X(i)
                    errorX[i] = CalculateError(currentX[i], resultX[i]);
                    sum = 0;
                }

                for (int i = 0; i < resultX.Length; i++)  // since errors are calculated, let's save current X values as a result
                {
                    resultX[i] = currentX[i];
                }

                if (IsAccuracyReached(errorX, accuracy))
                    break;
            }
        }

        private double CalculateError(double x1, double x0)
        {
            return Math.Abs(x1 - x0);
        }

        private bool IsAccuracyReached(double[] errorX, double accuracy)
        {
            double max = 0;
            for (int i = 0; i < errorX.Length; i++)
            {
                if (errorX[i] > max)
                    max = errorX[i];  // to not to check error for every X(i), it's better to find the max error and then check it
            }

            return max < accuracy;
        }

        public double[] ResultX
        {
            get { return resultX; }
        }

        public double[] ErrorX
        {
            get { return errorX; }
        }

        public uint IterationCount { get; private set; } = 0;
    }
}
