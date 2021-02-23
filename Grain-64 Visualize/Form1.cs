using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Grain_64_Visualize;
using System.IO;

namespace Grain_64_Visualize
{
    public partial class Form1 : Form
    {
        private bool _working;
        private bool _isOn;
        public int i;
        public byte[] key;
        public byte[] openText;
        public byte[] keyStream;
        string key_str;
        Grain_64 grain;

        public Form1()
        {
            InitializeComponent();

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            key = new byte[16] { 8, 4, 5, 6, 6, 6, 1, 6, 2, 6, 8, 6, 5, 4, 3, 12 };
            openText = new byte[26] { 49, 50, 32, 52, 54, 32, 51, 52, 32, 56, 57, 32, 56, 48, 32, 52, 53, 32, 54, 51, 32, 56, 50, 32, 55, 49 };
            loadKey();
            loadOpenText();
            keyStream = new byte[openText.Length];
        }

        void loadKey()
        {
            key_str = "";
            for (int i = 0; i < key.Length; i++)
                key_str += Convert.ToString(key[i], 2).PadLeft(8, '0') + "  ";
            Key.Text = key_str;
        }
        void loadOpenText()
        {
            string openText_str = "";
            for (int i = 0; i < openText.Length; i++)
                openText_str += Convert.ToString(openText[i], 2).PadLeft(8, '0') + "  ";
            OpenTextbox.Text = openText_str;
        }
        private void Start_button_Click(object sender, EventArgs e)
        {
            _working = true;
            Stop_button.Enabled = true;
            _isOn = true;
            Stop_button.Text = "Stop";
            grain = new Grain_64
            {
                key = key,
                lfsr = key.Take(key.Length / 2).ToArray(),
                nfsr = key.Skip(key.Length / 2).ToArray()
            };         
            grain.Init();
            backgroundWorker1.WorkerSupportsCancellation = true;
            if (backgroundWorker1.WorkerSupportsCancellation)
            {
                backgroundWorker1.CancelAsync();
                i = 0;
            }
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();             
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (i = 0; i < openText.Length; i++)
            {
                int h = Convert.ToInt32(grain.Enc());
                int ha = h << (7 - (i % 8));
               // int b = 1 << 5;/////////////////////////////////!!!!!!!!!!!!?//////////////////
                keyStream[7 - (i / 8)] = Convert.ToByte(ha);//??
                Thread.Sleep(1000);
                while(!_working)
                    Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(i);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            label1.Text = "Iteration: " + e.ProgressPercentage.ToString();
            string lfsr_str = "";
            for (int i = 0; i < grain.lfsr.Length; i++)
                lfsr_str += Convert.ToString(grain.lfsr[i], 2).PadLeft(8, '0') + "  ";
            LFSR.Text = lfsr_str;

            string nfsr_str = "";
            for (int i = 0; i < grain.nfsr.Length; i++)
                nfsr_str += Convert.ToString(grain.nfsr[i], 2).PadLeft(8, '0') + "  ";
            NFSR.Text = nfsr_str;

            string keystream_str = "";
            for (int i = 0; i < keyStream.Length; i++)
                keystream_str += Convert.ToString(keyStream[i], 2).PadLeft(8, '0') + "  ";
            KeyStreamTextBox.Text = keystream_str;
        }

        private void Stop_button_Click(object sender, EventArgs e)
        {
            if (_isOn)
            {
                _working = false;
                _isOn = false;
                Stop_button.Text = "Continue";
            }
            else
            {
                _working = true;
                _isOn = true;
                Stop_button.Text = "Stop";
            }
        }

        private void KeyOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                try
                {
                    string[] file_txt = File.ReadAllText(fileName).Split(' ');
                    for (int i = 0; i < key.Length; i++)
                        key[i] = Convert.ToByte(file_txt[i]);
                    loadKey();
                }
                catch (IOException exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private async void FileToolStripMenuItem1_ClickAsync(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                try
                {
                    using (FileStream SourceStream = File.Open(fileName, FileMode.Open))
                    {
                        openText = new byte[SourceStream.Length];
                        await SourceStream.ReadAsync(openText, 0, (int)SourceStream.Length);
                    }
                }
                catch (IOException exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            loadOpenText();
            keyStream = new byte[openText.Length];
        }
    }
}
