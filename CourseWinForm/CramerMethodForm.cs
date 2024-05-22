using MethodsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
