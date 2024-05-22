using MethodsLibrary;

namespace CourseWinForm
{
    public partial class CramerMethodForm(double[,] MatrixOfArgs) : MethodForm(MatrixOfArgs)
    {
        public override string GetMethodName()
        {
            return "Метод_Крамера";
        }

        public override double[] GetResult(IStepsNotifiable? notifier = null)
        {
            return CramerMethod.Solve(augmentedMatrix, ref methodIterations, notifier);
        }
    }
}
