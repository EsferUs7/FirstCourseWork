using System;

namespace MethodsLibrary
{
    public static class CramerMethod
    {
        public static double[] Solve(double[,] augmentedMatrix, ref int iterations, IStepsNotifiable? notifier = null)
        {
            int n = augmentedMatrix.GetLength(0);
            double[,] coefficientMatrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    coefficientMatrix[i, j] = augmentedMatrix[i, j];
                }
            }

            double mainDet = DeterminantCalculating.CalculateDeterminant(coefficientMatrix, ref iterations);
            if (mainDet == 0)
            {
                notifier.SetNotify("Метод є розбіжним, оскільки визначник основної матриці 0");
                return [];
            }
            if (notifier != null)
            {
                notifier.SetNotify($"Основний визначник: {mainDet:F6}");
            }

            double[] results = new double[n];
            for (int j = 0; j < n; j++)
            {
                double[,] replaceColMatrix = MatrixValuesManager.DeepCopy(coefficientMatrix);
                for (int i = 0; i < n; i++)
                {
                    replaceColMatrix[i, j] = augmentedMatrix[i, n];
                }
                double replaceColDet = DeterminantCalculating.CalculateDeterminant(replaceColMatrix, ref iterations);
                if (notifier != null)
                {
                    notifier.SetNotify($"Визначник для змінної {j + 1}: {replaceColDet:F6}");
                }
                results[j] = replaceColDet / mainDet;
            }
            return results;
        }
    }
}
