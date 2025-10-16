using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CiftleriSiraylaTikla
{
    public partial class Form1 : Form
    {
        // --- Oyun ayarları ---
        private const int BUTTON_COUNT = 10;   // Oyun alanına gelecek sayı adedi
        private const int MIN_VALUE = 1;       // Sayı alt sınır
        private const int MAX_VALUE = 100;     // Sayı üst sınır
        private const int BTN_W = 56;          // Buton genişlik
        private const int BTN_H = 36;          // Buton yükseklik
        private const int GAME_SECONDS = 60;   // Toplam süre (1 dakika)

        // --- Durum ---
        private readonly Random rnd = new Random();
        private List<int> values = new List<int>();           // Paneldeki 10 sayı
        private List<int> clickedSequence = new List<int>();  // Oyuncunun tıkladığı çiftler (sırasıyla)
        private int timeLeft = GAME_SECONDS;
        private bool isRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Oyuna Başla
        private void btnStart_Click(object sender, EventArgs e)
        {
            // --- Sıfırla ---
            isRunning = true;
            timeLeft = GAME_SECONDS;
            lblTime.Text = FormatTime(timeLeft);
            clickedSequence.Clear();
            lstSequence.Items.Clear();
            pnlArena.Controls.Clear();      // Paneli tamamen temizliyoruz
            btnFinish.Enabled = true;

            // Timer ayarı ve başlatma
            if (gameTimer == null) gameTimer = new Timer(); // (Designer’dan ekli değilse güvence)
            gameTimer.Interval = 1000;
            gameTimer.Tick -= gameTimer_Tick; // çift bağlanmayı engelle
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();

            // 1) 10 benzersiz rastgele sayı üret (1..100)
            values = UniqueRandoms(BUTTON_COUNT, MIN_VALUE, MAX_VALUE);

            // 2) Butonları panel içine çakışmasız yerleştir
            var placed = new List<Rectangle>();
            foreach (int val in values)
            {
                var btn = new Button
                {
                    Text = val.ToString(),
                    Size = new Size(BTN_W, BTN_H),
                    Tag = val,
                    BackColor = Color.White
                };
                btn.Click += NumberButton_Click;

                // Basit çakışmasız rastgele yerleşim
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
                        // çok sıkışırsa basit bir grid fallback
                        btn.Location = new Point(10 + (placed.Count % 8) * 70, 10 + (placed.Count / 8) * 50);
                        placed.Add(rect);
                        break;
                    }
                }
                pnlArena.Controls.Add(btn);
            }
        }

        // mm:ss formatı
        private string FormatTime(int seconds)
        {
            int m = seconds / 60;
            int s = seconds % 60;
            return $"{m:D1}:{s:D2}";
        }

        // Oyuncu bir sayıya tıklayınca
        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (!isRunning) return;

            var btn = (Button)sender;
            int value = (int)btn.Tag;

            // Yalnızca ÇİFTLER seçilecek ve seçilenler kullanıcının tıkladığı sırada listelenir.
            if (value % 2 != 0)
            {
                // Tek sayıya tıklama -> yok say
                return;
            }

            if (!btn.Enabled) return; // bir daha eklenmesin

            btn.Enabled = false;
            btn.BackColor = Color.MistyRose; // görsel geri bildirim (opsiyonel)

            // Seçilen çift sayıyı sıraya ekle ve sağdaki listede göster
            clickedSequence.Add(value);
            lstSequence.Items.Add(value);
        }

        // Oyunu Bitir - kontrol burada yapılacak
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!isRunning) return;

            // 1) Doğru sıra: sahadaki TÜM çiftler (values içindeki), KÜÇÜKTEN BÜYÜĞE
            var expected = values.Where(v => v % 2 == 0).OrderBy(v => v).ToList();

            // 2) Oyuncunun bastığı sıra: clickedSequence (dokunmadan, olduğu gibi)
            bool ok = clickedSequence.SequenceEqual(expected);

            gameTimer.Stop();
            isRunning = false;
            btnFinish.Enabled = false;

            if (ok)
            {
                MessageBox.Show($"Tebrikler! {timeLeft} saniye kala oyunu doğru bitirdiniz.",
                                "Kazandınız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Oyunu yanlış bitirdiniz. Tekrar oynayın!",
                                "Hatalı Sıra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Timer – geri sayım
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!isRunning) return;

            timeLeft--;
            if (timeLeft < 0) timeLeft = 0;

            // ekranda mm:ss güncelle
            lblTime.Text = FormatTime(timeLeft);

            if (timeLeft == 0)
            {
                gameTimer.Stop();
                isRunning = false;
                btnFinish.Enabled = false;
                MessageBox.Show("Süre bitti!", "Kaybettiniz",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Yardımcı: benzersiz rastgeleler
        private List<int> UniqueRandoms(int count, int min, int max)
        {
            var set = new HashSet<int>();
            while (set.Count < count)
                set.Add(rnd.Next(min, max + 1));
            return set.ToList();
        }
    }
}