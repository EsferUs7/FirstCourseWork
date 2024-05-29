namespace MethodsLibrary
{
    public static class MatrixValuesManager
    {
        private const double _minValue = 1e-6;
        private const double _maxValue = 1e5;
        private const int _maxDigitsAfterDot = 9;

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
            int flagIndex = receivedString.IndexOf(',');
            if (flagIndex != -1)
            {
                int digitsAfterDot = receivedString.Length - 1 - flagIndex;
                if (digitsAfterDot > _maxDigitsAfterDot)
                {
                    throw new Exception();
                }
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
            if (double.IsNaN(absResult) || double.IsInfinity(absResult))
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

        public static string GetToPrintNumber(double number)
        {
            if (Math.Abs(number) < _maxValue)
            {
                return number.ToString("G6");
            }
            else
            {
                return number.ToString("E3");
            }
        }
    }
}
