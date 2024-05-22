namespace MethodsLibrary
{
    public enum SolutionsCount
    {
        UniqueSolution,
        InfiniteSolutions,
        NoSolutions
    }

    public static class MatrixRankChecker
    {
        public static int GetRank(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int nonZeroColumn;
            for (int i = 0; i < rows; i++)
            {
                nonZeroColumn = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        nonZeroColumn = j;
                        break;
                    }
                }
                if (nonZeroColumn == -1)
                {
                    continue;
                }

                double nonZeroValue = matrix[i, nonZeroColumn];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] /= nonZeroValue;
                }
                for (int k = 0; k < rows; k++)
                {
                    if (k == i)
                    {
                        continue;
                    }
                    double eliminationValue = matrix[k, nonZeroColumn];
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[k, j] -= eliminationValue * matrix[i, j];
                    }
                }
            }

            int rank = 0;
            for (int i = 0; i < rows; i++)
            {
                bool allValuesIsZero = true;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        allValuesIsZero = false;
                        break;
                    }
                }
                if (!allValuesIsZero)
                {
                    rank++;
                }
            }
            return rank;
        }

        public static SolutionsCount CheckCompatibility(double[,] augmentedMatrix)
        {
            int rows = augmentedMatrix.GetLength(0);
            int cols = augmentedMatrix.GetLength(1);
            double[,] coefficientMatrix = new double[rows, cols - 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    coefficientMatrix[i, j] = augmentedMatrix[i, j];
                }
            }

            int rankMatrixCoefficient = GetRank(coefficientMatrix);
            int rankAugmentedMatrix = GetRank(augmentedMatrix);
            if (rankMatrixCoefficient == rankAugmentedMatrix)
            {
                if (rankMatrixCoefficient < cols - 1)
                {
                    return SolutionsCount.InfiniteSolutions;
                }
                return SolutionsCount.UniqueSolution;
            }
            return SolutionsCount.NoSolutions;
        }
    }
}
