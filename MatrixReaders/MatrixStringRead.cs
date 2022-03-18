namespace Lab_1
{
    public abstract class MatrixStringRead : IMatrixReadStrategy
    {
        protected MatrixConverter converter = new MatrixConverter();
        public abstract double[][] GetMatrixA();
        public abstract double[] GetMatrixB();
    }
}
