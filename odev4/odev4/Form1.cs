using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev4
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int score = 0;
        Rectangle hedefBolge;
        Button btn;

        private void Form1_Load(object sender, EventArgs e)
        {
            int bolgeGenislik = 350;
            int bolgeYukseklik = 250;
            int x = (this.ClientSize.Width - bolgeGenislik) / 2;
            int y = (this.ClientSize.Height - bolgeYukseklik) / 2;
            hedefBolge = new Rectangle(x, y, bolgeGenislik, bolgeYukseklik);

            // Buton oluştur
            btn = new Button();
            btn.Width = 35;
            btn.Height = 25;
            btn.Click += Btn_Click;
            this.Controls.Add(btn);

            // Timer başlat
            timer1.Interval = 1000;
            timer1.Start();

            lblScore.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            //sayılar düzeltilcek
            int sayi = rnd.Next(1, 11);
            btn.Text = sayi.ToString();

            int x = rnd.Next(0, this.ClientSize.Width - btn.Width);
            int y = rnd.Next(0, this.ClientSize.Height - btn.Height);
            btn.SetBounds(x, y, btn.Width, btn.Height);

            // Bölge kontrolü
            if (hedefBolge.Contains(btn.Bounds))
                btn.ForeColor = Color.Red;
            else
                btn.ForeColor = Color.Black;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int sayi = int.Parse(btn.Text);

            if (btn.ForeColor == Color.Red)
                score += sayi;
            else
                score -= sayi;

            lblScore.Text = score.ToString();

            if (score >= 100)
            {
                timer1.Stop();
                MessageBox.Show("Tebrikler! 100 puana ulaştınız 🎉");
            }
        }       
    }
}
