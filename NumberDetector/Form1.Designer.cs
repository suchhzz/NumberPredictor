namespace NumberDetector
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            clearButton = new Button();
            panel1 = new Panel();
            splitContainer2 = new SplitContainer();
            label1 = new Label();
            outputLabel = new Label();
            defineButton = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(clearButton);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(632, 450);
            splitContainer1.SplitterDistance = 416;
            splitContainer1.TabIndex = 0;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(12, 417);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 23);
            clearButton.TabIndex = 1;
            clearButton.Text = "Clear field";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Cursor = Cursors.Cross;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 400);
            panel1.TabIndex = 0;
            panel1.Click += panel1_Click;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(label1);
            splitContainer2.Panel1.Controls.Add(outputLabel);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(defineButton);
            splitContainer2.Size = new Size(212, 450);
            splitContainer2.SplitterDistance = 407;
            splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 10);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Output";
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            outputLabel.Location = new Point(68, 150);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(63, 86);
            outputLabel.TabIndex = 0;
            outputLabel.Text = "-";
            // 
            // defineButton
            // 
            defineButton.Location = new Point(3, 3);
            defineButton.Name = "defineButton";
            defineButton.Size = new Size(202, 31);
            defineButton.TabIndex = 0;
            defineButton.Text = "Define";
            defineButton.UseVisualStyleBackColor = true;
            defineButton.Click += defineButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private SplitContainer splitContainer2;
        private Button clearButton;
        private Label label1;
        private Label outputLabel;
        private Button defineButton;
    }
}
