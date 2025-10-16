namespace CiftleriSiraylaTikla
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


        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lstSequence = new System.Windows.Forms.ListBox();
            this.pnlArena = new System.Windows.Forms.Panel();
            this.lblArenaTitle = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.pnlArena.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 180);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 57);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Oyuna Başla";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(682, 180);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(106, 67);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "Oyunu Bitir";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lstSequence
            // 
            this.lstSequence.FormattingEnabled = true;
            this.lstSequence.Location = new System.Drawing.Point(556, 65);
            this.lstSequence.Name = "lstSequence";
            this.lstSequence.Size = new System.Drawing.Size(120, 368);
            this.lstSequence.TabIndex = 2;
            // 
            // pnlArena
            // 
            this.pnlArena.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlArena.Controls.Add(this.lblArenaTitle);
            this.pnlArena.Location = new System.Drawing.Point(122, 65);
            this.pnlArena.Name = "pnlArena";
            this.pnlArena.Size = new System.Drawing.Size(414, 368);
            this.pnlArena.TabIndex = 3;
            // 
            // lblArenaTitle
            // 
            this.lblArenaTitle.AutoSize = true;
            this.lblArenaTitle.Location = new System.Drawing.Point(18, 13);
            this.lblArenaTitle.Name = "lblArenaTitle";
            this.lblArenaTitle.Size = new System.Drawing.Size(58, 13);
            this.lblArenaTitle.TabIndex = 5;
            this.lblArenaTitle.Text = "Oyun Alanı";
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(722, 271);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(28, 13);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "1:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pnlArena);
            this.Controls.Add(this.lstSequence);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlArena.ResumeLayout(false);
            this.pnlArena.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.ListBox lstSequence;
        private System.Windows.Forms.Panel pnlArena;
        private System.Windows.Forms.Label lblArenaTitle;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblTime;
    }
}

