using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Görsel_Programlama_Hafta_1
{
    public partial class Form1 : Form
    {
        private DateTime targetTime;    // Hedef Saat kaydı.
        private bool isFirst = true;
        private DateTime startTime;     // Sayaç başlangıç zamanı
        private int counter = 0;

        private bool isCountingDown = false;
        private TimeSpan countdownTime;   // Geri sayacak süre

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBaslat.Enabled = true;     // Başlangıçta buton aktif
            Sonuc.Visible = false;
        }


        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            if (!isCountingDown)
            {
                // Sayaç = sistem saatinden 5 dakika gerisi
                //DateTime currentCounterTime = DateTime.Now.AddMinutes(-1);

                // Geçen süreyi hesapla
                counter += timer.Interval; // toplam milisaniye
                TimeSpan elapsed = TimeSpan.FromMilliseconds(counter);

                // Geçerli sayaç zamanı
                DateTime currentCounterTime = startTime + elapsed;

                // Label’ları güncelle
                lblHours.Text = currentCounterTime.Hour.ToString("00");
                lblMinute.Text = currentCounterTime.Minute.ToString("00");
                lblSec.Text = currentCounterTime.Second.ToString("00");
                lblSplitSec.Text = currentCounterTime.Millisecond.ToString("000");


                TimeSpan counterTime = currentCounterTime.TimeOfDay;
                TimeSpan targetTimeOfDay = targetTime.TimeOfDay;

                // Sistem saatine yaklaştı mı kontrol edilecek
                if (counterTime >= targetTimeOfDay)
                {
                    btnBaslat.Enabled = true;
                }

            }
            else
            {
                // Geri sayım
                if (countdownTime.TotalMilliseconds <= 0)
                {
                    // Sayaç sıfırlandı, dur
                    timer.Stop();
                    isCountingDown = false;
                    //button1.Enabled = true;
                    lblHours2.Text = "00";
                    lblMinute2.Text = "00";
                    lblSec2.Text = "00";
                    lblSplitSec2.Text = "000";

                    //Sonuç yazısını göster
                    Sonuc.Visible = true;

                    return;
                }

                // Geri say
                countdownTime = countdownTime - TimeSpan.FromMilliseconds(timer.Interval);

                lblHours2.Text = countdownTime.Hours.ToString("00");
                lblMinute2.Text = countdownTime.Minutes.ToString("00");
                lblSec2.Text = countdownTime.Seconds.ToString("00");
                lblSplitSec2.Text = countdownTime.Milliseconds.ToString("000");
            }

        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            {
                if (isFirst)
                {
                    targetTime = DateTime.Now;  // Saati kaydet.

                    //Sayaç Testi:
                    targetTime = DateTime.Today + new TimeSpan(0, 0, 1); // 00:00:01; 

                    timer.Interval = 10;    // 1 ms hassasiyet
                    timer.Start();
                    btnBaslat.Enabled = false;    // Buton pasif
                    isFirst = false;
                }
                else
                {
                    // İkinci tıklama: mevcut sayaç değerlerini diğer label’lara aktar
                    lblHours2.Text = lblHours.Text;
                    lblMinute2.Text = lblMinute.Text;
                    lblSec2.Text = lblSec.Text;
                    lblSplitSec2.Text = lblSplitSec.Text;
                    counter = 0;
                    btnBaslat.Enabled = false;
                    timer.Stop();

                    // Geri sayacak süreyi hesapla
                    int saat = int.Parse(lblHours2.Text);
                    int dk = int.Parse(lblMinute2.Text);
                    int sn = int.Parse(lblSec2.Text);
                    int ss = int.Parse(lblSplitSec2.Text);

                    countdownTime = new TimeSpan(saat, dk, sn).Add(TimeSpan.FromMilliseconds(ss));

                    isCountingDown = true;
                    btnBaslat.Enabled = false;
                    timer.Start();
                }
            }
        }
    }
}
