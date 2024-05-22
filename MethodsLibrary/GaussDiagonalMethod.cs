namespace MethodsLibrary
{
    public static class GaussDiagonalMethod
    {
        public static double[] Solve(double[,] augmentedMatrix, ref int iterations, IStepsNotifiable? notifier = null)
        {
            int n = augmentedMatrix.GetLength(0);
            int m = augmentedMatrix.GetLength(1);

            for (int k = 0; k < n; k++)
            {
                int maxInCol = k;
                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(augmentedMatrix[i, k]) > Math.Abs(augmentedMatrix[maxInCol, k]))
                    {
                        maxInCol = i;
                    }
                }
                if (maxInCol != k)
                {
                    SwapRows(augmentedMatrix, k, maxInCol);
                    notifier?.SetNotify($"Перестановка рядків {k + 1} та {maxInCol + 1}");
                }

                double diagonalElement = augmentedMatrix[k, k];
                if (diagonalElement == 0)
                {
                    notifier?.SetNotify("Метод є розбіжним для даної СЛАР");
                    return [];
                }
                for (int j = k; j < m; j++)
                {
                    augmentedMatrix[k, j] /= diagonalElement;
                }
                notifier?.SetNotify($"Нормалізація діагонального елемента {k + 1}");

                for (int i = k + 1; i < n; i++)
                {
                    double eliminationValue = augmentedMatrix[i, k];
                    for (int j = k; j < m; j++)
                    {
                        iterations++;
                        augmentedMatrix[i, j] -= eliminationValue * augmentedMatrix[k, j];
                    }
                    notifier?.SetNotify($"Елімінація рядка {i + 1} за допомогою рядка {k + 1}");
                }
            }

            double[] solution = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += augmentedMatrix[i, j] * solution[j];
                }
                solution[i] = augmentedMatrix[i, m - 1] - sum;
                notifier?.SetNotify($"Знайдене значення невідомого Х{i + 1} = {solution[i]:F6}");
            }
            return solution;
        }

        private static void SwapRows(double[,] matrix, int firstRow, int secondRow)
        {
            int n = matrix.GetLength(1);
            for (int j = 0; j < n; j++)
            {
                double temp = matrix[firstRow, j];
                matrix[firstRow, j] = matrix[secondRow, j];
                matrix[secondRow, j] = temp;
            }
        }
    }
}
