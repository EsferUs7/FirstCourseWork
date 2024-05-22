using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Schema;

namespace CourseWinForm
{
    public partial class GraphicForm : Form
    {
        private double xMin;
        private double xMax;
        private readonly double[] firstEquation;
        private readonly double[] secondEquation;
        private readonly double[] result;

        public GraphicForm(double[] firstEquation, double[] secondEquation, double[] result)
        {
            InitializeComponent();
            this.firstEquation = firstEquation;
            this.secondEquation = secondEquation;
            this.result = result;
            SetMinMax(result);
            DrawLines();
        }

        private void SetMinMax(double[] result)
        {
            double x = result[0];
            xMin = x - 3;
            xMax = x + 3;
        }

        private void DrawLines()
        {
            Series seriesFirst = ChartGraphic.Series.Add(
                $"Пряма : {firstEquation[0]} x + {firstEquation[1]} y = {firstEquation[2]}");
            Series seriesSecond = ChartGraphic.Series.Add(
                $"Пряма : {secondEquation[0]} x + {secondEquation[1]} y = {secondEquation[2]}");
            Series intersectionSeries = ChartGraphic.Series.Add("Точка перетину (розв'язок)");
            seriesFirst.ChartType = SeriesChartType.Line;
            seriesFirst.Color = Color.Blue;
            seriesSecond.ChartType = SeriesChartType.Line;
            seriesSecond.Color = Color.Red;
            intersectionSeries.ChartType = SeriesChartType.Point;
            intersectionSeries.MarkerStyle = MarkerStyle.Circle;
            intersectionSeries.MarkerColor = Color.Green;
            intersectionSeries.MarkerSize = 7;

            double startOfFirst, endOfFirst, startOfSecond, endOfSecond;
            if (firstEquation[1] == 0)
            {
                startOfFirst = result[1] - 5;
                endOfFirst = result[1] + 5;
                seriesFirst.Points.AddXY(result[0], startOfFirst);
                seriesFirst.Points.AddXY(result[0], endOfFirst);
            }
            else
            {
                startOfFirst = (firstEquation[2] / firstEquation[1]) - (firstEquation[0] / firstEquation[1]) * xMin;
                endOfFirst = (firstEquation[2] / firstEquation[1]) - (firstEquation[0] / firstEquation[1]) * xMax;
                seriesFirst.Points.AddXY(xMin, startOfFirst);
                seriesFirst.Points.AddXY(xMax, endOfFirst);
            }

            if (secondEquation[1] == 0)
            {
                startOfSecond = result[1] - 5;
                endOfSecond = result[1] + 5;
                seriesSecond.Points.AddXY(result[0], startOfSecond);
                seriesSecond.Points.AddXY(result[0], endOfSecond);
            }
            else
            {
                startOfSecond = (secondEquation[2] / secondEquation[1]) - (secondEquation[0] / secondEquation[1]) * xMin;
                endOfSecond = (secondEquation[2] / secondEquation[1]) - (secondEquation[0] / secondEquation[1]) * xMax;
                seriesSecond.Points.AddXY(xMin, startOfSecond);
                seriesSecond.Points.AddXY(xMax, endOfSecond);

            }

            double xAnswerPoint = result[0];
            double yAnswerPoint = result[1];
            intersectionSeries.Points.AddXY(xAnswerPoint, yAnswerPoint);
        }
    }
}
