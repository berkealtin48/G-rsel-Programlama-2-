using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace CiftleriSiraylaTikla
{
    public partial class Form1 : Form
    {
        // --- Oyun ayarları ---
        private const int BUTTON_COUNT = 12;   // Üretilecek buton adedi
        private const int MIN_VALUE = 1;       // Sayı alt sınır
        private const int MAX_VALUE = 99;      // Sayı üst sınır
        private const int BTN_W = 56;          // Buton genişlik
        private const int BTN_H = 36;          // Buton yükseklik
        private const int GAME_SECONDS = 60;   // Toplam süre

        // --- UI ---
        private Panel pnlArena;         // Oyun alanı (solda)
        private Panel pnlRight;         // Sağ bilgi paneli
        private Button btnStart;        // Oyunu başlat
        private Button btnFinish;       // Oyunu bitir
        private Label lblTimeTitle;     // "SÜRE"
        private Label lblTime;          // kalan süre (sn)
        private ListBox lstSequence;    // sağ panel: tıklanan çiftlerin sıralı listesi

        // --- Oyun durumu ---
        private readonly Random rnd = new Random();
        private int timeLeft = GAME_SECONDS;
        private Timer gameTimer;
        private bool isRunning = false;

        // yeni: toplam/kalan çift takibi
        private int totalEvenCount = 0;    // sahadaki toplam çift sayısı
        private int clickedEvenCount = 0;  // sağ listeye aktarılmış çift sayısı

        public Form1()
        {
            Text = "Çiftleri Sırayla Tıkla";
            MinimumSize = new Size(880, 560);
            StartPosition = FormStartPosition.CenterScreen;

            // Sol oyun alanı
            pnlArena = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Gainsboro,
                Padding = new Padding(16)
            };
            Controls.Add(pnlArena);

            // Sağ panel
            pnlRight = new Panel
            {
                Dock = DockStyle.Right,
                BackColor = Color.WhiteSmoke,
                Width = 240
            };
            Controls.Add(pnlRight);

            btnStart = new Button
            {
                Text = "OYUNA BAŞLA",
                Width = 180,
                Height = 40,
                Location = new Point(30, 24)
            };
            btnStart.Click += (_, __) => StartGame();
            pnlRight.Controls.Add(btnStart);

            btnFinish = new Button
            {
                Text = "OYUNU BİTİR",
                Width = 180,
                Height = 40,
                Location = new Point(30, 74),
                Enabled = false
            };
            btnFinish.Click += (_, __) => FinishGame();
            pnlRight.Controls.Add(btnFinish);

            lblTimeTitle = new Label
            {
                Text = "SÜRE",
                Location = new Point(30, 130),
                AutoSize = true,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold)
            };
            pnlRight.Controls.Add(lblTimeTitle);

            lblTime = new Label
            {
                Text = "60 sn",
                Location = new Point(30, 150),
                AutoSize = true,
                Font = new Font("Segoe UI", 14f, FontStyle.Bold)
            };
            pnlRight.Controls.Add(lblTime);

            lstSequence = new ListBox
            {
                Location = new Point(30, 200),
                Size = new Size(180, 280)
            };
            pnlRight.Controls.Add(lstSequence);

            gameTimer = new Timer { Interval = 1000 };
            gameTimer.Tick += GameTimer_Tick;
        }

        private void StartGame()
        {
            // Sıfırla
            isRunning = true;
            timeLeft = GAME_SECONDS;
            lblTime.Text = $"{timeLeft} sn";
            lstSequence.Items.Clear();       // sağ panel BAŞLANGIÇTA boş
            pnlArena.Controls.Clear();
            btnFinish.Enabled = true;

            // Rastgele butonlar üret
            var values = new List<int>();
            while (values.Count < BUTTON_COUNT)
            {
                int n = rnd.Next(MIN_VALUE, MAX_VALUE + 1);
                if (!values.Contains(n)) values.Add(n);
            }

            // Sahadaki toplam çift sayısını hesapla
            totalEvenCount = values.Count(v => v % 2 == 0);
            clickedEvenCount = 0;

            // Butonları panele yerleştir (çakışmasız rastgele basit yerleşim)
            var placed = new List<Rectangle>();
            foreach (int val in values)
            {
                var btn = new Button
                {
                    Text = val.ToString(),
                    Size = new Size(BTN_W, BTN_H),
                    Tag = val
                };
                btn.Click += NumberButton_Click;

                int tries = 0;
                while (true)
                {
                    int x = rnd.Next(0, Math.Max(1, pnlArena.ClientSize.Width - BTN_W));
                    int y = rnd.Next(0, Math.Max(1, pnlArena.ClientSize.Height - BTN_H));
                    var rect = new Rectangle(new Point(x, y), btn.Size);
                    if (!placed.Any(r => r.IntersectsWith(rect)))
                    {
                        btn.Location = new Point(x, y);
                        placed.Add(rect);
                        break;
                    }
                    if (++tries > 200)
                    {
                        btn.Location = new Point(10 * (placed.Count % 10), 10 * (placed.Count / 10));
                        placed.Add(rect);
                        break;
                    }
                }
                pnlArena.Controls.Add(btn);
            }

            gameTimer.Start();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (!isRunning) return;
            var btn = (Button)sender;
            int value = (int)btn.Tag;

            if (value % 2 != 0)
            {
                SystemSounds.Beep.Play();
                FlashControl(btn, Color.LightYellow);
                return;
            }

            pnlArena.Controls.Remove(btn);
            btn.Dispose();

            lstSequence.Items.Add(value);
            SortRightListAscending();

            clickedEvenCount++;
            if (clickedEvenCount >= totalEvenCount)
            {
                WinAndStop();
            }
        }

        private async void FlashControl(Control c, Color flash)
        {
            var original = c.BackColor;
            c.BackColor = flash;
            await System.Threading.Tasks.Task.Delay(200);
            c.BackColor = original;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft < 0) timeLeft = 0;
            lblTime.Text = $"{timeLeft} sn";

            if (timeLeft == 0)
            {
                LoseAndStop();
            }
        }

        private void FinishGame()
        {
            if (!isRunning) return;

            if (clickedEvenCount >= totalEvenCount)
            {
                WinAndStop();
            }
            else
            {
                int remaining = totalEvenCount - clickedEvenCount;
                MessageBox.Show($"Kalan çift sayısı: {remaining}", "Oyun Bitti",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                StopGame();
            }
        }

        private void WinAndStop()
        {
            int kalanSure = timeLeft; // kaç saniye kala bitirdiğini hesapla
            MessageBox.Show($"Tebrikler! {kalanSure} saniye kala oyunu doğru bitirdin!",
                "Kazandın", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StopGame();
        }

        private void LoseAndStop()
        {
            MessageBox.Show("Süre bitti!", "Kaybettin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            StopGame();
        }

        private void StopGame()
        {
            isRunning = false;
            gameTimer.Stop();
            btnFinish.Enabled = false;
        }

        private void SortRightListAscending()
        {
            var list = lstSequence.Items.Cast<int>().OrderBy(x => x).ToList();
            lstSequence.Items.Clear();
            foreach (var x in list) lstSequence.Items.Add(x);
        }
    }
}