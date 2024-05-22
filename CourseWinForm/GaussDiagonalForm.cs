using MethodsLibrary;

namespace CourseWinForm
{
    public partial class GaussDiagonalForm(double[,] MatrixOfArgs) : MethodForm(MatrixOfArgs)
    {
        public override string GetMethodName()
        {
            return "Метод_Гауса_з_одиничною_діагоналлю";
        }

        public override double[] GetResult(IStepsNotifiable? notifier = null)
        {
            return GaussDiagonalMethod.Solve(augmentedMatrix, ref methodIterations, notifier);
        }
    }
}
