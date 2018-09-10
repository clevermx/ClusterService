namespace Practik2_3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.countTB = new System.Windows.Forms.TextBox();
            this.downloadBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResParallelTB = new System.Windows.Forms.TextBox();
            this.ResPB = new System.Windows.Forms.ProgressBar();
            this.ResParallelPB = new System.Windows.Forms.ProgressBar();
            this.startBTN = new System.Windows.Forms.Button();
            this.startParallelBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.cancelParallelBTN = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ResTB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.accuracyTB = new System.Windows.Forms.TextBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.countTB2 = new System.Windows.Forms.TextBox();
            this.downloadBTN2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // countTB
            // 
            this.countTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countTB.Location = new System.Drawing.Point(27, 384);
            this.countTB.Name = "countTB";
            this.countTB.Size = new System.Drawing.Size(100, 20);
            this.countTB.TabIndex = 0;
            this.countTB.TextChanged += new System.EventHandler(this.tb_TextChanged);
            this.countTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // downloadBTN
            // 
            this.downloadBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadBTN.Location = new System.Drawing.Point(152, 382);
            this.downloadBTN.Name = "downloadBTN";
            this.downloadBTN.Size = new System.Drawing.Size(73, 23);
            this.downloadBTN.TabIndex = 2;
            this.downloadBTN.Text = "загрузить";
            this.downloadBTN.UseVisualStyleBackColor = true;
            this.downloadBTN.Click += new System.EventHandler(this.downloadBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Однопоточная версия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Параллельная версия";
            // 
            // ResParallelTB
            // 
            this.ResParallelTB.Location = new System.Drawing.Point(9, 223);
            this.ResParallelTB.Multiline = true;
            this.ResParallelTB.Name = "ResParallelTB";
            this.ResParallelTB.Size = new System.Drawing.Size(228, 39);
            this.ResParallelTB.TabIndex = 6;
            // 
            // ResPB
            // 
            this.ResPB.Location = new System.Drawing.Point(3, 310);
            this.ResPB.Name = "ResPB";
            this.ResPB.Size = new System.Drawing.Size(231, 23);
            this.ResPB.TabIndex = 7;
            // 
            // ResParallelPB
            // 
            this.ResParallelPB.Location = new System.Drawing.Point(6, 308);
            this.ResParallelPB.Name = "ResParallelPB";
            this.ResParallelPB.Size = new System.Drawing.Size(231, 23);
            this.ResParallelPB.TabIndex = 8;
            // 
            // startBTN
            // 
            this.startBTN.Location = new System.Drawing.Point(6, 268);
            this.startBTN.Name = "startBTN";
            this.startBTN.Size = new System.Drawing.Size(80, 36);
            this.startBTN.TabIndex = 9;
            this.startBTN.Text = "запуск";
            this.startBTN.UseVisualStyleBackColor = true;
            this.startBTN.Click += new System.EventHandler(this.startBTN_Click);
            // 
            // startParallelBTN
            // 
            this.startParallelBTN.Location = new System.Drawing.Point(6, 266);
            this.startParallelBTN.Name = "startParallelBTN";
            this.startParallelBTN.Size = new System.Drawing.Size(80, 36);
            this.startParallelBTN.TabIndex = 10;
            this.startParallelBTN.Text = "запуск";
            this.startParallelBTN.UseVisualStyleBackColor = true;
            this.startParallelBTN.Click += new System.EventHandler(this.startParallelBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(154, 268);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(80, 36);
            this.cancelBTN.TabIndex = 11;
            this.cancelBTN.Text = "отмена";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // cancelParallelBTN
            // 
            this.cancelParallelBTN.Location = new System.Drawing.Point(157, 266);
            this.cancelParallelBTN.Name = "cancelParallelBTN";
            this.cancelParallelBTN.Size = new System.Drawing.Size(80, 36);
            this.cancelParallelBTN.TabIndex = 12;
            this.cancelParallelBTN.Text = "отмена";
            this.cancelParallelBTN.UseVisualStyleBackColor = true;
            this.cancelParallelBTN.Click += new System.EventHandler(this.cancelParallelBTN_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SingleWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SingleComplete);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.cancelBTN);
            this.panel1.Controls.Add(this.startBTN);
            this.panel1.Controls.Add(this.ResPB);
            this.panel1.Controls.Add(this.ResTB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 342);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 201);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // ResTB
            // 
            this.ResTB.Location = new System.Drawing.Point(6, 223);
            this.ResTB.Multiline = true;
            this.ResTB.Name = "ResTB";
            this.ResTB.Size = new System.Drawing.Size(228, 39);
            this.ResTB.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.cancelParallelBTN);
            this.panel2.Controls.Add(this.startParallelBTN);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ResParallelPB);
            this.panel2.Controls.Add(this.ResParallelTB);
            this.panel2.Location = new System.Drawing.Point(365, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 342);
            this.panel2.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(241, 201);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Accuracy";
            // 
            // accuracyTB
            // 
            this.accuracyTB.Location = new System.Drawing.Point(265, 120);
            this.accuracyTB.Name = "accuracyTB";
            this.accuracyTB.Size = new System.Drawing.Size(70, 20);
            this.accuracyTB.TabIndex = 16;
            this.accuracyTB.Text = "0,1";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // countTB2
            // 
            this.countTB2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countTB2.Location = new System.Drawing.Point(365, 386);
            this.countTB2.Name = "countTB2";
            this.countTB2.Size = new System.Drawing.Size(100, 20);
            this.countTB2.TabIndex = 17;
            // 
            // downloadBTN2
            // 
            this.downloadBTN2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadBTN2.Location = new System.Drawing.Point(488, 383);
            this.downloadBTN2.Name = "downloadBTN2";
            this.downloadBTN2.Size = new System.Drawing.Size(73, 23);
            this.downloadBTN2.TabIndex = 18;
            this.downloadBTN2.Text = "загрузить";
            this.downloadBTN2.UseVisualStyleBackColor = true;
            this.downloadBTN2.Click += new System.EventHandler(this.downloadBTN2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 425);
            this.Controls.Add(this.downloadBTN2);
            this.Controls.Add(this.countTB2);
            this.Controls.Add(this.accuracyTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.downloadBTN);
            this.Controls.Add(this.countTB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox countTB;
        private System.Windows.Forms.Button downloadBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ResParallelTB;
        private System.Windows.Forms.ProgressBar ResPB;
        private System.Windows.Forms.ProgressBar ResParallelPB;
        private System.Windows.Forms.Button startBTN;
        private System.Windows.Forms.Button startParallelBTN;
        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.Button cancelParallelBTN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox accuracyTB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox ResTB;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox countTB2;
        private System.Windows.Forms.Button downloadBTN2;
    }
}

