using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using Newtonsoft.Json;

namespace Noisekun
{
    public partial class MainWindow : Form
    {
        static float gVolume = 1;
        int pomoTimeCount = 0;
        private MediaPlayer mediaPlayer1;
        private MediaPlayer mediaPlayer2;
        private MediaPlayer mediaPlayer3;
        private MediaPlayer mediaPlayer4;
        private MediaPlayer mediaPlayer5;
        private MediaPlayer mediaPlayer6;
        private MediaPlayer mediaPlayer7;
        private MediaPlayer mediaPlayer8;
        private MediaPlayer mediaPlayer9;
        private MediaPlayer mediaPlayer10;
        private MediaPlayer mediaPlayer11;
        private MediaPlayer mediaPlayer12;
        private MediaPlayer mediaPlayer13;
        private MediaPlayer mediaPlayer14;
        private MediaPlayer mediaPlayer15;
        private MediaPlayer mediaPlayer16;
        private MediaPlayer mediaPlayer17;
        private MediaPlayer mediaPlayer18;
        private MediaPlayer mediaPlayer19;
        private MediaPlayer mediaPlayer20;
        private MediaPlayer mediaPlayer21;
        private MediaPlayer mediaPlayer22;
        private MediaPlayer mediaPlayer23;

        private Dictionary<PictureBox, MediaPlayer> picPlayer;
        private Dictionary<TrackBar, MediaPlayer> trackPlayer;
        private Dictionary<PictureBox, TrackBar> picTrack;

        private Dictionary<int, PictureBox> picBoxId;

        Point pomoConfigOn;
        Point pomoConfigOff;

        class PlayerState
        {
            public bool Played { get; set; }
            public float Volume { get; set; }
        }

        private Dictionary<string, PlayerSnapshot> comboSnapshot;

        class PlayerSnapshot
        {
            public Dictionary<int, PlayerState> PlayerStateId;
            public PlayerSnapshot()
            {
                PlayerStateId = new Dictionary<int, PlayerState>();
            }
            public void storeSnapshot(Dictionary<int, PictureBox> picBoxId, Dictionary<PictureBox, TrackBar> picTrack)
            {
                foreach (var kvp in picBoxId)
                {
                    if (PlayerStateId.ContainsKey(kvp.Key) == false)
                    {
                        PlayerStateId[kvp.Key] = new PlayerState();
                    }
                    PlayerStateId[kvp.Key].Played = (kvp.Value.BackColor == SystemColors.ControlLight);
                    PlayerStateId[kvp.Key].Volume = (float)picTrack[kvp.Value].Value / picTrack[kvp.Value].Maximum * MainWindow.gVolume;
                }
            }
            public void loadSnapshot(Dictionary<int, PictureBox> picBoxId, Dictionary<PictureBox, TrackBar> picTrack, Dictionary<PictureBox, MediaPlayer> picPlayer)
            {
                foreach (var kvp in picBoxId)
                {
                    picTrack[kvp.Value].Value = (int)(PlayerStateId[kvp.Key].Volume / MainWindow.gVolume * picTrack[kvp.Value].Maximum);
                    picPlayer[kvp.Value].Volume = PlayerStateId[kvp.Key].Volume;
                    if (PlayerStateId[kvp.Key].Played && (kvp.Value.BackColor != SystemColors.ControlLight))
                    {
                        picPlayer[kvp.Value].Play();
                        picTrack[kvp.Value].Visible = true;
                        kvp.Value.BackColor = SystemColors.ControlLight;
                    } else if  (PlayerStateId[kvp.Key].Played==false && (kvp.Value.BackColor == SystemColors.ControlLight))
                    {
                        picPlayer[kvp.Value].Stop();
                        picTrack[kvp.Value].Visible = false;
                        kvp.Value.BackColor = SystemColors.Control;
                    }
                }
            }
        }

