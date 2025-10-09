using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama3
{
    public partial class Form1 : Form
    {
        //Ayarlar 
        private Timer sayac;              // saniyelik sayaç
        private int adim = 20;            // her tikte kaç piksel ilerleyeceği
        private bool disari = true;       // true: köşelere, false: merkeze dönüş

        // Butonların Yerleşimi 
        private Button[] btns;
        private Point[] baslangic;        // başlangıç  noktası
        private Point[] yon = new Point[]
        {
            new Point(-1,-1), // button1: sol-üst
            new Point(+1,-1), // button2: sağ-üst
            new Point(-1,+1), // button3: sol-alt
            new Point(+1,+1)  // button4: sağ-alt
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 4 butonu diziye al
            btns = new[] { button1, button2, button3, button4 };

            // başlangıç konumları

            baslangic = new Point[btns.Length];
            for (int i = 0; i < btns.Length; i++)
                baslangic[i] = new Point(btns[i].Left, btns[i].Top);

            // sayaç (Timer) = 0.1 saniye
            sayac = new Timer();
            sayac.Interval = 100; //0.1 saniye
            sayac.Tick += Sayac_Tick;
            sayac.Start();
        }
        private void Sayac_Tick(object sender, EventArgs e)
        {
            // 1) HAREKET: for ile 4 butonu gez, SetBounds ile yeni pozisyon ver
            for (int i = 0; i < btns.Length; i++)
            {
                var b = btns[i];
                int dx = yon[i].X * (disari ? adim : -adim);
                int dy = yon[i].Y * (disari ? adim : -adim);

                int nx = b.Left + dx;
                int ny = b.Top + dy;

                // SetBounds(x, y, w, h)
                b.SetBounds(nx, ny, b.Width, b.Height);
            }

            // 2) YÖN DEĞİŞTİRME KOŞULLARI
            if (disari)
            {
                // Dışarı giderken: herhangi bir buton kenara yeterince yaklaştı mı?
                for (int i = 0; i < btns.Length; i++)
                {
                    var b = btns[i];
                    bool tasiyor =
                        b.Left <= 0 ||
                        b.Top <= 0 ||
                        b.Right >= this.ClientSize.Width ||
                        b.Bottom >= this.ClientSize.Height;

                    if (tasiyor)
                    {
                        disari = false; // geri dön
                        break;
                    }
                }
            }
            else
            {
                // Merkeze dönerken: merkezlere yeterince yaklaştıysa tam oturt ve tekrar dışarı git
                bool hepsiMerkezde = true;

                for (int i = 0; i < btns.Length; i++)
                {
                    var b = btns[i];
                    var c = baslangic[i];

                    // tolerans: adim kadar yakınsa merkeze sabitle
                    if (Math.Abs(b.Left - c.X) <= adim && Math.Abs(b.Top - c.Y) <= adim)
                    {
                        b.SetBounds(c.X, c.Y, b.Width, b.Height);
                    }
                    else
                    {
                        hepsiMerkezde = false;
                    }
                }

                if (hepsiMerkezde)
                    disari = true; // tekrar köşelere
            }
        }
    }
}
