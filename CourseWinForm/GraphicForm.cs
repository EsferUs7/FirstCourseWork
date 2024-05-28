using MethodsLibrary;
using System.Windows.Forms.DataVisualization.Charting;

namespace CourseWinForm
{
    public partial class GraphicForm : Form
    {
        private double _xMin;
        private double _xMax;
        private double _range;
        private readonly double[] _firstEquation;
        private readonly double[] _secondEquation;
        private readonly double[] _result;

        public GraphicForm(double[] firstEquation, double[] secondEquation, double[] result)
        {
            InitializeComponent();
            _firstEquation = firstEquation;
            _secondEquation = secondEquation;
            _result = result;
            _range = 2;
            SetMinMax();
            DrawLines();
        }

        private void SetMinMax()
        {
            double x = _result[0];
            _xMin = x - _range;
            _xMax = x + _range;
        }

        private void DrawLines()
        {
            Series seriesFirst = ChartGraphic.Series.Add(
                $"Пряма : {MatrixValuesManager.GetToPrintNumber(_firstEquation[0])} x + " +
                $"{MatrixValuesManager.GetToPrintNumber(_firstEquation[1])} y = " +
                $"{MatrixValuesManager.GetToPrintNumber(_firstEquation[2])}");
            seriesFirst.ChartType = SeriesChartType.Line;
            seriesFirst.Color = Color.Blue;
            Series seriesSecond = ChartGraphic.Series.Add(
                $"Пряма : {MatrixValuesManager.GetToPrintNumber(_secondEquation[0])} x + " +
                $"{MatrixValuesManager.GetToPrintNumber(_secondEquation[1])} y = " +
                $"{MatrixValuesManager.GetToPrintNumber(_secondEquation[2])}");
            Series intersectionSeries = ChartGraphic.Series.Add($"Точка перетину (розв'язок) " +
                $"({MatrixValuesManager.GetToPrintNumber(_result[0])};{MatrixValuesManager.GetToPrintNumber(_result[1])})");
            seriesSecond.ChartType = SeriesChartType.Line;
            seriesSecond.Color = Color.Red;
            intersectionSeries.ChartType = SeriesChartType.Point;
            intersectionSeries.MarkerStyle = MarkerStyle.Circle;
            intersectionSeries.MarkerColor = Color.Green;
            intersectionSeries.MarkerSize = 7;

            double startOfFirst, endOfFirst, startOfSecond, endOfSecond;
            if (_firstEquation[1] == 0)
            {
                startOfFirst = _result[1] - _range;
                endOfFirst = _result[1] + _range;
                seriesFirst.Points.AddXY(_result[0], startOfFirst);
                seriesFirst.Points.AddXY(_result[0], endOfFirst);
            }
            else
            {
                startOfFirst = (_firstEquation[2] / _firstEquation[1]) - (_firstEquation[0] / _firstEquation[1]) * _xMin;
                endOfFirst = (_firstEquation[2] / _firstEquation[1]) - (_firstEquation[0] / _firstEquation[1]) * _xMax;
                seriesFirst.Points.AddXY(_xMin, startOfFirst);
                seriesFirst.Points.AddXY(_xMax, endOfFirst);
            }

            if (_secondEquation[1] == 0)
            {
                startOfSecond = _result[1] - _range;
                endOfSecond = _result[1] + _range;
                seriesSecond.Points.AddXY(_result[0], startOfSecond);
                seriesSecond.Points.AddXY(_result[0], endOfSecond);
            }
            else
            {
                startOfSecond = (_secondEquation[2] / _secondEquation[1]) - (_secondEquation[0] / _secondEquation[1]) * _xMin;
                endOfSecond = (_secondEquation[2] / _secondEquation[1]) - (_secondEquation[0] / _secondEquation[1]) * _xMax;
                seriesSecond.Points.AddXY(_xMin, startOfSecond);
                seriesSecond.Points.AddXY(_xMax, endOfSecond);
            }
            double xAnswerPoint = _result[0];
            double yAnswerPoint = _result[1];
            intersectionSeries.Points.AddXY(xAnswerPoint, yAnswerPoint);
        }
    }
}
