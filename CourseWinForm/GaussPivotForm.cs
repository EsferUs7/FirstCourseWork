using MethodsLibrary;

namespace CourseWinForm
{
    public partial class GaussPivotForm(double[,] MatrixOfArgs) : MethodForm(MatrixOfArgs)
    {
        public override string GetMethodName()
        {
            return "Метод_Гауса_з_вибором_головного_елементу";
        }

        public override double[] GetResult(IStepsNotifiable? notifier = null)
        {
            return GaussPivotMethod.Solve(augmentedMatrix, ref methodIterations, notifier);
        }
    }
}
