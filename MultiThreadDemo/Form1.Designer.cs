namespace MultiThreadDemo
{
    partial class Form1
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
            this.btnTimeConsumingWork = new System.Windows.Forms.Button();
            this.btnPrintNumbers = new System.Windows.Forms.Button();
            this.listBoxNumbers = new System.Windows.Forms.ListBox();
            this.btnProcessFIle = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TextBackgroundWorkerBtn = new System.Windows.Forms.Button();
            this.threadDemoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTimeConsumingWork
            // 
            this.btnTimeConsumingWork.Location = new System.Drawing.Point(13, 13);
            this.btnTimeConsumingWork.Name = "btnTimeConsumingWork";
            this.btnTimeConsumingWork.Size = new System.Drawing.Size(257, 30);
            this.btnTimeConsumingWork.TabIndex = 0;
            this.btnTimeConsumingWork.Text = "Do Time Consuming Work";
            this.btnTimeConsumingWork.UseVisualStyleBackColor = true;
            this.btnTimeConsumingWork.Click += new System.EventHandler(this.btnTimeConsumingWork_Click);
            // 
            // btnPrintNumbers
            // 
            this.btnPrintNumbers.Location = new System.Drawing.Point(13, 49);
            this.btnPrintNumbers.Name = "btnPrintNumbers";
            this.btnPrintNumbers.Size = new System.Drawing.Size(257, 23);
            this.btnPrintNumbers.TabIndex = 1;
            this.btnPrintNumbers.Text = "Print Numbers";
            this.btnPrintNumbers.UseVisualStyleBackColor = true;
            this.btnPrintNumbers.Click += new System.EventHandler(this.btnPrintNumbers_Click);
            // 
            // listBoxNumbers
            // 
            this.listBoxNumbers.FormattingEnabled = true;
            this.listBoxNumbers.ItemHeight = 16;
            this.listBoxNumbers.Location = new System.Drawing.Point(13, 79);
            this.listBoxNumbers.Name = "listBoxNumbers";
            this.listBoxNumbers.Size = new System.Drawing.Size(407, 164);
            this.listBoxNumbers.TabIndex = 2;
            this.listBoxNumbers.SelectedIndexChanged += new System.EventHandler(this.listBoxNumbers_SelectedIndexChanged);
            // 
            // btnProcessFIle
            // 
            this.btnProcessFIle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessFIle.Location = new System.Drawing.Point(13, 266);
            this.btnProcessFIle.Name = "btnProcessFIle";
            this.btnProcessFIle.Size = new System.Drawing.Size(257, 34);
            this.btnProcessFIle.TabIndex = 3;
            this.btnProcessFIle.Text = "Process File";
            this.btnProcessFIle.UseVisualStyleBackColor = true;
            this.btnProcessFIle.Click += new System.EventHandler(this.btnProcessFile_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(13, 320);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(21, 20);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "\"\"";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 369);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(403, 22);
            this.textBox1.TabIndex = 5;
            // 
            // TextBackgroundWorkerBtn
            // 
            this.TextBackgroundWorkerBtn.Location = new System.Drawing.Point(17, 398);
            this.TextBackgroundWorkerBtn.Name = "TextBackgroundWorkerBtn";
            this.TextBackgroundWorkerBtn.Size = new System.Drawing.Size(253, 34);
            this.TextBackgroundWorkerBtn.TabIndex = 6;
            this.TextBackgroundWorkerBtn.Text = "Background Button";
            this.TextBackgroundWorkerBtn.UseVisualStyleBackColor = true;
            this.TextBackgroundWorkerBtn.Click += new System.EventHandler(this.TextBackgroundWorkerBtn_Click);
            // 
            // threadDemoButton
            // 
            this.threadDemoButton.Location = new System.Drawing.Point(17, 454);
            this.threadDemoButton.Name = "threadDemoButton";
            this.threadDemoButton.Size = new System.Drawing.Size(253, 53);
            this.threadDemoButton.TabIndex = 7;
            this.threadDemoButton.Text = "Run Thread Demo";
            this.threadDemoButton.UseVisualStyleBackColor = true;
            this.threadDemoButton.Click += new System.EventHandler(this.threadDemoButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 519);
            this.Controls.Add(this.threadDemoButton);
            this.Controls.Add(this.TextBackgroundWorkerBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnProcessFIle);
            this.Controls.Add(this.listBoxNumbers);
            this.Controls.Add(this.btnPrintNumbers);
            this.Controls.Add(this.btnTimeConsumingWork);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimeConsumingWork;
        private System.Windows.Forms.Button btnPrintNumbers;
        private System.Windows.Forms.ListBox listBoxNumbers;
        private System.Windows.Forms.Button btnProcessFIle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button TextBackgroundWorkerBtn;
        private System.Windows.Forms.Button threadDemoButton;
    }
}