        static class HistoryManager
        {
            static public Dictionary<string, PlayerSnapshot> LoadHistory()
            {
                Dictionary<string, PlayerSnapshot> history;
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string jsonFilePath = Path.Combine(baseDirectory, "history.json");
                if (System.IO.File.Exists(jsonFilePath))
                {
                    // Đọc toàn bộ nội dung của tệp JSON
                    string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
                    // Chuyển đổi JSON thành đối tượng
                    history = JsonConvert.DeserializeObject<Dictionary<string, PlayerSnapshot>>(jsonContent);
                } else
                {
                    history = new Dictionary<string, PlayerSnapshot>();
                }
                if (history == null)
                {
                    history = new Dictionary<string, PlayerSnapshot>();
                }
                return history;
            }

            static public void StoreHistory(Dictionary<string, PlayerSnapshot> history)
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string jsonFilePath = Path.Combine(baseDirectory, "history.json");
                string jsonContent = JsonConvert.SerializeObject(history, Formatting.Indented);
                System.IO.File.WriteAllText(jsonFilePath, jsonContent);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.MaximumSize = new Size(305, 545);
            pomoConfigOn = new Point(14, 5);
            pomoConfigOff = new Point(325, 5);

            picPlayer = new Dictionary<PictureBox, MediaPlayer>();
            trackPlayer = new Dictionary<TrackBar, MediaPlayer>();
            picTrack = new Dictionary<PictureBox, TrackBar>();

            picBoxId = new Dictionary<int, PictureBox>();
            comboSnapshot = HistoryManager.LoadHistory();

            mediaPlayer1 = new MediaPlayer();
            mediaPlayer2 = new MediaPlayer();
            mediaPlayer3 = new MediaPlayer();
            mediaPlayer4 = new MediaPlayer();
            mediaPlayer5 = new MediaPlayer();
            mediaPlayer6 = new MediaPlayer();
            mediaPlayer7 = new MediaPlayer();
            mediaPlayer8 = new MediaPlayer();
            mediaPlayer9 = new MediaPlayer();
            mediaPlayer10 = new MediaPlayer();
            mediaPlayer11 = new MediaPlayer();
            mediaPlayer12 = new MediaPlayer();
            mediaPlayer13 = new MediaPlayer();
            mediaPlayer14 = new MediaPlayer();
            mediaPlayer15 = new MediaPlayer();
            mediaPlayer16 = new MediaPlayer();
            mediaPlayer17 = new MediaPlayer();
            mediaPlayer18 = new MediaPlayer();
            mediaPlayer19 = new MediaPlayer();
            mediaPlayer20 = new MediaPlayer();
            mediaPlayer21 = new MediaPlayer();
            mediaPlayer22 = new MediaPlayer();
            mediaPlayer23 = new MediaPlayer();
            mediaPlayer1.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer2.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer3.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer4.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer5.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer6.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer7.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer8.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer9.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer10.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer11.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer12.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer13.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer14.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer15.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer16.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer17.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer18.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer19.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer20.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer21.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer22.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer23.MediaEnded += MediaPlayer_MediaEnded;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            mediaPlayer1.Open(new Uri(Path.Combine(baseDirectory, "sounds", "rain.mp3")));
            mediaPlayer2.Open(new Uri(Path.Combine(baseDirectory, "sounds", "storm.mp3")));
            mediaPlayer3.Open(new Uri(Path.Combine(baseDirectory, "sounds", "drops.mp3")));
            mediaPlayer4.Open(new Uri(Path.Combine(baseDirectory, "sounds", "wind.mp3")));
            mediaPlayer5.Open(new Uri(Path.Combine(baseDirectory, "sounds", "waves.mp3")));
            mediaPlayer6.Open(new Uri(Path.Combine(baseDirectory, "sounds", "underwater.mp3")));
            mediaPlayer7.Open(new Uri(Path.Combine(baseDirectory, "sounds", "stream-water.mp3")));
            mediaPlayer8.Open(new Uri(Path.Combine(baseDirectory, "sounds", "waterfall.mp3")));
            mediaPlayer9.Open(new Uri(Path.Combine(baseDirectory, "sounds", "birds-tree.mp3")));
            mediaPlayer10.Open(new Uri(Path.Combine(baseDirectory, "sounds", "leaves.mp3")));
            mediaPlayer11.Open(new Uri(Path.Combine(baseDirectory, "sounds", "fire.mp3")));
            mediaPlayer12.Open(new Uri(Path.Combine(baseDirectory, "sounds", "cave-drops.mp3")));
            mediaPlayer13.Open(new Uri(Path.Combine(baseDirectory, "sounds", "night.mp3")));
            mediaPlayer14.Open(new Uri(Path.Combine(baseDirectory, "sounds", "coffee.mp3")));
            mediaPlayer15.Open(new Uri(Path.Combine(baseDirectory, "sounds", "train.mp3")));
            mediaPlayer16.Open(new Uri(Path.Combine(baseDirectory, "sounds", "air-plane.mp3")));
            mediaPlayer17.Open(new Uri(Path.Combine(baseDirectory, "sounds", "washing-machine.mp3")));
            mediaPlayer18.Open(new Uri(Path.Combine(baseDirectory, "sounds", "playground.mp3")));
            mediaPlayer19.Open(new Uri(Path.Combine(baseDirectory, "sounds", "boat.mp3")));
            mediaPlayer20.Open(new Uri(Path.Combine(baseDirectory, "sounds", "rain-on-tent.mp3")));
            mediaPlayer21.Open(new Uri(Path.Combine(baseDirectory, "sounds", "brown-noise.mp3")));
            mediaPlayer22.Open(new Uri(Path.Combine(baseDirectory, "sounds", "white-noise.mp3")));
            mediaPlayer23.Open(new Uri(Path.Combine(baseDirectory, "sounds", "pink-noise.mp3")));


