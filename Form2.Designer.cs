namespace ornek1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.saat1 = new System.Windows.Forms.Label();
            this.dk1 = new System.Windows.Forms.Label();
            this.sn1 = new System.Windows.Forms.Label();
            this.ss1 = new System.Windows.Forms.Label();
            this.saat2 = new System.Windows.Forms.Label();
            this.dk2 = new System.Windows.Forms.Label();
            this.sn2 = new System.Windows.Forms.Label();
            this.ss2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Sonuc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(412, 118);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "BASLA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saat1
            // 
            this.saat1.AutoSize = true;
            this.saat1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.saat1.Location = new System.Drawing.Point(94, 84);
            this.saat1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saat1.Name = "saat1";
            this.saat1.Size = new System.Drawing.Size(45, 24);
            this.saat1.TabIndex = 1;
            this.saat1.Text = "Saat";
            // 
            // dk1
            // 
            this.dk1.AutoSize = true;
            this.dk1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dk1.Location = new System.Drawing.Point(168, 84);
            this.dk1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dk1.Name = "dk1";
            this.dk1.Size = new System.Drawing.Size(33, 24);
            this.dk1.TabIndex = 1;
            this.dk1.Text = "DK";
            // 
            // sn1
            // 
            this.sn1.AutoSize = true;
            this.sn1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sn1.Location = new System.Drawing.Point(241, 84);
            this.sn1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sn1.Name = "sn1";
            this.sn1.Size = new System.Drawing.Size(30, 24);
            this.sn1.TabIndex = 1;
            this.sn1.Text = "Sn";
            // 
            // ss1
            // 
            this.ss1.AutoSize = true;
            this.ss1.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ss1.Location = new System.Drawing.Point(315, 84);
            this.ss1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ss1.Name = "ss1";
            this.ss1.Size = new System.Drawing.Size(28, 24);
            this.ss1.TabIndex = 1;
            this.ss1.Text = "Ss";
            // 
            // saat2
            // 
            this.saat2.AutoSize = true;
            this.saat2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.saat2.Location = new System.Drawing.Point(94, 161);
            this.saat2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saat2.Name = "saat2";
            this.saat2.Size = new System.Drawing.Size(45, 24);
            this.saat2.TabIndex = 1;
            this.saat2.Text = "Saat";
            // 
            // dk2
            // 
            this.dk2.AutoSize = true;
            this.dk2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dk2.Location = new System.Drawing.Point(168, 161);
            this.dk2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dk2.Name = "dk2";
            this.dk2.Size = new System.Drawing.Size(33, 24);
            this.dk2.TabIndex = 1;
            this.dk2.Text = "DK";
            // 
            // sn2
            // 
            this.sn2.AutoSize = true;
            this.sn2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sn2.Location = new System.Drawing.Point(241, 161);
            this.sn2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sn2.Name = "sn2";
            this.sn2.Size = new System.Drawing.Size(30, 24);
            this.sn2.TabIndex = 1;
            this.sn2.Text = "Sn";
            // 
            // ss2
            // 
            this.ss2.AutoSize = true;
            this.ss2.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ss2.Location = new System.Drawing.Point(315, 161);
            this.ss2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ss2.Name = "ss2";
            this.ss2.Size = new System.Drawing.Size(28, 24);
            this.ss2.TabIndex = 1;
            this.ss2.Text = "Ss";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Sonuc
            // 
            this.Sonuc.AutoSize = true;
            this.Sonuc.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Sonuc.Location = new System.Drawing.Point(218, 222);
            this.Sonuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Sonuc.Name = "Sonuc";
            this.Sonuc.Size = new System.Drawing.Size(173, 24);
            this.Sonuc.TabIndex = 2;
            this.Sonuc.Text = "Süreç Tamamlandı.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(600, 294);
            this.Controls.Add(this.Sonuc);
            this.Controls.Add(this.ss2);
            this.Controls.Add(this.ss1);
            this.Controls.Add(this.sn2);
            this.Controls.Add(this.sn1);
            this.Controls.Add(this.dk2);
            this.Controls.Add(this.dk1);
            this.Controls.Add(this.saat2);
            this.Controls.Add(this.saat1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Sitka Small", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label saat1;
        private System.Windows.Forms.Label dk1;
        private System.Windows.Forms.Label sn1;
        private System.Windows.Forms.Label ss1;
        private System.Windows.Forms.Label saat2;
        private System.Windows.Forms.Label dk2;
        private System.Windows.Forms.Label sn2;
        private System.Windows.Forms.Label ss2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Sonuc;
    }
}