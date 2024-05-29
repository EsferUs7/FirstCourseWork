using MethodsLibrary;

namespace CourseWinForm
{
    public partial class MenuForm : Form
    {
        private TextBox[,] _matrixTextBoxes;
        private ToolTip[,] _matrixToolTips;
        private readonly TableLayoutPanel _tableOfArgs;

        public MenuForm()
        {
            InitializeComponent();
            for (int i = 2; i <= 10; i++)
            {
                ComboBoxMatrixLength.Items.Add(i);
            }
            ComboBoxMatrixLength.SelectedIndexChanged += ComboBoxMatrixLength_Selected;
            _tableOfArgs = new TableLayoutPanel
            {
                Location = new Point(280, 20),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };
            Controls.Add(_tableOfArgs);
        }

        private void ComboBoxMatrixLength_Selected(object sender, EventArgs e)
        {
            if (ComboBoxMatrixLength.SelectedIndex < 0)
            {
                MessageBox.Show("Будь ласка, оберіть розмірність СЛАР перед продовженням.");
                return;
            }

            int dimension = (int)ComboBoxMatrixLength.SelectedItem;
            _matrixTextBoxes = new TextBox[dimension, dimension + 1];
            int widthOfTextbox = 50;
            int widthOfLabel = 50;
            _tableOfArgs.Controls.Clear();
            _tableOfArgs.ColumnCount = 2 * dimension + 2;
            _tableOfArgs.RowCount = dimension;

            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension + 1; col++)
                {
                    var textBox = new TextBox
                    {
                        Width = widthOfTextbox,
                        TextAlign = HorizontalAlignment.Center
                    };
                    _matrixTextBoxes[row, col] = textBox;

                    var label = new Label()
                    {
                        Width = widthOfLabel,
                    };
                    if (col < dimension - 1)
                    {
                        label.Text = $"X{col + 1} +";
                    }
                    else if (col == dimension - 1)
                    {
                        label.Text = $"X{col + 1} =";
                    }

                    _tableOfArgs.Controls.Add(label, col, row);
                    _tableOfArgs.Controls.Add(textBox, col, row);
                }
            }
            SetToolTips();
        }

        private void ButtonToStartSolving_Click(object sender, EventArgs e)
        {
            if (ComboBoxMatrixLength.SelectedIndex < 0)
            {
                MessageBox.Show("Будь ласка, оберіть розмірності СЛАР перед продовженням.");
                return;
            }
            int dimension = (int)ComboBoxMatrixLength.SelectedItem;
            double[,] MatrixOfCoefficients = new double[dimension, dimension + 1];
            bool allValuesIsCorrect = true;
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension + 1; col++)
                {
                    _matrixTextBoxes[row, col].BackColor = Color.White;
                    _matrixToolTips[row, col].SetToolTip(_matrixTextBoxes[row, col], "");
                    try
                    {
                        MatrixOfCoefficients[row, col] = MatrixValuesManager.GetValueFromString(
                            _matrixTextBoxes[row, col].Text);
                    }
                    catch (Exception ex)
                    {
                        string massage;
                        if (ex is ArgumentNullException) massage = "Комірка порожня. " +
                                "Введіть дійсне значення у форматі '12,13'";
                        else if (ex is FormatException) massage = "Введено не дійсне значення. " +
                                "Введіть дійсне значення у форматі '12,13'";
                        else if (ex is ValueTooHugeException) massage = "Абсолютне значення завелике. " +
                                "Введіть значення з вказаної множини";
                        else if (ex is ValueTooSmallException) massage = "Абсолютне значення замале. " +
                            "Введіть значення з вказаної множини";
                        else massage = "Введено некоректне значення. " +
                            "Введіть дійсне значення з вказаної множини у форматі '12,13'. " +
                            "Кількість знаків після коми має бути не більшою за 9";
                        _matrixToolTips[row, col].SetToolTip(_matrixTextBoxes[row, col], massage);
                        _matrixTextBoxes[row, col].BackColor = Color.Red;
                        allValuesIsCorrect = false;
                    }
                }
            }
            if (!allValuesIsCorrect)
            {
                MessageBox.Show("Дані введено некоректно");
                return;
            }

            double[,] copyMatrixOfCoefficients = MatrixValuesManager.DeepCopy(MatrixOfCoefficients);
            SolutionsCount isCompatibleResult = MatrixRankChecker.CheckCompatibility(copyMatrixOfCoefficients);
            if (isCompatibleResult == SolutionsCount.UniqueSolution)
            {
                int selectedIndex = ComboBoxMethods.SelectedIndex;
                switch (selectedIndex)
                {
                    case 0: // Метод Крамера
                        new CramerMethodForm(MatrixOfCoefficients).ShowDialog();
                        break;
                    case 1: // Метод Гауса з одиничною діагоналлю
                        new GaussDiagonalForm(MatrixOfCoefficients).ShowDialog();
                        break;
                    case 2: // Метод Гауса з вибором головного елементу
                        new GaussPivotForm(MatrixOfCoefficients).ShowDialog();
                        break;
                    default:
                        MessageBox.Show("Метод не обрано. Будь ласка, оберіть метод розв'язання СЛАР");
                        break;
                }
            }
            else if (isCompatibleResult == SolutionsCount.InfiniteSolutions)
            {
                MessageBox.Show("Система має нескінченну кількість розв'язків.");
            }
            else
            {
                MessageBox.Show("Система несумісна");
            }
        }

        private void ButtonRandomGenerate_Click(object sender, EventArgs e)
        {
            if (ComboBoxMatrixLength.SelectedIndex < 0)
            {
                MessageBox.Show("Будь ласка, оберіть розмірність СЛАР перед продовженням.");
                return;
            }
            int dimension = (int)ComboBoxMatrixLength.SelectedItem;
            Random forRandomValue = new();
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension + 1; col++)
                {
                    double randomValue = Math.Round(forRandomValue.NextDouble() * 100, 2);
                    _matrixTextBoxes[row, col].Text = randomValue.ToString();
                }
            }
        }

        private void SetToolTips()
        {
            int dimension = (int)ComboBoxMatrixLength.SelectedItem;
            _matrixToolTips = new ToolTip[dimension, dimension + 1];
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension + 1; col++)
                {
                    ToolTip newToolTip = new ToolTip();
                    newToolTip.SetToolTip(_matrixTextBoxes[row, col], "");
                    _matrixToolTips[row, col] = newToolTip;
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (ComboBoxMatrixLength.SelectedIndex < 0)
            {
                MessageBox.Show("Будь ласка, оберіть розмірність СЛАР перед продовженням.");
                return;
            }

            int dimension = (int)ComboBoxMatrixLength.SelectedItem;
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension + 1; col++)
                {
                    _matrixTextBoxes[row, col].Text = "";
                }
            }
        }
    }
}