            // Pomodoro Config
            pomoTimeCount = (int)pomoTime.Value * 60;
            btnPomodoClock.Text = (pomoTimeCount / 60).ToString("D2") + ":" + (pomoTimeCount % 60).ToString("D2");
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            if (sender is MediaPlayer player)
            {
                player.Position = TimeSpan.Zero;
                player.Play();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pic)
            {
                btnSave.Enabled = true;
                if (pic.BackColor == SystemColors.Control)
                {
                    picPlayer[pic].Play();
                    picTrack[pic].Visible = true;
                    pic.BackColor = SystemColors.ControlLight;
                } else
                {
                    picPlayer[pic].Stop();
                    picTrack[pic].Visible = false;
                    pic.BackColor = SystemColors.Control;
                }
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (sender is TrackBar trackBar)
            {
                btnSave.Enabled = true;
                // Lấy giá trị từ TrackBar và chuyển đổi nó thành giá trị âm lượng (từ 0 đến 1)
                float volume = (float)trackBar.Value / trackBar.Maximum;

                // Thiết lập âm lượng cho đối tượng mediaPlayer
                trackPlayer[trackBar].Volume = volume * gVolume;
            }

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            picPlayer.Add(pictureBox1, mediaPlayer1);
            picPlayer.Add(pictureBox2, mediaPlayer2);
            picPlayer.Add(pictureBox3, mediaPlayer3);
            picPlayer.Add(pictureBox4, mediaPlayer4);
            picPlayer.Add(pictureBox5, mediaPlayer5);
            picPlayer.Add(pictureBox6, mediaPlayer6);
            picPlayer.Add(pictureBox7, mediaPlayer7);
            picPlayer.Add(pictureBox8, mediaPlayer8);
            picPlayer.Add(pictureBox9, mediaPlayer9);
            picPlayer.Add(pictureBox10, mediaPlayer10);
            picPlayer.Add(pictureBox11, mediaPlayer11);
            picPlayer.Add(pictureBox12, mediaPlayer12);
            picPlayer.Add(pictureBox13, mediaPlayer13);
            picPlayer.Add(pictureBox14, mediaPlayer14);
            picPlayer.Add(pictureBox15, mediaPlayer15);
            picPlayer.Add(pictureBox16, mediaPlayer16);
            picPlayer.Add(pictureBox17, mediaPlayer17);
            picPlayer.Add(pictureBox18, mediaPlayer18);
            picPlayer.Add(pictureBox19, mediaPlayer19);
            picPlayer.Add(pictureBox20, mediaPlayer20);
            picPlayer.Add(pictureBox21, mediaPlayer21);
            picPlayer.Add(pictureBox22, mediaPlayer22);
            picPlayer.Add(pictureBox23, mediaPlayer23);

            trackPlayer.Add(trackBar1, mediaPlayer1);
            trackPlayer.Add(trackBar2, mediaPlayer2);
            trackPlayer.Add(trackBar3, mediaPlayer3);
            trackPlayer.Add(trackBar4, mediaPlayer4);
            trackPlayer.Add(trackBar5, mediaPlayer5);
            trackPlayer.Add(trackBar6, mediaPlayer6);
            trackPlayer.Add(trackBar7, mediaPlayer7);
            trackPlayer.Add(trackBar8, mediaPlayer8);
            trackPlayer.Add(trackBar9, mediaPlayer9);
            trackPlayer.Add(trackBar10, mediaPlayer10);
            trackPlayer.Add(trackBar11, mediaPlayer11);
            trackPlayer.Add(trackBar12, mediaPlayer12);
            trackPlayer.Add(trackBar13, mediaPlayer13);
            trackPlayer.Add(trackBar14, mediaPlayer14);
            trackPlayer.Add(trackBar15, mediaPlayer15);
            trackPlayer.Add(trackBar16, mediaPlayer16);
            trackPlayer.Add(trackBar17, mediaPlayer17);
            trackPlayer.Add(trackBar18, mediaPlayer18);
            trackPlayer.Add(trackBar19, mediaPlayer19);
            trackPlayer.Add(trackBar20, mediaPlayer20);
            trackPlayer.Add(trackBar21, mediaPlayer21);
            trackPlayer.Add(trackBar22, mediaPlayer22);
            trackPlayer.Add(trackBar23, mediaPlayer23);

            picTrack.Add(pictureBox1, trackBar1);
            picTrack.Add(pictureBox2, trackBar2);
            picTrack.Add(pictureBox3, trackBar3);
            picTrack.Add(pictureBox4, trackBar4);
            picTrack.Add(pictureBox5, trackBar5);
            picTrack.Add(pictureBox6, trackBar6);
            picTrack.Add(pictureBox7, trackBar7);
            picTrack.Add(pictureBox8, trackBar8);
            picTrack.Add(pictureBox9, trackBar9);
            picTrack.Add(pictureBox10, trackBar10);
            picTrack.Add(pictureBox11, trackBar11);
            picTrack.Add(pictureBox12, trackBar12);
            picTrack.Add(pictureBox13, trackBar13);
            picTrack.Add(pictureBox14, trackBar14);
            picTrack.Add(pictureBox15, trackBar15);
            picTrack.Add(pictureBox16, trackBar16);
            picTrack.Add(pictureBox17, trackBar17);
            picTrack.Add(pictureBox18, trackBar18);
            picTrack.Add(pictureBox19, trackBar19);
            picTrack.Add(pictureBox20, trackBar20);
            picTrack.Add(pictureBox21, trackBar21);
            picTrack.Add(pictureBox22, trackBar22);
            picTrack.Add(pictureBox23, trackBar23);

            picBoxId.Add(1, pictureBox1);
            picBoxId.Add(2, pictureBox2);
            picBoxId.Add(3, pictureBox3);
            picBoxId.Add(4, pictureBox4);
            picBoxId.Add(5, pictureBox5);
            picBoxId.Add(6, pictureBox6);
            picBoxId.Add(7, pictureBox7);
            picBoxId.Add(8, pictureBox8);
            picBoxId.Add(9, pictureBox9);
            picBoxId.Add(10, pictureBox10);
            picBoxId.Add(11, pictureBox11);
            picBoxId.Add(12, pictureBox12);
            picBoxId.Add(13, pictureBox13);
            picBoxId.Add(14, pictureBox14);
            picBoxId.Add(15, pictureBox15);
            picBoxId.Add(16, pictureBox16);
            picBoxId.Add(17, pictureBox17);
            picBoxId.Add(18, pictureBox18);
            picBoxId.Add(19, pictureBox19);
            picBoxId.Add(20, pictureBox20);
            picBoxId.Add(21, pictureBox21);
            picBoxId.Add(22, pictureBox22);
            picBoxId.Add(23, pictureBox23);

            foreach (var kvp in comboSnapshot)
            {
                comboList.Items.Add(kvp.Key);
            }
            if (comboList.Items.Count > 0) comboList.SelectedIndex = 0;
        }

