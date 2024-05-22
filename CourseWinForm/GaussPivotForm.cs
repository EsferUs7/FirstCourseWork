﻿using MethodsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWinForm
{
    public partial class GaussPivotForm(double[,] MatrixOfArgs) : MethodForm(MatrixOfArgs)
    {
        public override string GetMethodName()
        {
            return "Метод_Гауса_з_вибором_головного_елемента";
        }

        public override double[] GetResult(IStepsNotifiable? notifier = null)
        {
            return GaussPivotMethod.Solve(augmentedMatrix, ref methodIterations, notifier);
        }
    }
}
