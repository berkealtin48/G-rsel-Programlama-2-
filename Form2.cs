

namespace ornek1
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (isFirst)
            {
                targetTime = DateTime.Now;  // Saati kaydet.

                //Sayaç Testi:
                //targetTime = DateTime.Today + new TimeSpan(0, 0, 1); // 00:00:01; 

                timer1.Interval = 1;    // 1 ms hassasiyet
                timer1.Start();
                button1.Enabled = false;    // Buton pasif
                isFirst = false;
            }
            else
            {
                // İkinci tıklama: mevcut sayaç değerlerini diğer label’lara aktar
                saat2.Text = saat1.Text;
                dk2.Text = dk1.Text;
                sn2.Text = sn1.Text;
                ss2.Text = ss1.Text;
                counter = 0;
                button1.Enabled = false;
                timer1.Stop();

                // Geri sayacak süreyi hesapla
                int saat = int.Parse(saat2.Text);
                int dk = int.Parse(dk2.Text);
                int sn = int.Parse(sn2.Text);
                int ss = int.Parse(ss2.Text);

                countdownTime = new TimeSpan(saat, dk, sn).Add(TimeSpan.FromMilliseconds(ss));

                isCountingDown = true;
                button1.Enabled = false;
                timer1.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;     // Başlangıçta buton aktif
            Sonuc.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isCountingDown)
            {
                // Sayaç = sistem saatinden 5 dakika gerisi
                //DateTime currentCounterTime = DateTime.Now.AddMinutes(-1);

                // Geçen süreyi hesapla
                counter += timer1.Interval; // toplam milisaniye
                TimeSpan elapsed = TimeSpan.FromMilliseconds(counter);

                // Geçerli sayaç zamanı
                DateTime currentCounterTime = startTime + elapsed;

                // Label’ları güncelle
                saat1.Text = currentCounterTime.Hour.ToString("00");
                dk1.Text = currentCounterTime.Minute.ToString("00");
                sn1.Text = currentCounterTime.Second.ToString("00");
                ss1.Text = currentCounterTime.Millisecond.ToString("000");


                TimeSpan counterTime = currentCounterTime.TimeOfDay;
                TimeSpan targetTimeOfDay = targetTime.TimeOfDay;

                // Sistem saatine yaklaştı mı kontrol edilecek
                if (counterTime >= targetTimeOfDay)
                {
                    button1.Enabled = true;
                }

            }
            else
            {
                // Geri sayım
                if (countdownTime.TotalMilliseconds <= 0)
                {
                    // Sayaç sıfırlandı, dur
                    timer1.Stop();
                    isCountingDown = false;
                    //button1.Enabled = true;
                    saat2.Text = "00";
                    dk2.Text = "00";
                    sn2.Text = "00";
                    ss2.Text = "000";

                    //Sonuç yazısını göster
                    Sonuc.Visible = true;

                    return;
                }

                // Geri say
                countdownTime = countdownTime - TimeSpan.FromMilliseconds(timer1.Interval);

                saat2.Text = countdownTime.Hours.ToString("00");
                dk2.Text = countdownTime.Minutes.ToString("00");
                sn2.Text = countdownTime.Seconds.ToString("00");
                ss2.Text = countdownTime.Milliseconds.ToString("000");
            }

        }

    }
}