        private void globalVolume_Scroll(object sender, EventArgs e)
        {
            gVolume = (float)globalVolume.Value / globalVolume.Maximum;
            foreach (var kvp in trackPlayer)
            {
                kvp.Value.Volume = (float) kvp.Key.Value / kvp.Key.Maximum * gVolume;
            }
        }

        private void btnPomodoClock_Click(object sender, EventArgs e)
        {
            panelPomoConfig.Location = pomoConfigOn;
        }

        private void btnPomodoroSave_Click(object sender, EventArgs e)
        {
            panelPomoConfig.Location = pomoConfigOff;
            pomoTimeCount = (int)pomoTime.Value * 60;
            btnPomodoClock.Text = (pomoTimeCount / 60).ToString("D2") + ":" + (pomoTimeCount % 60).ToString("D2");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            panelPomoConfig.Location = pomoConfigOff;
            pomoTime.Value = 25;
            pomoTimeCount = (int)pomoTime.Value * 60;
            btnPomodoClock.Text = (pomoTimeCount / 60).ToString("D2") + ":" + (pomoTimeCount % 60).ToString("D2");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var kvp in picPlayer)
            {
                if (kvp.Key.BackColor == SystemColors.ControlLight)
                {
                    pictureBox_Click(kvp.Key, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboSnapshot.ContainsKey(comboList.Text) == false)
            {
                comboSnapshot[comboList.Text] = new PlayerSnapshot();
                comboList.Items.Insert(0, comboList.Text);
            }
            comboSnapshot[comboList.Text].storeSnapshot(picBoxId, picTrack);
            btnSave.Enabled = false;
        }

        bool changeByUser = false;

        private void comboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changeByUser == true)
            {
                changeByUser = false;
                return;
            }
            if (comboSnapshot.ContainsKey(comboList.Text) == false) return;
            comboSnapshot[comboList.Text].loadSnapshot(picBoxId, picTrack, picPlayer);

