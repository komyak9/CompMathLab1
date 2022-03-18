using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_1
{
    public class FileMatrixStrategy : MatrixStringRead
    {
        private readonly string pathA;
        private readonly string pathB;

        public FileMatrixStrategy()
        {
            Console.Write("Please, enter path to matrix A: ");
            pathA = Console.ReadLine();
            Console.Write("Please, enter path to matrix B: ");
            pathB = Console.ReadLine();
        }
        public override double[][] GetMatrixA()
        {
            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader(pathA))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length > 0)
                        list.Add(line);
                }
            }

            return converter.ConvertIntoMatrix(list);
        }

        public override double[] GetMatrixB()
        {
            string line;
            using (StreamReader sr = new StreamReader(pathB))
            {
                line = sr.ReadLine();
            }

            return converter.ConvertIntoVector(line);
        }
    }
}
