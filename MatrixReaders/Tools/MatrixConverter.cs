using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class MatrixConverter
    {
        public double[][] ConvertIntoMatrix(List<string> list)
        {
            double[][] matrix = new double[list.Count][];
            for (int i = 0; i < list.Count; i++)
            {
                matrix[i] = ConvertIntoVector(list[i]);
            }
            return matrix;
        }

        public double[] ConvertIntoVector(string line)
        {
            string[] array = line.Split(' ');
            double[] matrix_row = new double[array.Length];

            for (int j = 0; j < array.Length; j++)
            {
                matrix_row[j] = double.Parse(array[j]);
            }
            return matrix_row;
        }
    }
}
