namespace MethodsLibrary
{
    public static class DeterminantCalculating
    {
        public static double CalculateDeterminant(double[,] matrix, ref int iterations)
        {
            int n = matrix.GetLength(0);
            if (n == 1)
            {
                return matrix[0, 0];
            }
            double determinant = 0;
            int altenationSign = 1;
            for (int col = 0; col < n; col++)
            {
                double[,] newMatrix = GetNewMatrix(matrix, 0, col, ref iterations);
                determinant += altenationSign * matrix[0, col] * CalculateDeterminant(newMatrix, ref iterations);
                altenationSign = -altenationSign;
            }
            return determinant;
        }

        private static double[,] GetNewMatrix(double[,] matrix, int rowToRemove, int colToRemove, ref int iterations)
        {
            int n = matrix.GetLength(0);
            double[,] newMatrix = new double[n - 1, n - 1];
            int rowToFill = 0;
            for (int row = 0; row < n; row++)
            {
                if (row != rowToRemove)
                {
                    int colToFill = 0;
                    for (int col = 0; col < n; col++)
                    {
                        iterations++;
                        if (col != colToRemove)
                        {
                            newMatrix[rowToFill, colToFill] = matrix[row, col];
                            colToFill++;
                        }
                    }
                    rowToFill++;
                }
            }
            return newMatrix;
        }
    }
}
