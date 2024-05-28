namespace CourseWinForm
{
    partial class MethodForm
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
            ResultLabel = new Label();
            CloseButton = new Button();
            ButtonGetFile = new Button();
            StepsLabel = new Label();
            SuspendLayout();
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(12, 9);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(87, 20);
            ResultLabel.TabIndex = 0;
            ResultLabel.Text = "Результати:";
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(12, 393);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(139, 29);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "Повернутись";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ButtonGetFile
            // 
            ButtonGetFile.Location = new Point(12, 320);
            ButtonGetFile.Name = "ButtonGetFile";
            ButtonGetFile.Size = new Size(139, 49);
            ButtonGetFile.TabIndex = 2;
            ButtonGetFile.Text = "Завантажити\r\nрозв'язки";
            ButtonGetFile.UseVisualStyleBackColor = true;
            ButtonGetFile.Click += ButtonGetFile_Click;
            // 
            // StepsLabel
            // 
            StepsLabel.AutoSize = true;
            StepsLabel.Location = new Point(200, 9);
            StepsLabel.Name = "StepsLabel";
            StepsLabel.Size = new Size(135, 20);
            StepsLabel.TabIndex = 3;
            StepsLabel.Text = "Кроки виконання:";
            // 
            // MethodForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StepsLabel);
            Controls.Add(ButtonGetFile);
            Controls.Add(CloseButton);
            Controls.Add(ResultLabel);
            Name = "MethodForm";
            Text = "MethodForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ResultLabel;
        private Button CloseButton;
        private Button ButtonGetFile;
        private Label StepsLabel;
    }
}