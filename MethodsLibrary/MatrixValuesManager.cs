﻿namespace MethodsLibrary
{
    public static class MatrixValuesManager
    {
        private const double _minValue = 1e-10;
        private const double _maxValue = 1e10;

        public static double[,] DeepCopy(double[,] matrixToCopy)
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);
            double[,] copyOfMatrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copyOfMatrix[i, j] = matrixToCopy[i, j];
                }
            }
            return copyOfMatrix;
        }

        public static double GetValueFromString(string receivedString)
        {
            if (string.IsNullOrEmpty(receivedString))
            {
                throw new ArgumentNullException();
            }
            if (!double.TryParse(receivedString, out double result))
            {
                throw new FormatException();
            }

            double absResult = Math.Abs(result);
            if (absResult > _maxValue)
            {
                throw new ValueTooHugeException();
            }
            if (absResult < _minValue && absResult != 0)
            {
                throw new ValueTooSmallException();
            }
            if (Double.IsNaN(absResult) || Double.IsInfinity(absResult))
            {
                throw new FormatException();
            }
            if (absResult == 0)
            {
                foreach (char ch in receivedString)
                {
                    if (ch != '0' && ch != ',')
                    {
                        throw new ValueTooSmallException();
                    }
                }
            }
            return result;
        }
    }
}