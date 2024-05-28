namespace CourseWinForm
{
    partial class GraphicForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            ChartGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)ChartGraphic).BeginInit();
            SuspendLayout();
            // 
            // ChartGraphic
            // 
            chartArea1.CursorX.AutoScroll = false;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.AutoScroll = false;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            ChartGraphic.ChartAreas.Add(chartArea1);
            legend1.MaximumAutoSize = 100F;
            legend1.Name = "Legend1";
            ChartGraphic.Legends.Add(legend1);
            ChartGraphic.Location = new Point(12, 12);
            ChartGraphic.MaximumSize = new Size(1200, 1000);
            ChartGraphic.MinimumSize = new Size(100, 100);
            ChartGraphic.Name = "ChartGraphic";
            ChartGraphic.Size = new Size(1108, 340);
            ChartGraphic.TabIndex = 0;
            ChartGraphic.Text = "Графічний розв'язок";
            // 
            // GraphicForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 362);
            Controls.Add(ChartGraphic);
            Name = "GraphicForm";
            Text = "Графічний_розв'язок";
            ((System.ComponentModel.ISupportInitialize)ChartGraphic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartGraphic;
    }
}