using MethodsLibrary;
using System.Text;


namespace CourseWinForm
{
    public abstract partial class MethodForm : Form, IStepsNotifiable
    {
        protected double[] Result;
        protected ListBox ResultListBox;
        protected ListBox StepsListBox;
        protected double[,] augmentedMatrix;
        protected double[] firstLineEquation;
        protected double[] secondLineEquation;
        protected int methodIterations;

        public MethodForm(double[,] MatrixOfArgs)
        {
            InitializeComponent();
            methodIterations = 0;
            this.Text = GetMethodName();
            augmentedMatrix = MatrixOfArgs;
            if (MatrixOfArgs.GetLength(0) == 2)
            {
                int columnCount = 3;
                firstLineEquation = new double[columnCount];
                secondLineEquation = new double[columnCount];
                for (int i = 0; i < columnCount; i++)
                {
                    firstLineEquation[i] = MatrixOfArgs[0, i];
                    secondLineEquation[i] = MatrixOfArgs[1, i];
                }
            }
            GetAnswerWithSteps();
            if (MatrixOfArgs.GetLength(0) == 2)
            {
                AddGraphicButton();
            }
            AddIterationsLabel();
            this.Load += MethodForm_Load;
        }

        private void MethodForm_Load(object sender, EventArgs e)
        {
            if (Result.Length == 0)
            {
                MessageBox.Show($"Розв'язку даної системи не знайдено.\n" +
                    $"Спробуйте іншу СЛАР");
                this.Close();
            }
            if (HasNanOrInf())
            {
                MessageBox.Show($"Знайдений розв'язок містить не числове значення (NaN або Inf).\n" +
                    $"Спробуйте іншу СЛАР");
                this.Close();
            }
        }

        public abstract double[] GetResult(IStepsNotifiable? notifier = null);

        private bool HasNanOrInf()
        {
            for (int i = 0; i < this.Result.Length; i++)
            {
                if (double.IsNaN(this.Result[i]) || double.IsInfinity(this.Result[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private void GetAnswerWithSteps()
        {
            StepsListBox = new ListBox
            {
                Location = new Point(200, 35),
                Size = new Size(500, 200),
            };
            Controls.Add(StepsListBox);
            this.Result = GetResult(this);
            ResultListBox = new ListBox
            {
                Location = new Point(10, 35),
                Size = new Size(150, 200),
            };
            Controls.Add(ResultListBox);
            for (int i = 0; i < Result.Length; i++)
            {
                StepsListBox.Items.Add($"X{i + 1}: {Result[i]:F6}");
                ResultListBox.Items.Add($"X{i + 1}: {Result[i]:F6}");
            }
        }

        public void SetNotify(string message)
        {
            StepsListBox.Items.Add(message);
        }

        public abstract string GetMethodName();

        private void ButtonGetFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new())
            {
                StringBuilder resultText = new();
                string methodName = GetMethodName();
                DateTime currentDateAndTime = DateTime.Now;
                string editedDateTime = currentDateAndTime.ToString("dd-MM-yyyy_HHmmss");
                string startFilePath = $"{methodName}_{editedDateTime}.txt";
                for (int i = 0; i < Result.Length; i++)
                {
                    resultText.Append($"X{i + 1}: {Result[i]:F6}\n");
                }

                saveFile.Title = "Виберіть, куди зберегти файл";
                saveFile.Filter = "Text files (*.txt)|*.txt";
                saveFile.FileName = startFilePath;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFile.FileName;
                    try
                    {
                        if (!filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                            filePath += ".txt";
                        }
                        File.WriteAllText(filePath, resultText.ToString());
                        MessageBox.Show($"Файл успішно збережено в: {filePath}");
                    }
                    catch
                    {
                        MessageBox.Show("Помилка при збереженні файлу. Переконайтесь, що зберігаєте файл правильно");
                    }
                }
            }
        }

        private void AddGraphicButton()
        {
            Button ButtonToGetGraphic = new()
            {
                Text = "Графічний\nрозв'язок",
                Location = new Point(12, 250),
                Size = new Size(139, 60)  
            };
            Controls.Add(ButtonToGetGraphic);
            ButtonToGetGraphic.Click += ButtonToGetGraphic_Click;
        }

        private void ButtonToGetGraphic_Click(object sender, EventArgs e)
        {
            new GraphicForm(firstLineEquation, secondLineEquation, Result).ShowDialog();
        }

        private void AddIterationsLabel()
        {
            Label LabelToGetOperation = new()
            {
                Text = $"Кількість ітерацій: {methodIterations}",
                Location = new Point(200, 393),
                Size = new Size(250, 60)
            };
            Controls.Add(LabelToGetOperation);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
