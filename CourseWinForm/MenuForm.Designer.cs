namespace CourseWinForm
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            ButtonToStartSolving = new Button();
            LabelOfChoice = new Label();
            ComboBoxMethods = new ComboBox();
            ComboBoxMatrixLength = new ComboBox();
            labelForDimensions = new Label();
            ButtonRandomGenerate = new Button();
            ShowInfoLabel = new Label();
            ClearButton = new Button();
            SuspendLayout();
            // 
            // ButtonToStartSolving
            // 
            ButtonToStartSolving.Font = new Font("Segoe UI", 16F);
            ButtonToStartSolving.Location = new Point(888, 390);
            ButtonToStartSolving.Name = "ButtonToStartSolving";
            ButtonToStartSolving.Size = new Size(350, 60);
            ButtonToStartSolving.TabIndex = 5;
            ButtonToStartSolving.Text = "Почати розв'язання СЛАР";
            ButtonToStartSolving.UseVisualStyleBackColor = true;
            ButtonToStartSolving.Click += ButtonToStartSolving_Click;
            // 
            // LabelOfChoice
            // 
            LabelOfChoice.AutoSize = true;
            LabelOfChoice.Location = new Point(380, 398);
            LabelOfChoice.Name = "LabelOfChoice";
            LabelOfChoice.Size = new Size(190, 20);
            LabelOfChoice.TabIndex = 6;
            LabelOfChoice.Text = "Оберіть потрібний метод:";
            // 
            // ComboBoxMethods
            // 
            ComboBoxMethods.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxMethods.FormattingEnabled = true;
            ComboBoxMethods.Items.AddRange(new object[] { "Метод Крамера", "Метод Гауса з одиничною діагоналлю", "Метод Гауса з вибором головного елементу" });
            ComboBoxMethods.Location = new Point(380, 422);
            ComboBoxMethods.Name = "ComboBoxMethods";
            ComboBoxMethods.Size = new Size(417, 28);
            ComboBoxMethods.TabIndex = 7;
            // 
            // ComboBoxMatrixLength
            // 
            ComboBoxMatrixLength.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxMatrixLength.FormattingEnabled = true;
            ComboBoxMatrixLength.Location = new Point(12, 327);
            ComboBoxMatrixLength.Name = "ComboBoxMatrixLength";
            ComboBoxMatrixLength.Size = new Size(151, 28);
            ComboBoxMatrixLength.TabIndex = 9;
            // 
            // labelForDimensions
            // 
            labelForDimensions.AutoSize = true;
            labelForDimensions.Location = new Point(12, 304);
            labelForDimensions.Name = "labelForDimensions";
            labelForDimensions.Size = new Size(135, 20);
            labelForDimensions.TabIndex = 10;
            labelForDimensions.Text = "Розмірність СЛАР:";
            // 
            // ButtonRandomGenerate
            // 
            ButtonRandomGenerate.Location = new Point(12, 396);
            ButtonRandomGenerate.Name = "ButtonRandomGenerate";
            ButtonRandomGenerate.Size = new Size(99, 52);
            ButtonRandomGenerate.TabIndex = 11;
            ButtonRandomGenerate.Text = "Випадкова генерація";
            ButtonRandomGenerate.UseVisualStyleBackColor = true;
            ButtonRandomGenerate.Click += ButtonRandomGenerate_Click;
            // 
            // ShowInfoLabel
            // 
            ShowInfoLabel.AutoSize = true;
            ShowInfoLabel.BackColor = SystemColors.ControlLightLight;
            ShowInfoLabel.BorderStyle = BorderStyle.FixedSingle;
            ShowInfoLabel.Font = new Font("Segoe UI", 9F);
            ShowInfoLabel.ForeColor = SystemColors.ActiveCaptionText;
            ShowInfoLabel.ImageAlign = ContentAlignment.MiddleLeft;
            ShowInfoLabel.Location = new Point(12, 9);
            ShowInfoLabel.Name = "ShowInfoLabel";
            ShowInfoLabel.Size = new Size(246, 262);
            ShowInfoLabel.TabIndex = 12;
            ShowInfoLabel.Text = resources.GetString("ShowInfoLabel.Text");
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(159, 398);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(99, 50);
            ClearButton.TabIndex = 13;
            ClearButton.Text = "Очистити введення";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1540, 488);
            Controls.Add(ClearButton);
            Controls.Add(ShowInfoLabel);
            Controls.Add(ButtonRandomGenerate);
            Controls.Add(labelForDimensions);
            Controls.Add(ComboBoxMatrixLength);
            Controls.Add(ComboBoxMethods);
            Controls.Add(LabelOfChoice);
            Controls.Add(ButtonToStartSolving);
            Name = "MenuForm";
            Text = "Меню: Розв'язання СЛАР точними методами";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonToStartSolving;
        private Label LabelOfChoice;
        private ComboBox ComboBoxMethods;
        private ComboBox ComboBoxMatrixLength;
        private Label labelForDimensions;
        private Button ButtonRandomGenerate;
        private Label ShowInfoLabel;
        private Button ClearButton;
    }
}