            changeByUser = true;
            string selectedItem = comboList.SelectedItem.ToString();
            comboList.Items.Remove(selectedItem);
            comboList.Items.Insert(0, selectedItem);
            comboList.SelectedIndex = 0;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            HistoryManager.StoreHistory(comboSnapshot);
        }

        private void comboList_TextUpdate(object sender, EventArgs e)
        {
            if (comboList.Text != "") btnSave.Enabled = true;
        }

        private void timerPomo_Tick(object sender, EventArgs e)
        {
            if (pomoTimeCount > 0) pomoTimeCount--;
            else
            {
                btnClear_Click(sender, e);
                timerPomo.Stop();
            }

            // Update Text
            btnPomodoClock.Text = (pomoTimeCount / 60).ToString("D2") + ":" + (pomoTimeCount % 60).ToString("D2");

        }

        private void btnTimeReset_Click(object sender, EventArgs e)
        {
            timerPomo.Stop();
            pomoTimeCount = (int)pomoTime.Value * 60;
            btnPomodoClock.Text = (pomoTimeCount / 60).ToString("D2") + ":" + (pomoTimeCount % 60).ToString("D2");
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.Text == "▷")
            {
                timerPomo.Start();
                btnPlay.Text = "||";
            }
            else
            {
                timerPomo.Stop();
                btnPlay.Text = "▷";
            }
        }
    }
}
