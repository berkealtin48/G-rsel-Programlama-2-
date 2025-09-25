namespace Görsel_Programlama_Hafta_1
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
            components = new System.ComponentModel.Container();
            lblHours = new Label();
            lblMinute = new Label();
            lblSec = new Label();
            lblSplitSec = new Label();
            btnBaslat = new Button();
            timer = new System.Windows.Forms.Timer(components);
            lblSplitSec2 = new Label();
            lblSec2 = new Label();
            lblMinute2 = new Label();
            lblHours2 = new Label();
            Sonuc = new Label();
            SuspendLayout();
            // 
            // lblHours
            // 
            lblHours.AutoSize = true;
            lblHours.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblHours.Location = new Point(106, 141);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(34, 25);
            lblHours.TabIndex = 0;
            lblHours.Text = "00";
            // 
            // lblMinute
            // 
            lblMinute.AutoSize = true;
            lblMinute.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMinute.Location = new Point(182, 141);
            lblMinute.Name = "lblMinute";
            lblMinute.Size = new Size(34, 25);
            lblMinute.TabIndex = 1;
            lblMinute.Text = "00";
            // 
            // lblSec
            // 
            lblSec.AutoSize = true;
            lblSec.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSec.Location = new Point(256, 141);
            lblSec.Name = "lblSec";
            lblSec.Size = new Size(34, 25);
            lblSec.TabIndex = 2;
            lblSec.Text = "00";
            // 
            // lblSplitSec
            // 
            lblSplitSec.AutoSize = true;
            lblSplitSec.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSplitSec.Location = new Point(329, 141);
            lblSplitSec.Name = "lblSplitSec";
            lblSplitSec.Size = new Size(34, 25);
            lblSplitSec.TabIndex = 3;
            lblSplitSec.Text = "00";
            // 
            // btnBaslat
            // 
            btnBaslat.BackColor = SystemColors.HighlightText;
            btnBaslat.Location = new Point(411, 184);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(110, 44);
            btnBaslat.TabIndex = 8;
            btnBaslat.Text = "Başlat";
            btnBaslat.UseVisualStyleBackColor = false;
            btnBaslat.Click += btnBaslat_Click;
            // 
            // timer
            // 
            timer.Interval = 50;
            timer.Tick += ClockTimer_Tick;
            // 
            // lblSplitSec2
            // 
            lblSplitSec2.AutoSize = true;
            lblSplitSec2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSplitSec2.Location = new Point(329, 203);
            lblSplitSec2.Name = "lblSplitSec2";
            lblSplitSec2.Size = new Size(34, 25);
            lblSplitSec2.TabIndex = 12;
            lblSplitSec2.Text = "00";
            // 
            // lblSec2
            // 
            lblSec2.AutoSize = true;
            lblSec2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSec2.Location = new Point(256, 203);
            lblSec2.Name = "lblSec2";
            lblSec2.Size = new Size(34, 25);
            lblSec2.TabIndex = 11;
            lblSec2.Text = "00";
            // 
            // lblMinute2
            // 
            lblMinute2.AutoSize = true;
            lblMinute2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMinute2.Location = new Point(182, 203);
            lblMinute2.Name = "lblMinute2";
            lblMinute2.Size = new Size(34, 25);
            lblMinute2.TabIndex = 10;
            lblMinute2.Text = "00";
            // 
            // lblHours2
            // 
            lblHours2.AutoSize = true;
            lblHours2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblHours2.Location = new Point(106, 203);
            lblHours2.Name = "lblHours2";
            lblHours2.Size = new Size(34, 25);
            lblHours2.TabIndex = 9;
            lblHours2.Text = "00";
            // 
            // Sonuc
            // 
            Sonuc.AutoSize = true;
            Sonuc.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Sonuc.Location = new Point(143, 280);
            Sonuc.Margin = new Padding(4, 0, 4, 0);
            Sonuc.Name = "Sonuc";
            Sonuc.Size = new Size(173, 23);
            Sonuc.TabIndex = 13;
            Sonuc.Text = "Süreç Tamamlandı.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(Sonuc);
            Controls.Add(lblSplitSec2);
            Controls.Add(lblSec2);
            Controls.Add(lblMinute2);
            Controls.Add(lblHours2);
            Controls.Add(btnBaslat);
            Controls.Add(lblSplitSec);
            Controls.Add(lblSec);
            Controls.Add(lblMinute);
            Controls.Add(lblHours);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHours;
        private Label lblMinute;
        private Label lblSec;
        private Label lblSplitSec;
        private Button btnBaslat;
        private System.Windows.Forms.Timer timer;
        private Label lblSplitSec2;
        private Label lblSec2;
        private Label lblMinute2;
        private Label lblHours2;
        private Label Sonuc;
    }
}